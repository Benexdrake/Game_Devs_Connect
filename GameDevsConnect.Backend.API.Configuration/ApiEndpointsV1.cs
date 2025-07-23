namespace GameDevsConnect.Backend.API.Configuration;

public static class ApiEndpointsV1
{
    public const string Version = "1";
    private const string Base = $"api/v{{apiVersion:apiVersion}}";
    public const string Health = "_health";

    public static ApiVersionSet GetVersionSet(IEndpointRouteBuilder app)
    {
        return app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(int.Parse(Version)))
            .ReportApiVersions()
            .Build();
    }

    public static class Azure
    {
        public const string GroupBlob = $"{Base}/{nameof(Azure)}/blob";
        public const string Get = $"/";
        public const string Upload = $"upload";
        public const string Delete = $"delete";

        public static class MetaData
        {
            public static class Name
            {
                public const string Get = "GetFileUrl";
                public const string Upload = "UploadFile";
                public const string Delete = "DeleteFile";
            }

            public static class Description
            {
                public const string Get = "GetFileUrl";
                public const string Upload = "UploadFile";
                public const string Delete = "DeleteFile";
            }
        }
    }

    public static class File
    {
        public const string Group = $"{Base}/{nameof(File)}";
        public const string Get = $"{{id}}";
        public const string GetByOwnerId = $"owner/{{id}}";
        public const string GetByPostParentId = $"post/{{id}}";
        public const string Create = "add";
        public const string Update = "update";
        public const string Delete = $"delete/{{id}}";

        public static class MetaData
        {
            public static class Name
            {
                public const string Get = "GetFile";
                public const string GetByOwnerId = "GetFileIdsByOwnerId";
                public const string GetByPostParentId = "GetFileIdsByPostParentId";
                public const string Create = "AddFile";
                public const string Update = "UpdateFile";
                public const string Delete = "DeleteFile";
            }

            public static class Description
            {
                public const string Get = "GetFile";
                public const string GetByOwnerId = "GetFileIdsByOwnerId";
                public const string GetByPostParentId = "GetFileIdsByPostParentId";
                public const string Create = "AddFile";
                public const string Update = "UpdateFile";
                public const string Delete = "DeleteFile";
            }
        }
    }

    public static class Gateway
    {
        public const string Login = "/login";

        public static class MetaData
        {
            public static class Name
            {
                public const string Login = "Login";
            }

            public static class Description
            {
                public const string Login = "Login";
            }
        }
    }

    public static class Notification
    {
        public const string Group = $"{Base}/{nameof(Notification)}";
        public const string GetCount = $"count/{{id}}";
        public const string Get = $"{{id}}";
        public const string GetByUserId = $"user/{{id}}";
        public const string Create = "add";
        public const string Update = $"update/{{id}}";
        public const string Delete = $"delete/{{id}}";

        public static class MetaData
        {
            public static class Name
            {
                public const string GetCount = $"GetNotificationsCountById";
                public const string Get = $"GetNotification";
                public const string GetByUserId = $"GetNotificationsByUserId";
                public const string Create = "CreateNotification";
                public const string Update = "UpdateNotification";
                public const string Delete = "DeleteNotification";
            }

            public static class Description
            {
                public const string GetCount = $"GetNotificationsCountById";
                public const string Get = $"GetNotification";
                public const string GetByUserId = $"GetNotificationsByUserId";
                public const string Create = "CreateNotification";
                public const string Update = "UpdateNotification";
                public const string Delete = "DeleteNotification";
            }
        }
    }

    public static class Post
    {
        public const string Group = $"{Base}/{nameof(Post)}";
        public const string Get = "/";
        public const string GetById = $"{{id}}";
        public const string GetFull = $"full/{{id}}";
        public const string GetByUserId = $"user/{{id}}";
        public const string GetCommentByParentId = $"comment/{{id}}";
        public const string Create = "add";
        public const string Update = "update";
        public const string Delete = $"delete/{{id}}";

        public static class MetaData
        {
            public static class Name
            {
                public const string Get = "GetPostIds";
                public const string GetById = "GetPostById";
                public const string GetFull = "GetFullPost";
                public const string GetByUserId = "GetPostIdsByUserId";
                public const string GetCommentByParentId = "GetCommentByParentId";
                public const string Create = "CreatePost";
                public const string Update = "UpdatePost";
                public const string Delete = "DeletePost";
            }

            public static class Description
            {
                public const string Get = "GetPostIds";
                public const string GetById = "GetPostById";
                public const string GetFull = "GetFullPost";
                public const string GetByUserId = "GetPostIdsByUserId";
                public const string GetCommentByParentId = "GetCommentByParentId";
                public const string Create = "CreatePost";
                public const string Update = "UpdatePost";
                public const string Delete = "DeletePost";
            }
        }
    }

    public static class Profile
    {
        public const string Group = $"{Base}/{nameof(Profile)}";
        public const string Get = $"{{id}}";
        public const string GetFull = $"full/{{id}}";
        public const string Create = $"add/{{id}}";
        public const string Update = $"update";
        public const string Delete = $"delete/{{id}}";

        public static class MetaData
        {
            public static class Name
            {
                public const string Get = "GetProfileById";
                public const string GetFull = "GetFullProfile";
                public const string Create = "CreateProfile";
                public const string Update = "UpdateProfile";
                public const string Delete = "DeleteProfile";
            }

            public static class Description
            {
                public const string Get = "GetProfileById";
                public const string GetFull = "GetFullProfile";
                public const string Create = "CreateProfile";
                public const string Update = "UpdateProfile";
                public const string Delete = "DeleteProfile";
            }
        }
    }

    public static class Project
    {
        public const string Group = $"{Base}/{nameof(Project)}";
        public const string Get = $"/";
        public const string GetByRequestId = $"{{id}}";
        public const string Create = $"add";
        public const string Update = $"update";
        public const string Delete = $"delete/{{id}}";

        public static class MetaData
        {
            public static class Name
            {
                public const string Get = $"GetAllProjectIds";
                public const string GetByRequestId = $"GetProjectByRequestId";
                public const string Create = $"CreateProject";
                public const string Update = $"UpdateProject";
                public const string Delete = $"DeleteProject";
            }

            public static class Description
            {
                public const string Get = $"GetAllProjectIds";
                public const string GetByRequestId = $"GetProjectByRequestId";
                public const string Create = $"CreateProject";
                public const string Update = $"UpdateProject";
                public const string Delete = $"DeleteProject";
            }
        }
    }

    public static class Quest
    {
        public const string Group = $"{Base}/{nameof(Quest)}";
        public const string Get = $"{{id}}";
        public const string GetFavorites = $"/favorites";
        public const string GetIdsByPostId = $"post/{{id}}";
        public const string Create = "add";
        public const string Complete = "complete";
        public const string Update = "update";
        public const string Delete = $"delete/{{id}}";
        public const string Favorite = $"favorite";

        public static class MetaData
        {
            public static class Name
            {
                public const string Get = "GetQuest";
                public const string GetFavorites = "GetFavoriteQuests";
                public const string GetIdsByPostId = "GetPostIds";
                public const string Create = "CreateQuest";
                public const string Complete = "CompleteQuest";
                public const string Update = "UpdateQuest";
                public const string Delete = "DeleteQuest";
                public const string Favorite = $"FavoriteQuest";
            }

            public static class Description
            {
                public const string Get = "GetQuest";
                public const string GetFavorites = "GetFavoriteQuests";
                public const string GetIdsByPostId = "GetPostIds";
                public const string Create = "CreateQuest";
                public const string Complete = "CompleteQuest";
                public const string Update = "UpdateQuest";
                public const string Delete = "DeleteQuest";
                public const string Favorite = $"FavoriteQuest";
            }
        }
    }

    public static class Request
    {
        public const string Group = $"{Base}/{nameof(Request)}";
        public const string Get = "/";
        public const string GetByRequestId = $"{{id}}";
        public const string GetFull = $"full/{{id}}";
        public const string GetByUserId = $"user/{{id}}";
        public const string Create = "add";
        public const string Update = "update";
        public const string Delete = $"delete/{{id}}";

        public static class MetaData
        {
            public static class Name
            {
                public const string Get = "GetRequestIds";
                public const string GetByRequestId = "GetRequestById";
                public const string GetFull = "GetFullRequest";
                public const string GetByUserId = "GetRequestIdsByUserId";
                public const string Create = "CreateRequest";
                public const string Update = "UpdateRequest";
                public const string Delete = "DeleteRequest";
            }

            public static class Description
            {
                public const string Get = "GetRequestIds";
                public const string GetByRequestId = "GetRequestById";
                public const string GetFull = "GetFullRequest";
                public const string GetByUserId = "GetRequestIdsByUserId";
                public const string Create = "CreateRequest";
                public const string Update = "UpdateRequest";
                public const string Delete = "DeleteRequest";
            }
        }
    }

    public static class Tag
    {

        public const string Group = $"{Base}/{nameof(Tag)}";
        public const string GetAll = "/";
        public const string Create = "/add";
        public const string Update = "/update";
        public const string Delete = $"/delete/{{tag}}";

        public static class MetaData
        {
            public static class Name
            {
                public const string GetAll = "GetAllTags";
                public const string Create = "CreateTag";
                public const string Update = "UpdateTag";
                public const string Delete = "DeleteTag";
            }

            public static class Description
            {
                public const string GetAll = "GetAllTags";
                public const string Create = "CreateTag";
                public const string Update = "UpdateTag";
                public const string Delete = "DeleteTag";
            }
        }
    }

    public static class User
    {
        public const string Group = $"{Base}/{nameof(User)}";
        public const string GetIds = $"";
        public const string Get = $"{{id}}";
        
        public const string GetFollower = $"follower/{{id}}";
        public const string GetFollowing = $"following/{{id}}";
        public const string GetFollowerCount = $"follower/count/{{id}}";
        public const string GetFollowingCount = $"following/count/{{id}}";
        public const string GetIdsByProjectId = $"project/{{id}}";

        public const string Exist = $"exist/{{id}}";
        public const string Create = $"add";
        public const string Update = $"update";
        public const string Delete = $"delete/{{id}}";

        public static class MetaData
        {
            public static class Name
            {
                public const string GetIds = $"GetAllUserIds";
                public const string Get = $"GetUserById";
                public const string GetFollower = $"GetFollowerIds";
                public const string GetFollowing = $"GetFollowingIds";
                public const string GetFollowerCount = $"GetFollowerCount";
                public const string GetFollowingCount = $"GetFollwingCount";
                public const string GetIdsByProjectId = $"GetIdsByProjectId";
                public const string Exist = $"GetExistingUserById";
                public const string Create = $"CreateUser";
                public const string Update = $"UpdateUser";
                public const string Delete = $"DeleteUser";
            }

            public static class Description
            {
                public const string GetIds = $"Get All User Ids with Page, PageSize and Searchterm";
                public const string Get = $"GetUserById";
                public const string GetFollower = $"GetFollowerIds";
                public const string GetFollowing = $"GetFollowingIds";
                public const string GetFollowerCount = $"GetFollowerCount";
                public const string GetFollowingCount = $"GetFollwingCount";
                public const string GetIdsByProjectId = $"GetIdsByProjectId";
                public const string Exist = $"GetExistingUserById";
                public const string Create = $"CreateUser";
                public const string Update = $"UpdateUser";
                public const string Delete = $"DeleteUser";
            }
        }
    }

}
