﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace UwpCommunityBackend.Models
{
    public class Project
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("collaborators")]
        public List<Collaborator> Collaborators { get; set; }

        [JsonProperty("launchYear")]
        public short? LaunchYear { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty("needsManualReview")]
        public bool NeedsManualReview { get; set; }

        [JsonProperty("appName")]
        public string AppName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("isPrivate")]
        public bool IsPrivate { get; set; }

        [JsonProperty("downloadLink")]
        public string DownloadLink { get; set; }

        [JsonProperty("githubLink")]
        public string GitHubLink { get; set; }

        [JsonProperty("externalLink")]
        public string ExternalLink { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("awaitingLaunchApproval")]
        public bool? IsAwaitingLaunchApproval { get; set; }

        [JsonProperty("heroImage")]
        public string HeroImage { get; set; } = "https://uwpcommunity.com/assets/img/LaunchHero.jpg";

        [JsonProperty("appIcon")]
        public string AppIcon { get; set; } = "https://uwpcommunity.com/assets/img/LaunchHero.jpg";

        [JsonProperty("lookingForRoles")]
        public bool? IsLookingForRoles { get; set; }

        [JsonProperty("images")]
        public List<object> Images { get; set; }

        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }

        [JsonProperty("accentColor")]
        public string AccentColor { get; set; }

        /// <summary>
        /// The role the user had in this project. Only for use with POST /projects/
        /// </summary>
        [JsonProperty("role")]
        public string Role { get; set; } = "Developer";

        public System.Uri HeroImageUri {
            get {
                return new System.Uri(HeroImageSafe);
            }
        }

        /// <summary>
        /// A duplicate of HeroImage, but returns a dummy image if null
        /// </summary>
        public string HeroImageSafe {
            get {
                return HeroImage ?? "https://uwpcommunity.com/assets/img/LaunchHero.png";
            }
        }

        public Collaborator Owner => Collaborators.First(c => c.IsOwner);

        public enum ProjectCategory
        {
            BooksAndReference,
            Business,
            DeveloperTools,
            Education,
            Entertainment,
            FoodAndDining,
            GovernmentAndPolitics,
            KidsAndFamily,
            Lifestyle,
            Medical,
            MultimediaDesign,
            Music,
            NavigationAndMaps,
            NewsAndWeather,
            PersonalFinance,
            Personalization,
            PhotoAndVideo,
            Productivity,
            Security,
            Shopping,
            Social,
            Sports,
            Travel,
            UtilitiesAndTools
        }
        public static string GetCategoryTitle(ProjectCategory category)
        {
            switch (category)
            {
                case ProjectCategory.BooksAndReference:
                    return "Books & reference";

                case ProjectCategory.Business:
                    return "Business";

                case ProjectCategory.DeveloperTools:
                    return "Developer tools";

                case ProjectCategory.Education:
                    return "Education";

                case ProjectCategory.Entertainment:
                    return "Entertainment";

                case ProjectCategory.FoodAndDining:
                    return "Food & dining";

                case ProjectCategory.GovernmentAndPolitics:
                    return "Government & politics";

                case ProjectCategory.KidsAndFamily:
                    return "Kids & family";

                case ProjectCategory.Lifestyle:
                    return "Lifestyle";

                case ProjectCategory.Medical:
                    return "Medical";

                case ProjectCategory.MultimediaDesign:
                    return "Multimedia design";

                case ProjectCategory.Music:
                    return "Music";

                case ProjectCategory.NavigationAndMaps:
                    return "Navigation & maps";

                case ProjectCategory.NewsAndWeather:
                    return "News & weather";

                case ProjectCategory.PersonalFinance:
                    return "Personal finance";

                case ProjectCategory.Personalization:
                    return "Personalization";

                case ProjectCategory.PhotoAndVideo:
                    return "Photo & video";

                case ProjectCategory.Productivity:
                    return "Productivity";

                case ProjectCategory.Security:
                    return "Security";

                case ProjectCategory.Shopping:
                    return "Shopping";

                case ProjectCategory.Social:
                    return "Social";

                case ProjectCategory.Sports:
                    return "Sports";

                case ProjectCategory.Travel:
                    return "Travel";

                case ProjectCategory.UtilitiesAndTools:
                    return "Utilities & tools";

                default:
                    return "";
            }
        }
        public static ProjectCategory GetCategoryFromTitle(string name)
        {
            switch (name)
            {
                case "Books & reference":
                    return ProjectCategory.BooksAndReference;

                case "Business":
                    return ProjectCategory.Business;

                case "Developer tools":
                    return ProjectCategory.DeveloperTools;

                case "Education":
                    return ProjectCategory.Education;

                case "Entertainment":
                    return ProjectCategory.Entertainment;

                case "Food & dining":
                    return ProjectCategory.FoodAndDining;

                case "Government & politics":
                    return ProjectCategory.GovernmentAndPolitics;

                case "Kids & family":
                    return ProjectCategory.KidsAndFamily;

                case "Lifestyle":
                    return ProjectCategory.Lifestyle;

                case "Medical":
                    return ProjectCategory.Medical;

                case "Multimedia design":
                    return ProjectCategory.MultimediaDesign;

                case "Music":
                    return ProjectCategory.MultimediaDesign;

                case "Navigation & maps":
                    return ProjectCategory.NavigationAndMaps;

                case "News & weather":
                    return ProjectCategory.NewsAndWeather;

                case "Personal finance":
                    return ProjectCategory.PersonalFinance;

                case "Personalization":
                    return ProjectCategory.Personalization;

                case "Photo & video":
                    return ProjectCategory.PhotoAndVideo;

                case "Productivity":
                    return ProjectCategory.Productivity;

                case "Security":
                    return ProjectCategory.Security;

                case "Shopping":
                    return ProjectCategory.Shopping;

                case "Social":
                    return ProjectCategory.Social;

                case "Sports":
                    return ProjectCategory.Sports;

                case "Travel":
                    return ProjectCategory.Travel;

                case "Utilities & tools":
                    return ProjectCategory.UtilitiesAndTools;

                default:
                    return ProjectCategory.BooksAndReference;
            }
        }

        /// <summary>
        /// Checks if the user is the owner of this project
        /// </summary>
        public bool IsOwner(string userId)
		{
            var owner = Collaborators.Find(c => c.IsOwner == true);
            return owner.DiscordId == userId;
		}

        /// <summary>
        /// Checks if the user is a developer for this project
        /// </summary>
        public bool IsDeveloper(string userId)
		{
            var user = Collaborators.Find(c => c.DiscordId == userId);
            return user.Role == Collaborator.RoleType.Developer;
		}
        /// <summary>
        /// Checks if the user is a translator for this project
        /// </summary>
        public bool IsTranslator(string userId)
		{
            var user = Collaborators.Find(c => c.DiscordId == userId);
            return user.Role == Collaborator.RoleType.Translator;
		}
        /// <summary>
        /// Checks if the user is a beta tester for this project
        /// </summary>
        public bool IsBetaTester(string userId)
		{
            var user = Collaborators.Find(c => c.DiscordId == userId);
            return user.Role == Collaborator.RoleType.BetaTester;
		}

        public IEnumerable<Collaborator> GetDevelopers()
		{
            return Collaborators.Where(c => c.Role == Collaborator.RoleType.Developer);
		}
        public IEnumerable<Collaborator> GetTranslators()
		{
            return Collaborators.Where(c => c.Role == Collaborator.RoleType.Translator);
		}
        public IEnumerable<Collaborator> GetBetaTesters()
		{
            return Collaborators.Where(c => c.Role == Collaborator.RoleType.BetaTester);
		}

        public override string ToString()
        {
            return $"{AppName} by {Owner.Name}: {Description}";
        }
    }

    public class NewProjectRequest
    {
        [JsonProperty("appName")]
        public string AppName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("isPrivate")]
        public bool IsPrivate { get; set; }

        [JsonProperty("downloadLink")]
        public string DownloadLink { get; set; }

        [JsonProperty("githubLink")]
        public string GitHubLink { get; set; }

        [JsonProperty("externalLink")]
        public string ExternalLink { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("heroImage")]
        public string HeroImage { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }

    public class DeleteProjectRequest
    {
        [JsonProperty("appName")]
        public string AppName { get; set; }

        public DeleteProjectRequest(string appName)
        {
            AppName = appName;
        }

        public static explicit operator DeleteProjectRequest(string appName)
        {
            return new DeleteProjectRequest(appName);
        }
        public static explicit operator string(DeleteProjectRequest info)
        {
            return info?.AppName;
        }

        public override string ToString()
        {
            return AppName;
        }
    }
}
