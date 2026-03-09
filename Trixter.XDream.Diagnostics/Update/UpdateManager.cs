using System;
using System.Linq;
using System.Threading.Tasks;
using Trixter.XDream.Diagnostics.Properties;



namespace Trixter.XDream.Diagnostics.Update
{
    internal class UpdateManager
    {
        private readonly Settings settings;
        private string updateRepo;
        private UpdateState updateState;

        public Version LatestRelease { get; private set; }
        public Uri ReleasesUri => UpdateChecker.ReleasesUri(this.updateRepo);

        public UpdateManager(Settings settings, string updateRepo)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.updateRepo = updateRepo;
        }

        /// <summary>
        /// Implemented by subclasses to determine whether an update is available.
        /// </summary>
        protected async Task<UpdateChecker.ReleaseInfo> GetNewReleaseInfo()
        {
            var updateChecker = new UpdateChecker(this.updateRepo);
            return await updateChecker.GetLatestRelease();
        }

        public DateTime LastUpdateCheckUtc
        {
            get => settings.LastUpdateCheckDateUtc;
            protected set
            {
                this.settings.LastUpdateCheckDateUtc = value;
                this.settings.Save();
            }
        }

        public bool AutoUpdateChecksEnabled
        {
            get => settings.AutomaticUpdateChecksEnabled;
        }

        public int UpdateCheckIntervalDays
        {
            get => settings.UpdateIntervalCheckDays;
        }

        public event EventHandler<UpdateState> UpdateStateChanged;

        public UpdateState UpdateState
        {
            get => updateState;
            private set
            {
                if(this.updateState!=value)
                {
                    this.updateState = value;
                    OnUpdateStateChanged(value);
                }
            }
        }

        public Exception LastException { get; private set; }

        protected virtual void OnUpdateStateChanged(UpdateState newState)
        {
            this.UpdateStateChanged?.Invoke(this, newState);
        }

        /// <summary>
        /// Checks whether an update is required and updates the current update state asynchronously.
        /// </summary>
        /// <returns>A <see cref="UpdateState"/> value that indicates the result of the update check.</returns>
        public async Task<UpdateState> CheckForUpdatesIfNeeded(bool forceIfNotDue)
        {
            this.UpdateState = await CheckForUpdatesIfNeededInternal(forceIfNotDue);
            return this.UpdateState;
        }

        /// <summary>
        /// Checks whether an update is available and updates the current update state asynchronously.
        /// </summary>
        /// <returns>A <see cref="UpdateState"/> value that indicates the result of the update check.</returns>
        public async Task<UpdateState> CheckForUpdates()
        {
            this.UpdateState = await CheckForUpdatesInternal();
            return this.UpdateState;
        }

        /// <summary>
        /// Checks for updates if automatic checks are enabled and the interval has elapsed.
        /// Returns true if an update is available.
        /// </summary>
        private async Task<UpdateState> CheckForUpdatesIfNeededInternal(bool forceIfNotDue)
        {
            var elapsedDays = (DateTime.UtcNow - LastUpdateCheckUtc).TotalDays;
            bool checkDue = forceIfNotDue || elapsedDays >= UpdateCheckIntervalDays;
            
            if (!AutoUpdateChecksEnabled)
            {
                return checkDue ? UpdateState.UpdateCheckDue:UpdateState.None;
            }

            return await CheckForUpdatesInternal();
        }

        /// <summary>
        /// Checks for updates.
        /// </summary>
        private async Task<UpdateState> CheckForUpdatesInternal()
        {
            try
            {
                var newRelease = await GetNewReleaseInfo();

                LastUpdateCheckUtc = DateTime.UtcNow;
                

                if (newRelease != null)
                {
                    this.LatestRelease = newRelease.Release;    
                }
                else
                {
                    this.LatestRelease = null;
                }

                return this.LatestRelease!=null ? UpdateState.UpdateAvailable : UpdateState.UpToDate;
            }
            catch (Exception e)
            {
                this.LastException = e;
                return UpdateState.Error;
            }

        }
    }



}
