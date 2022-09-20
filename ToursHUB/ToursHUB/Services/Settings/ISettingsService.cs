﻿namespace ToursHUB.Services.Settings
{
    public interface ISettingsService
    {
        string AuthAccessToken { get; set; }
        string AuthIdToken { get; set; }
        bool UseLocalDb { get; set; }
        string UrlBase { get; set; }
        bool UseFakeLocation { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
        bool AllowGpsLocation { get; set; }
    }
}
