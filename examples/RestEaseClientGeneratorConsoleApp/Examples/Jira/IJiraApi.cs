using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AnyOfTypes;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.Jira.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Api
{
    /// <summary>
    /// Jira Cloud platform REST API documentation
    /// </summary>
    public interface IJiraApi
    {
        /// <summary>
        /// Update custom fields
        /// </summary>
        /// <param name="content">List of updates for a custom fields.</param>
        /// <param name="generateChangelog">Whether to generate a changelog for this update.</param>
        [Post("/rest/api/3/app/field/value")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<UpdateMultipleCustomFieldValuesResult, object>>> UpdateMultipleCustomFieldValuesAsync([Body] MultipleCustomFieldValuesUpdateDetails content, [Query] bool? generateChangelog);

        /// <summary>
        /// Get custom field configurations
        /// </summary>
        /// <param name="fieldIdOrKey">The ID or key of the custom field, for example `customfield_10000`.</param>
        /// <param name="id">The list of configuration IDs. To include multiple configurations, separate IDs with an ampersand: `id=10000&id=10001`. Can't be provided with `fieldContextId`, `issueId`, `projectKeyOrId`, or `issueTypeId`.</param>
        /// <param name="contextId">DEPRECATED. Do not use.</param>
        /// <param name="fieldContextId">The list of field context IDs. To include multiple field contexts, separate IDs with an ampersand: `fieldContextId=10000&fieldContextId=10001`. Can't be provided with `id`, `issueId`, `projectKeyOrId`, or `issueTypeId`.</param>
        /// <param name="issueId">The ID of the issue to filter results by. If the issue doesn't exist, an empty list is returned. Can't be provided with `contextIds`, `projectKeyOrId`, or `issueTypeId`.</param>
        /// <param name="projectKeyOrId">The ID or key of the project to filter results by. Must be provided with `issueTypeId`. Can't be provided with `contextIds` or `issueId`.</param>
        /// <param name="issueTypeId">The ID of the issue type to filter results by. Must be provided with `projectKeyOrId`. Can't be provided with `contextIds` or `issueId`.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/app/field/{fieldIdOrKey}/context/configuration")]
        Task<Response<AnyOf<PageBeanContextualConfiguration, object>>> GetCustomFieldConfigurationAsync([Path] string fieldIdOrKey, [Query] long[] id, [Query] long[] contextId, [Query] long[] fieldContextId, [Query] long? issueId, [Query] string projectKeyOrId, [Query] string issueTypeId, [Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Update custom field configurations
        /// </summary>
        /// <param name="fieldIdOrKey">The ID or key of the custom field, for example `customfield_10000`.</param>
        /// <param name="content">Details of configurations for a custom field.</param>
        [Put("/rest/api/3/app/field/{fieldIdOrKey}/context/configuration")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<UpdateCustomFieldConfigurationResult, object>>> UpdateCustomFieldConfigurationAsync([Path] string fieldIdOrKey, [Body] CustomFieldConfigurations content);

        /// <summary>
        /// Update custom field value
        /// </summary>
        /// <param name="fieldIdOrKey">The ID or key of the custom field. For example, `customfield_10010`.</param>
        /// <param name="content">Details of updates for a custom field.</param>
        /// <param name="generateChangelog">Whether to generate a changelog for this update.</param>
        [Put("/rest/api/3/app/field/{fieldIdOrKey}/value")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<UpdateCustomFieldValueResult, object>>> UpdateCustomFieldValueAsync([Path] string fieldIdOrKey, [Body] CustomFieldValueUpdateDetails content, [Query] bool? generateChangelog);

        /// <summary>
        /// Get application property
        /// </summary>
        /// <param name="key">The key of the application property.</param>
        /// <param name="permissionLevel">The permission level of all items being returned in the list.</param>
        /// <param name="keyFilter">When a `key` isn't provided, this filters the list of results by the application property `key` using a regular expression. For example, using `jira.lf.*` will return all application properties with keys that start with *jira.lf.*.</param>
        [Get("/rest/api/3/application-properties")]
        Task<Response<AnyOf<ApplicationProperty[], object>>> GetApplicationPropertyAsync([Query] string key, [Query] string permissionLevel, [Query] string keyFilter);

        /// <summary>
        /// Get advanced settings
        /// </summary>
        [Get("/rest/api/3/application-properties/advanced-settings")]
        Task<Response<AnyOf<ApplicationProperty[], object>>> GetAdvancedSettingsAsync();

        /// <summary>
        /// Set application property
        /// </summary>
        /// <param name="id">The key of the application property to update.</param>
        /// <param name="content"></param>
        [Put("/rest/api/3/application-properties/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ApplicationProperty, object>>> SetApplicationPropertyAsync([Path] string id, [Body] SimpleApplicationPropertyBean content);

        /// <summary>
        /// Get all application roles
        /// </summary>
        [Get("/rest/api/3/applicationrole")]
        Task<Response<AnyOf<ApplicationRole[], object>>> GetAllApplicationRolesAsync();

        /// <summary>
        /// Get application role
        /// </summary>
        /// <param name="key">The key of the application role. Use the [Get all application roles](#api-rest-api-3-applicationrole-get) operation to get the key for each application role.</param>
        [Get("/rest/api/3/applicationrole/{key}")]
        Task<Response<AnyOf<ApplicationRole, object>>> GetApplicationRoleAsync([Path] string key);

        /// <summary>
        /// Get attachment content
        /// </summary>
        /// <param name="id">The ID of the attachment.</param>
        /// <param name="redirect">Whether a redirect is provided for the attachment download. Clients that do not automatically follow redirects can set this to `false` to avoid making multiple requests to download the attachment.</param>
        [Get("/rest/api/3/attachment/content/{id}")]
        Task<Response<AnyOf<GetAttachmentContentResult, object>>> GetAttachmentContentAsync([Path] string id, [Query] bool? redirect);

        /// <summary>
        /// Get Jira attachment settings
        /// </summary>
        [Get("/rest/api/3/attachment/meta")]
        Task<Response<AnyOf<AttachmentSettings, object>>> GetAttachmentMetaAsync();

        /// <summary>
        /// Get attachment thumbnail
        /// </summary>
        /// <param name="id">The ID of the attachment.</param>
        /// <param name="redirect">Whether a redirect is provided for the attachment download. Clients that do not automatically follow redirects can set this to `false` to avoid making multiple requests to download the attachment.</param>
        /// <param name="fallbackToDefault">Whether a default thumbnail is returned when the requested thumbnail is not found.</param>
        /// <param name="width">The maximum width to scale the thumbnail to.</param>
        /// <param name="height">The maximum height to scale the thumbnail to.</param>
        [Get("/rest/api/3/attachment/thumbnail/{id}")]
        Task<Response<AnyOf<GetAttachmentThumbnailResult, object>>> GetAttachmentThumbnailAsync([Path] string id, [Query] bool? redirect, [Query] bool? fallbackToDefault, [Query] int? width, [Query] int? height);

        /// <summary>
        /// Get attachment metadata
        /// </summary>
        /// <param name="id">The ID of the attachment.</param>
        [Get("/rest/api/3/attachment/{id}")]
        Task<Response<AnyOf<AttachmentMetadata, object>>> GetAttachmentAsync([Path] string id);

        /// <summary>
        /// Delete attachment
        /// </summary>
        /// <param name="id">The ID of the attachment.</param>
        [Delete("/rest/api/3/attachment/{id}")]
        Task<object> RemoveAttachmentAsync([Path] string id);

        /// <summary>
        /// Get all metadata for an expanded attachment
        /// </summary>
        /// <param name="id">The ID of the attachment.</param>
        [Get("/rest/api/3/attachment/{id}/expand/human")]
        Task<Response<AnyOf<AttachmentArchiveMetadataReadable, object>>> ExpandAttachmentForHumansAsync([Path] string id);

        /// <summary>
        /// Get contents metadata for an expanded attachment
        /// </summary>
        /// <param name="id">The ID of the attachment.</param>
        [Get("/rest/api/3/attachment/{id}/expand/raw")]
        Task<Response<AnyOf<AttachmentArchiveImpl, object>>> ExpandAttachmentForMachinesAsync([Path] string id);

        /// <summary>
        /// Get audit records
        /// </summary>
        /// <param name="offset">The number of records to skip before returning the first result.</param>
        /// <param name="limit">The maximum number of results to return.</param>
        /// <param name="filter">The strings to match with audit field content, space separated.</param>
        /// <param name="x2825b7af bd90 4af6 8b20 8624320fcc51">The date and time on or after which returned audit records must have been created. If `to` is provided `from` must be before `to` or no audit records are returned.</param>
        /// <param name="to">The date and time on or before which returned audit results must have been created. If `from` is provided `to` must be after `from` or no audit records are returned.</param>
        [Get("/rest/api/3/auditing/record")]
        Task<Response<AnyOf<AuditRecords, object>>> GetAuditRecordsAsync([Query] int? offset, [Query] int? limit, [Query] string filter, [Query(Name = "from")] DateTime? x2825b7af bd90 4af6 8b20 8624320fcc51, [Query] DateTime? to);

        /// <summary>
        /// Get system avatars by type
        /// </summary>
        /// <param name="type">The avatar type.</param>
        [Get("/rest/api/3/avatar/{type}/system")]
        Task<Response<AnyOf<SystemAvatars, object>>> GetAllSystemAvatarsAsync([Path] string type);

        /// <summary>
        /// Get comments by IDs
        /// </summary>
        /// <param name="content">The list of comment IDs.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about comments in the response. This parameter accepts a comma-separated list. Expand options include: *  `renderedBody` Returns the comment body rendered in HTML. *  `properties` Returns the comment's properties.</param>
        [Post("/rest/api/3/comment/list")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PageBeanComment, object>>> GetCommentsByIdsAsync([Body] IssueCommentListRequestBean content, [Query] string expand);

        /// <summary>
        /// Get comment property keys
        /// </summary>
        /// <param name="commentId">The ID of the comment.</param>
        [Get("/rest/api/3/comment/{commentId}/properties")]
        Task<Response<AnyOf<PropertyKeys, object>>> GetCommentPropertyKeysAsync([Path] string commentId);

        /// <summary>
        /// Get comment property
        /// </summary>
        /// <param name="commentId">The ID of the comment.</param>
        /// <param name="propertyKey">The key of the property.</param>
        [Get("/rest/api/3/comment/{commentId}/properties/{propertyKey}")]
        Task<Response<AnyOf<EntityProperty, object>>> GetCommentPropertyAsync([Path] string commentId, [Path] string propertyKey);

        /// <summary>
        /// Set comment property
        /// </summary>
        /// <param name="commentId">The ID of the comment.</param>
        /// <param name="propertyKey">The key of the property. The maximum length is 255 characters.</param>
        [Put("/rest/api/3/comment/{commentId}/properties/{propertyKey}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SetCommentPropertyResult, object>>> SetCommentPropertyAsync([Path] string commentId, [Path] string propertyKey);

        /// <summary>
        /// Delete comment property
        /// </summary>
        /// <param name="commentId">The ID of the comment.</param>
        /// <param name="propertyKey">The key of the property.</param>
        [Delete("/rest/api/3/comment/{commentId}/properties/{propertyKey}")]
        Task<object> DeleteCommentPropertyAsync([Path] string commentId, [Path] string propertyKey);

        /// <summary>
        /// Create component
        /// </summary>
        /// <param name="content">Details about a project component.</param>
        [Post("/rest/api/3/component")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ProjectComponent, object>>> CreateComponentAsync([Body] ProjectComponent content);

        /// <summary>
        /// Get component
        /// </summary>
        /// <param name="id">The ID of the component.</param>
        [Get("/rest/api/3/component/{id}")]
        Task<Response<AnyOf<ProjectComponent, object>>> GetComponentAsync([Path] string id);

        /// <summary>
        /// Update component
        /// </summary>
        /// <param name="id">The ID of the component.</param>
        /// <param name="content">Details about a project component.</param>
        [Put("/rest/api/3/component/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ProjectComponent, object>>> UpdateComponentAsync([Path] string id, [Body] ProjectComponent content);

        /// <summary>
        /// Delete component
        /// </summary>
        /// <param name="id">The ID of the component.</param>
        /// <param name="moveIssuesTo">The ID of the component to replace the deleted component. If this value is null no replacement is made.</param>
        [Delete("/rest/api/3/component/{id}")]
        Task<object> DeleteComponentAsync([Path] string id, [Query] string moveIssuesTo);

        /// <summary>
        /// Get component issues count
        /// </summary>
        /// <param name="id">The ID of the component.</param>
        [Get("/rest/api/3/component/{id}/relatedIssueCounts")]
        Task<Response<AnyOf<ComponentIssuesCount, object>>> GetComponentRelatedIssuesAsync([Path] string id);

        /// <summary>
        /// Get global settings
        /// </summary>
        [Get("/rest/api/3/configuration")]
        Task<Response<AnyOf<Configuration, object>>> GetConfigurationAsync();

        /// <summary>
        /// Get selected time tracking provider
        /// </summary>
        [Get("/rest/api/3/configuration/timetracking")]
        Task<Response<AnyOf<TimeTrackingProvider, GetSelectedTimeTrackingImplementationResult, object>>> GetSelectedTimeTrackingImplementationAsync();

        /// <summary>
        /// Select time tracking provider
        /// </summary>
        /// <param name="content">Details about the time tracking provider.</param>
        [Put("/rest/api/3/configuration/timetracking")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SelectTimeTrackingImplementationResult, object>>> SelectTimeTrackingImplementationAsync([Body] TimeTrackingProvider content);

        /// <summary>
        /// Get all time tracking providers
        /// </summary>
        [Get("/rest/api/3/configuration/timetracking/list")]
        Task<Response<AnyOf<TimeTrackingProvider[], object>>> GetAvailableTimeTrackingImplementationsAsync();

        /// <summary>
        /// Get time tracking settings
        /// </summary>
        [Get("/rest/api/3/configuration/timetracking/options")]
        Task<Response<AnyOf<TimeTrackingConfiguration, object>>> GetSharedTimeTrackingConfigurationAsync();

        /// <summary>
        /// Set time tracking settings
        /// </summary>
        /// <param name="content">Details of the time tracking configuration.</param>
        [Put("/rest/api/3/configuration/timetracking/options")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<TimeTrackingConfiguration, object>>> SetSharedTimeTrackingConfigurationAsync([Body] TimeTrackingConfiguration content);

        /// <summary>
        /// Get custom field option
        /// </summary>
        /// <param name="id">The ID of the custom field option.</param>
        [Get("/rest/api/3/customFieldOption/{id}")]
        Task<Response<AnyOf<CustomFieldOption, object>>> GetCustomFieldOptionAsync([Path] string id);

        /// <summary>
        /// Get all dashboards
        /// </summary>
        /// <param name="filter">The filter applied to the list of dashboards. Valid values are: *  `favourite` Returns dashboards the user has marked as favorite. *  `my` Returns dashboards owned by the user.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/dashboard")]
        Task<Response<AnyOf<PageOfDashboards, ErrorCollection>>> GetAllDashboardsAsync([Query] string filter, [Query] int? startAt, [Query] int? maxResults);

        /// <summary>
        /// Create dashboard
        /// </summary>
        /// <param name="content">Details of a dashboard.</param>
        [Post("/rest/api/3/dashboard")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Dashboard, ErrorCollection>>> CreateDashboardAsync([Body] DashboardDetails content);

        /// <summary>
        /// Search for dashboards
        /// </summary>
        /// <param name="dashboardName">String used to perform a case-insensitive partial match with `name`.</param>
        /// <param name="accountId">User account ID used to return dashboards with the matching `owner.accountId`. This parameter cannot be used with the `owner` parameter.</param>
        /// <param name="owner">This parameter is deprecated because of privacy changes. Use `accountId` instead. See the [migration guide](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details. User name used to return dashboards with the matching `owner.name`. This parameter cannot be used with the `accountId` parameter.</param>
        /// <param name="groupname">Group name used to returns dashboards that are shared with a group that matches `sharePermissions.group.name`.</param>
        /// <param name="projectId">Project ID used to returns dashboards that are shared with a project that matches `sharePermissions.project.id`.</param>
        /// <param name="orderBy">[Order](#ordering) the results by a field: *  `description` Sorts by dashboard description. Note that this sort works independently of whether the expand to display the description field is in use. *  `favourite_count` Sorts by dashboard popularity. *  `id` Sorts by dashboard ID. *  `is_favourite` Sorts by whether the dashboard is marked as a favorite. *  `name` Sorts by dashboard name. *  `owner` Sorts by dashboard owner name.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about dashboard in the response. This parameter accepts a comma-separated list. Expand options include: *  `description` Returns the description of the dashboard. *  `owner` Returns the owner of the dashboard. *  `viewUrl` Returns the URL that is used to view the dashboard. *  `favourite` Returns `isFavourite`, an indicator of whether the user has set the dashboard as a favorite. *  `favouritedCount` Returns `popularity`, a count of how many users have set this dashboard as a favorite. *  `sharePermissions` Returns details of the share permissions defined for the dashboard. *  `editPermissions` Returns details of the edit permissions defined for the dashboard. *  `isWritable` Returns whether the current user has permission to edit the dashboard.</param>
        [Get("/rest/api/3/dashboard/search")]
        Task<Response<AnyOf<PageBeanDashboard, ErrorCollection>>> GetDashboardsPaginatedAsync([Query] string dashboardName, [Query] string accountId, [Query] string owner, [Query] string groupname, [Query] long? projectId, [Query] string orderBy, [Query] long? startAt, [Query] int? maxResults, [Query] string expand);

        /// <summary>
        /// Get dashboard item property keys
        /// </summary>
        /// <param name="dashboardId">The ID of the dashboard.</param>
        /// <param name="itemId">The ID of the dashboard item.</param>
        [Get("/rest/api/3/dashboard/{dashboardId}/items/{itemId}/properties")]
        Task<Response<AnyOf<PropertyKeys, object>>> GetDashboardItemPropertyKeysAsync([Path] string dashboardId, [Path] string itemId);

        /// <summary>
        /// Get dashboard item property
        /// </summary>
        /// <param name="dashboardId">The ID of the dashboard.</param>
        /// <param name="itemId">The ID of the dashboard item.</param>
        /// <param name="propertyKey">The key of the dashboard item property.</param>
        [Get("/rest/api/3/dashboard/{dashboardId}/items/{itemId}/properties/{propertyKey}")]
        Task<Response<AnyOf<EntityProperty, object>>> GetDashboardItemPropertyAsync([Path] string dashboardId, [Path] string itemId, [Path] string propertyKey);

        /// <summary>
        /// Set dashboard item property
        /// </summary>
        /// <param name="dashboardId">The ID of the dashboard.</param>
        /// <param name="itemId">The ID of the dashboard item.</param>
        /// <param name="propertyKey">The key of the dashboard item property. The maximum length is 255 characters.</param>
        [Put("/rest/api/3/dashboard/{dashboardId}/items/{itemId}/properties/{propertyKey}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SetDashboardItemPropertyResult, object>>> SetDashboardItemPropertyAsync([Path] string dashboardId, [Path] string itemId, [Path] string propertyKey);

        /// <summary>
        /// Delete dashboard item property
        /// </summary>
        /// <param name="dashboardId">The ID of the dashboard.</param>
        /// <param name="itemId">The ID of the dashboard item.</param>
        /// <param name="propertyKey">The key of the dashboard item property.</param>
        [Delete("/rest/api/3/dashboard/{dashboardId}/items/{itemId}/properties/{propertyKey}")]
        Task<object> DeleteDashboardItemPropertyAsync([Path] string dashboardId, [Path] string itemId, [Path] string propertyKey);

        /// <summary>
        /// Get dashboard
        /// </summary>
        /// <param name="id">The ID of the dashboard.</param>
        [Get("/rest/api/3/dashboard/{id}")]
        Task<Response<AnyOf<Dashboard, ErrorCollection, object>>> GetDashboardAsync([Path] string id);

        /// <summary>
        /// Update dashboard
        /// </summary>
        /// <param name="id">The ID of the dashboard to update.</param>
        /// <param name="content">Details of a dashboard.</param>
        [Put("/rest/api/3/dashboard/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Dashboard, ErrorCollection>>> UpdateDashboardAsync([Path] string id, [Body] DashboardDetails content);

        /// <summary>
        /// Delete dashboard
        /// </summary>
        /// <param name="id">The ID of the dashboard.</param>
        [Delete("/rest/api/3/dashboard/{id}")]
        Task<Response<AnyOf<object, ErrorCollection>>> DeleteDashboardAsync([Path] string id);

        /// <summary>
        /// Copy dashboard
        /// </summary>
        /// <param name="id"></param>
        /// <param name="content">Details of a dashboard.</param>
        [Post("/rest/api/3/dashboard/{id}/copy")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Dashboard, ErrorCollection>>> CopyDashboardAsync([Path] string id, [Body] DashboardDetails content);

        /// <summary>
        /// Get events
        /// </summary>
        [Get("/rest/api/3/events")]
        Task<Response<AnyOf<IssueEvent[], object>>> GetEventsAsync();

        /// <summary>
        /// Analyse Jira expression
        /// </summary>
        /// <param name="content">Details of Jira expressions for analysis.</param>
        /// <param name="check">The check to perform: *  `syntax` Each expression's syntax is checked to ensure the expression can be parsed. Also, syntactic limits are validated. For example, the expression's length. *  `type` EXPERIMENTAL. Each expression is type checked and the final type of the expression inferred. Any type errors that would result in the expression failure at runtime are reported. For example, accessing properties that don't exist or passing the wrong number of arguments to functions. Also performs the syntax check. *  `complexity` EXPERIMENTAL. Determines the formulae for how many [expensive operations](https://developer.atlassian.com/cloud/jira/platform/jira-expressions/#expensive-operations) each expression may execute.</param>
        [Post("/rest/api/3/expression/analyse")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<JiraExpressionsAnalysis, ErrorCollection, object>>> AnalyseExpressionAsync([Body] JiraExpressionForAnalysis content, [Query] string check);

        /// <summary>
        /// Evaluate Jira expression
        /// </summary>
        /// <param name="content">The Jira expression and the evaluation context.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information in the response. This parameter accepts `meta.complexity` that returns information about the expression complexity. For example, the number of expensive operations used by the expression and how close the expression is to reaching the [complexity limit](https://developer.atlassian.com/cloud/jira/platform/jira-expressions/#restrictions). Useful when designing and debugging your expressions.</param>
        [Post("/rest/api/3/expression/eval")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<JiraExpressionResult, ErrorCollection, object>>> EvaluateJiraExpressionAsync([Body] JiraExpressionEvalRequestBean content, [Query] string expand);

        /// <summary>
        /// Get fields
        /// </summary>
        [Get("/rest/api/3/field")]
        Task<Response<AnyOf<FieldDetails[], object>>> GetFieldsAsync();

        /// <summary>
        /// Create custom field
        /// </summary>
        /// <param name="content">Definition of the custom field to be created</param>
        [Post("/rest/api/3/field")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<FieldDetails, object>>> CreateCustomFieldAsync([Body] CustomFieldDefinitionJsonBean content);

        /// <summary>
        /// Get fields paginated
        /// </summary>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="type">The type of fields to search.</param>
        /// <param name="id">The IDs of the custom fields to return or, where `query` is specified, filter.</param>
        /// <param name="query">String used to perform a case-insensitive partial match with field names or descriptions.</param>
        /// <param name="orderBy">[Order](#ordering) the results by a field: *  `contextsCount` Sorts by the number of contexts related to a field. *  `lastUsed` Sorts by the date when the value of the field last changed. *  `name` Sorts by the field name. *  `screensCount` Sorts by the number of screens related to a field.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information in the response. This parameter accepts a comma-separated list. Expand options include: *  `key` Returns the key for each field. *  `lastUsed` Returns the date when the value of the field last changed. *  `screensCount` Returns the number of screens related to a field. *  `contextsCount` Returns the number of contexts related to a field. *  `isLocked` Returns information about whether the field is [locked](https://confluence.atlassian.com/x/ZSN7Og). *  `searcherKey` Returns the searcher key for each custom field.</param>
        [Get("/rest/api/3/field/search")]
        Task<Response<AnyOf<PageBeanField, ErrorCollection, object>>> GetFieldsPaginatedAsync([Query] long? startAt, [Query] int? maxResults, [Query] string[] type, [Query] string[] id, [Query] string query, [Query] string orderBy, [Query] string expand);

        /// <summary>
        /// Update custom field
        /// </summary>
        /// <param name="fieldId">The ID of the custom field.</param>
        /// <param name="content">Details of a custom field.</param>
        [Put("/rest/api/3/field/{fieldId}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<UpdateCustomFieldResult, object>>> UpdateCustomFieldAsync([Path] string fieldId, [Body] UpdateCustomFieldDetails content);

        /// <summary>
        /// Get custom field contexts
        /// </summary>
        /// <param name="fieldId">The ID of the custom field.</param>
        /// <param name="isAnyIssueType">Whether to return contexts that apply to all issue types.</param>
        /// <param name="isGlobalContext">Whether to return contexts that apply to all projects.</param>
        /// <param name="contextId">The list of context IDs. To include multiple contexts, separate IDs with ampersand: `contextId=10000&contextId=10001`.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/field/{fieldId}/context")]
        Task<Response<AnyOf<PageBeanCustomFieldContext, object>>> GetContextsForFieldAsync([Path] string fieldId, [Query] bool? isAnyIssueType, [Query] bool? isGlobalContext, [Query] long[] contextId, [Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Create custom field context
        /// </summary>
        /// <param name="fieldId">The ID of the custom field.</param>
        /// <param name="content">The details of a created custom field context.</param>
        [Post("/rest/api/3/field/{fieldId}/context")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<CreateCustomFieldContext, object>>> CreateCustomFieldContextAsync([Path] string fieldId, [Body] CreateCustomFieldContext content);

        /// <summary>
        /// Get custom field contexts default values
        /// </summary>
        /// <param name="fieldId">The ID of the custom field, for example `customfield\_10000`.</param>
        /// <param name="contextId">The IDs of the contexts.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/field/{fieldId}/context/defaultValue")]
        Task<Response<AnyOf<PageBeanCustomFieldContextDefaultValue, object>>> GetDefaultValuesAsync([Path] string fieldId, [Query] long[] contextId, [Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Set custom field contexts default values
        /// </summary>
        /// <param name="fieldId">The ID of the custom field.</param>
        /// <param name="content">Default values to update.</param>
        [Put("/rest/api/3/field/{fieldId}/context/defaultValue")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SetDefaultValuesResult, object>>> SetDefaultValuesAsync([Path] string fieldId, [Body] CustomFieldContextDefaultValueUpdate content);

        /// <summary>
        /// Get issue types for custom field context
        /// </summary>
        /// <param name="fieldId">The ID of the custom field.</param>
        /// <param name="contextId">The ID of the context. To include multiple contexts, provide an ampersand-separated list. For example, `contextId=10001&contextId=10002`.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/field/{fieldId}/context/issuetypemapping")]
        Task<Response<AnyOf<PageBeanIssueTypeToContextMapping, object>>> GetIssueTypeMappingsForContextsAsync([Path] string fieldId, [Query] long[] contextId, [Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Get custom field contexts for projects and issue types
        /// </summary>
        /// <param name="fieldId">The ID of the custom field.</param>
        /// <param name="content">The project and issue type mappings.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Post("/rest/api/3/field/{fieldId}/context/mapping")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PageBeanContextForProjectAndIssueType, object>>> GetCustomFieldContextsForProjectsAndIssueTypesAsync([Path] string fieldId, [Body] ProjectIssueTypeMappings content, [Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Get project mappings for custom field context
        /// </summary>
        /// <param name="fieldId">The ID of the custom field, for example `customfield\_10000`.</param>
        /// <param name="contextId">The list of context IDs. To include multiple context, separate IDs with ampersand: `contextId=10000&contextId=10001`.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/field/{fieldId}/context/projectmapping")]
        Task<Response<AnyOf<PageBeanCustomFieldContextProjectMapping, object>>> GetProjectContextMappingAsync([Path] string fieldId, [Query] long[] contextId, [Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Update custom field context
        /// </summary>
        /// <param name="fieldId">The ID of the custom field.</param>
        /// <param name="contextId">The ID of the context.</param>
        /// <param name="content">Details of a custom field context.</param>
        [Put("/rest/api/3/field/{fieldId}/context/{contextId}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<UpdateCustomFieldContextResult, object>>> UpdateCustomFieldContextAsync([Path] string fieldId, [Path] long contextId, [Body] CustomFieldContextUpdateDetails content);

        /// <summary>
        /// Delete custom field context
        /// </summary>
        /// <param name="fieldId">The ID of the custom field.</param>
        /// <param name="contextId">The ID of the context.</param>
        [Delete("/rest/api/3/field/{fieldId}/context/{contextId}")]
        Task<Response<AnyOf<DeleteCustomFieldContextResult, object>>> DeleteCustomFieldContextAsync([Path] string fieldId, [Path] long contextId);

        /// <summary>
        /// Add issue types to context
        /// </summary>
        /// <param name="fieldId">The ID of the custom field.</param>
        /// <param name="contextId">The ID of the context.</param>
        /// <param name="content">The list of issue type IDs.</param>
        [Put("/rest/api/3/field/{fieldId}/context/{contextId}/issuetype")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<AddIssueTypesToContextResult, object>>> AddIssueTypesToContextAsync([Path] string fieldId, [Path] long contextId, [Body] IssueTypeIds content);

        /// <summary>
        /// Remove issue types from context
        /// </summary>
        /// <param name="fieldId">The ID of the custom field.</param>
        /// <param name="contextId">The ID of the context.</param>
        /// <param name="content">The list of issue type IDs.</param>
        [Post("/rest/api/3/field/{fieldId}/context/{contextId}/issuetype/remove")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<RemoveIssueTypesFromContextResult, object>>> RemoveIssueTypesFromContextAsync([Path] string fieldId, [Path] long contextId, [Body] IssueTypeIds content);

        /// <summary>
        /// Get custom field options (context)
        /// </summary>
        /// <param name="fieldId">The ID of the custom field.</param>
        /// <param name="contextId">The ID of the context.</param>
        /// <param name="optionId">The ID of the option.</param>
        /// <param name="onlyOptions">Whether only options are returned.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/field/{fieldId}/context/{contextId}/option")]
        Task<Response<AnyOf<PageBeanCustomFieldContextOption, object>>> GetOptionsForContextAsync([Path] string fieldId, [Path] long contextId, [Query] long? optionId, [Query] bool? onlyOptions, [Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Update custom field options (context)
        /// </summary>
        /// <param name="fieldId">The ID of the custom field.</param>
        /// <param name="contextId">The ID of the context.</param>
        /// <param name="content">Details of the options to update for a custom field.</param>
        [Put("/rest/api/3/field/{fieldId}/context/{contextId}/option")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<CustomFieldUpdatedContextOptionsList, object>>> UpdateCustomFieldOptionAsync([Path] string fieldId, [Path] long contextId, [Body] BulkCustomFieldOptionUpdateRequest content);

        /// <summary>
        /// Create custom field options (context)
        /// </summary>
        /// <param name="fieldId">The ID of the custom field.</param>
        /// <param name="contextId">The ID of the context.</param>
        /// <param name="content">Details of the options to create for a custom field.</param>
        [Post("/rest/api/3/field/{fieldId}/context/{contextId}/option")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<CustomFieldCreatedContextOptionsList, object>>> CreateCustomFieldOptionAsync([Path] string fieldId, [Path] long contextId, [Body] BulkCustomFieldOptionCreateRequest content);

        /// <summary>
        /// Reorder custom field options (context)
        /// </summary>
        /// <param name="fieldId">The ID of the custom field.</param>
        /// <param name="contextId">The ID of the context.</param>
        /// <param name="content">An ordered list of custom field option IDs and information on where to move them.</param>
        [Put("/rest/api/3/field/{fieldId}/context/{contextId}/option/move")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ReorderCustomFieldOptionsResult, object>>> ReorderCustomFieldOptionsAsync([Path] string fieldId, [Path] long contextId, [Body] OrderOfCustomFieldOptions content);

        /// <summary>
        /// Delete custom field options (context)
        /// </summary>
        /// <param name="fieldId">The ID of the custom field.</param>
        /// <param name="contextId">The ID of the context from which an option should be deleted.</param>
        /// <param name="optionId">The ID of the option to delete.</param>
        [Delete("/rest/api/3/field/{fieldId}/context/{contextId}/option/{optionId}")]
        Task<object> DeleteCustomFieldOptionAsync([Path] string fieldId, [Path] long contextId, [Path] long optionId);

        /// <summary>
        /// Assign custom field context to projects
        /// </summary>
        /// <param name="fieldId">The ID of the custom field.</param>
        /// <param name="contextId">The ID of the context.</param>
        /// <param name="content">A list of project IDs.</param>
        [Put("/rest/api/3/field/{fieldId}/context/{contextId}/project")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<AssignProjectsToCustomFieldContextResult, object>>> AssignProjectsToCustomFieldContextAsync([Path] string fieldId, [Path] long contextId, [Body] ProjectIds content);

        /// <summary>
        /// Remove custom field context from projects
        /// </summary>
        /// <param name="fieldId">The ID of the custom field.</param>
        /// <param name="contextId">The ID of the context.</param>
        /// <param name="content">A list of project IDs.</param>
        [Post("/rest/api/3/field/{fieldId}/context/{contextId}/project/remove")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<RemoveCustomFieldContextFromProjectsResult, object>>> RemoveCustomFieldContextFromProjectsAsync([Path] string fieldId, [Path] long contextId, [Body] ProjectIds content);

        /// <summary>
        /// Get contexts for a field
        /// </summary>
        /// <param name="fieldId">The ID of the field to return contexts for.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/field/{fieldId}/contexts")]
        Task<Response<AnyOf<PageBeanContext, object>>> GetContextsForFieldDeprecatedAsync([Path] string fieldId, [Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Get screens for a field
        /// </summary>
        /// <param name="fieldId">The ID of the field to return screens for.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about screens in the response. This parameter accepts `tab` which returns details about the screen tabs the field is used in.</param>
        [Get("/rest/api/3/field/{fieldId}/screens")]
        Task<Response<AnyOf<PageBeanScreenWithTab, object>>> GetScreensForFieldAsync([Path] string fieldId, [Query] long? startAt, [Query] int? maxResults, [Query] string expand);

        /// <summary>
        /// Get all issue field options
        /// </summary>
        /// <param name="fieldKey">The field key is specified in the following format: **$(app-key)\_\_$(field-key)**. For example, *example-add-on\_\_example-issue-field*. To determine the `fieldKey` value, do one of the following: *  open the app's plugin descriptor, then **app-key** is the key at the top and **field-key** is the key in the `jiraIssueFields` module. **app-key** can also be found in the app listing in the Atlassian Universal Plugin Manager. *  run [Get fields](#api-rest-api-3-field-get) and in the field details the value is returned in `key`. For example, `"key": "teams-add-on__team-issue-field"`</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/field/{fieldKey}/option")]
        Task<Response<AnyOf<PageBeanIssueFieldOption, object>>> GetAllIssueFieldOptionsAsync([Path] string fieldKey, [Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Create issue field option
        /// </summary>
        /// <param name="fieldKey">The field key is specified in the following format: **$(app-key)\_\_$(field-key)**. For example, *example-add-on\_\_example-issue-field*. To determine the `fieldKey` value, do one of the following: *  open the app's plugin descriptor, then **app-key** is the key at the top and **field-key** is the key in the `jiraIssueFields` module. **app-key** can also be found in the app listing in the Atlassian Universal Plugin Manager. *  run [Get fields](#api-rest-api-3-field-get) and in the field details the value is returned in `key`. For example, `"key": "teams-add-on__team-issue-field"`</param>
        /// <param name="content"></param>
        [Post("/rest/api/3/field/{fieldKey}/option")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<IssueFieldOption, object>>> CreateIssueFieldOptionAsync([Path] string fieldKey, [Body] IssueFieldOptionCreateBean content);

        /// <summary>
        /// Get selectable issue field options
        /// </summary>
        /// <param name="fieldKey">The field key is specified in the following format: **$(app-key)\_\_$(field-key)**. For example, *example-add-on\_\_example-issue-field*. To determine the `fieldKey` value, do one of the following: *  open the app's plugin descriptor, then **app-key** is the key at the top and **field-key** is the key in the `jiraIssueFields` module. **app-key** can also be found in the app listing in the Atlassian Universal Plugin Manager. *  run [Get fields](#api-rest-api-3-field-get) and in the field details the value is returned in `key`. For example, `"key": "teams-add-on__team-issue-field"`</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="projectId">Filters the results to options that are only available in the specified project.</param>
        [Get("/rest/api/3/field/{fieldKey}/option/suggestions/edit")]
        Task<Response<AnyOf<PageBeanIssueFieldOption, object>>> GetSelectableIssueFieldOptionsAsync([Path] string fieldKey, [Query] long? startAt, [Query] int? maxResults, [Query] long? projectId);

        /// <summary>
        /// Get visible issue field options
        /// </summary>
        /// <param name="fieldKey">The field key is specified in the following format: **$(app-key)\_\_$(field-key)**. For example, *example-add-on\_\_example-issue-field*. To determine the `fieldKey` value, do one of the following: *  open the app's plugin descriptor, then **app-key** is the key at the top and **field-key** is the key in the `jiraIssueFields` module. **app-key** can also be found in the app listing in the Atlassian Universal Plugin Manager. *  run [Get fields](#api-rest-api-3-field-get) and in the field details the value is returned in `key`. For example, `"key": "teams-add-on__team-issue-field"`</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="projectId">Filters the results to options that are only available in the specified project.</param>
        [Get("/rest/api/3/field/{fieldKey}/option/suggestions/search")]
        Task<Response<AnyOf<PageBeanIssueFieldOption, object>>> GetVisibleIssueFieldOptionsAsync([Path] string fieldKey, [Query] long? startAt, [Query] int? maxResults, [Query] long? projectId);

        /// <summary>
        /// Get issue field option
        /// </summary>
        /// <param name="fieldKey">The field key is specified in the following format: **$(app-key)\_\_$(field-key)**. For example, *example-add-on\_\_example-issue-field*. To determine the `fieldKey` value, do one of the following: *  open the app's plugin descriptor, then **app-key** is the key at the top and **field-key** is the key in the `jiraIssueFields` module. **app-key** can also be found in the app listing in the Atlassian Universal Plugin Manager. *  run [Get fields](#api-rest-api-3-field-get) and in the field details the value is returned in `key`. For example, `"key": "teams-add-on__team-issue-field"`</param>
        /// <param name="optionId">The ID of the option to be returned.</param>
        [Get("/rest/api/3/field/{fieldKey}/option/{optionId}")]
        Task<Response<AnyOf<IssueFieldOption, object>>> GetIssueFieldOptionAsync([Path] string fieldKey, [Path] long optionId);

        /// <summary>
        /// Update issue field option
        /// </summary>
        /// <param name="fieldKey">The field key is specified in the following format: **$(app-key)\_\_$(field-key)**. For example, *example-add-on\_\_example-issue-field*. To determine the `fieldKey` value, do one of the following: *  open the app's plugin descriptor, then **app-key** is the key at the top and **field-key** is the key in the `jiraIssueFields` module. **app-key** can also be found in the app listing in the Atlassian Universal Plugin Manager. *  run [Get fields](#api-rest-api-3-field-get) and in the field details the value is returned in `key`. For example, `"key": "teams-add-on__team-issue-field"`</param>
        /// <param name="optionId">The ID of the option to be updated.</param>
        /// <param name="content">Details of the options for a select list issue field.</param>
        [Put("/rest/api/3/field/{fieldKey}/option/{optionId}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<IssueFieldOption, object>>> UpdateIssueFieldOptionAsync([Path] string fieldKey, [Path] long optionId, [Body] IssueFieldOption content);

        /// <summary>
        /// Delete issue field option
        /// </summary>
        /// <param name="fieldKey">The field key is specified in the following format: **$(app-key)\_\_$(field-key)**. For example, *example-add-on\_\_example-issue-field*. To determine the `fieldKey` value, do one of the following: *  open the app's plugin descriptor, then **app-key** is the key at the top and **field-key** is the key in the `jiraIssueFields` module. **app-key** can also be found in the app listing in the Atlassian Universal Plugin Manager. *  run [Get fields](#api-rest-api-3-field-get) and in the field details the value is returned in `key`. For example, `"key": "teams-add-on__team-issue-field"`</param>
        /// <param name="optionId">The ID of the option to be deleted.</param>
        [Delete("/rest/api/3/field/{fieldKey}/option/{optionId}")]
        Task<Response<AnyOf<DeleteIssueFieldOptionResult, object>>> DeleteIssueFieldOptionAsync([Path] string fieldKey, [Path] long optionId);

        /// <summary>
        /// Replace issue field option
        /// </summary>
        /// <param name="fieldKey">The field key is specified in the following format: **$(app-key)\_\_$(field-key)**. For example, *example-add-on\_\_example-issue-field*. To determine the `fieldKey` value, do one of the following: *  open the app's plugin descriptor, then **app-key** is the key at the top and **field-key** is the key in the `jiraIssueFields` module. **app-key** can also be found in the app listing in the Atlassian Universal Plugin Manager. *  run [Get fields](#api-rest-api-3-field-get) and in the field details the value is returned in `key`. For example, `"key": "teams-add-on__team-issue-field"`</param>
        /// <param name="optionId">The ID of the option to be deselected.</param>
        /// <param name="replaceWith">The ID of the option that will replace the currently selected option.</param>
        /// <param name="jql">A JQL query that specifies the issues to be updated. For example, *project=10000*.</param>
        /// <param name="overrideScreenSecurity">Whether screen security is overridden to enable hidden fields to be edited. Available to Connect app users with admin permission and Forge app users with the `manage:jira-configuration` scope.</param>
        /// <param name="overrideEditableFlag">Whether screen security is overridden to enable uneditable fields to be edited. Available to Connect app users with admin permission and Forge app users with the `manage:jira-configuration` scope.</param>
        [Delete("/rest/api/3/field/{fieldKey}/option/{optionId}/issue")]
        Task<Response<AnyOf<TaskProgressBeanRemoveOptionFromIssuesResult, object>>> ReplaceIssueFieldOptionAsync([Path] string fieldKey, [Path] long optionId, [Query] long? replaceWith, [Query] string jql, [Query] bool? overrideScreenSecurity, [Query] bool? overrideEditableFlag);

        /// <summary>
        /// Delete custom field
        /// </summary>
        /// <param name="id">The ID of a custom field.</param>
        [Delete("/rest/api/3/field/{id}")]
        Task<Response<AnyOf<DeleteCustomFieldResult, ErrorCollection>>> DeleteCustomFieldAsync([Path] string id);

        /// <summary>
        /// Restore custom field from trash
        /// </summary>
        /// <param name="id">The ID of a custom field.</param>
        [Post("/rest/api/3/field/{id}/restore")]
        Task<Response<AnyOf<RestoreCustomFieldResult, ErrorCollection>>> RestoreCustomFieldAsync([Path] string id);

        /// <summary>
        /// Move custom field to trash
        /// </summary>
        /// <param name="id">The ID of a custom field.</param>
        [Post("/rest/api/3/field/{id}/trash")]
        Task<Response<AnyOf<TrashCustomFieldResult, ErrorCollection>>> TrashCustomFieldAsync([Path] string id);

        /// <summary>
        /// Get all field configurations
        /// </summary>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="id">The list of field configuration IDs. To include multiple IDs, provide an ampersand-separated list. For example, `id=10000&id=10001`.</param>
        /// <param name="isDefault">If *true* returns default field configurations only.</param>
        /// <param name="query">The query string used to match against field configuration names and descriptions.</param>
        [Get("/rest/api/3/fieldconfiguration")]
        Task<Response<AnyOf<PageBeanFieldConfigurationDetails, object>>> GetAllFieldConfigurationsAsync([Query] long? startAt, [Query] int? maxResults, [Query] long[] id, [Query] bool? isDefault, [Query] string query);

        /// <summary>
        /// Create field configuration
        /// </summary>
        /// <param name="content">Details of a field configuration.</param>
        [Post("/rest/api/3/fieldconfiguration")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<FieldConfiguration, object>>> CreateFieldConfigurationAsync([Body] FieldConfigurationDetails content);

        /// <summary>
        /// Update field configuration
        /// </summary>
        /// <param name="id">The ID of the field configuration.</param>
        /// <param name="content">Details of a field configuration.</param>
        [Put("/rest/api/3/fieldconfiguration/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<UpdateFieldConfigurationResult, object>>> UpdateFieldConfigurationAsync([Path] long id, [Body] FieldConfigurationDetails content);

        /// <summary>
        /// Delete field configuration
        /// </summary>
        /// <param name="id">The ID of the field configuration.</param>
        [Delete("/rest/api/3/fieldconfiguration/{id}")]
        Task<Response<AnyOf<DeleteFieldConfigurationResult, object>>> DeleteFieldConfigurationAsync([Path] long id);

        /// <summary>
        /// Get field configuration items
        /// </summary>
        /// <param name="id">The ID of the field configuration.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/fieldconfiguration/{id}/fields")]
        Task<Response<AnyOf<PageBeanFieldConfigurationItem, object>>> GetFieldConfigurationItemsAsync([Path] long id, [Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Update field configuration items
        /// </summary>
        /// <param name="id">The ID of the field configuration.</param>
        /// <param name="content">Details of field configuration items.</param>
        [Put("/rest/api/3/fieldconfiguration/{id}/fields")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<UpdateFieldConfigurationItemsResult, object>>> UpdateFieldConfigurationItemsAsync([Path] long id, [Body] FieldConfigurationItemsDetails content);

        /// <summary>
        /// Get all field configuration schemes
        /// </summary>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="id">The list of field configuration scheme IDs. To include multiple IDs, provide an ampersand-separated list. For example, `id=10000&id=10001`.</param>
        [Get("/rest/api/3/fieldconfigurationscheme")]
        Task<Response<AnyOf<PageBeanFieldConfigurationScheme, object>>> GetAllFieldConfigurationSchemesAsync([Query] long? startAt, [Query] int? maxResults, [Query] long[] id);

        /// <summary>
        /// Create field configuration scheme
        /// </summary>
        /// <param name="content">The details of the field configuration scheme.</param>
        [Post("/rest/api/3/fieldconfigurationscheme")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<FieldConfigurationScheme, object>>> CreateFieldConfigurationSchemeAsync([Body] UpdateFieldConfigurationSchemeDetails content);

        /// <summary>
        /// Get field configuration issue type items
        /// </summary>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="fieldConfigurationSchemeId">The list of field configuration scheme IDs. To include multiple field configuration schemes separate IDs with ampersand: `fieldConfigurationSchemeId=10000&fieldConfigurationSchemeId=10001`.</param>
        [Get("/rest/api/3/fieldconfigurationscheme/mapping")]
        Task<Response<AnyOf<PageBeanFieldConfigurationIssueTypeItem, object>>> GetFieldConfigurationSchemeMappingsAsync([Query] long? startAt, [Query] int? maxResults, [Query] long[] fieldConfigurationSchemeId);

        /// <summary>
        /// Get field configuration schemes for projects
        /// </summary>
        /// <param name="projectId">The list of project IDs. To include multiple projects, separate IDs with ampersand: `projectId=10000&projectId=10001`.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/fieldconfigurationscheme/project")]
        Task<Response<AnyOf<PageBeanFieldConfigurationSchemeProjects, object>>> GetFieldConfigurationSchemeProjectMappingAsync([Query] long[] projectId, [Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Assign field configuration scheme to project
        /// </summary>
        /// <param name="content">Associated field configuration scheme and project.</param>
        [Put("/rest/api/3/fieldconfigurationscheme/project")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<AssignFieldConfigurationSchemeToProjectResult, object>>> AssignFieldConfigurationSchemeToProjectAsync([Body] FieldConfigurationSchemeProjectAssociation content);

        /// <summary>
        /// Update field configuration scheme
        /// </summary>
        /// <param name="id">The ID of the field configuration scheme.</param>
        /// <param name="content">The details of the field configuration scheme.</param>
        [Put("/rest/api/3/fieldconfigurationscheme/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<UpdateFieldConfigurationSchemeResult, object>>> UpdateFieldConfigurationSchemeAsync([Path] long id, [Body] UpdateFieldConfigurationSchemeDetails content);

        /// <summary>
        /// Delete field configuration scheme
        /// </summary>
        /// <param name="id">The ID of the field configuration scheme.</param>
        [Delete("/rest/api/3/fieldconfigurationscheme/{id}")]
        Task<Response<AnyOf<DeleteFieldConfigurationSchemeResult, object>>> DeleteFieldConfigurationSchemeAsync([Path] long id);

        /// <summary>
        /// Assign issue types to field configurations
        /// </summary>
        /// <param name="id">The ID of the field configuration scheme.</param>
        /// <param name="content">Details of a field configuration to issue type mappings.</param>
        [Put("/rest/api/3/fieldconfigurationscheme/{id}/mapping")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SetFieldConfigurationSchemeMappingResult, object>>> SetFieldConfigurationSchemeMappingAsync([Path] long id, [Body] AssociateFieldConfigurationsWithIssueTypesRequest content);

        /// <summary>
        /// Remove issue types from field configuration scheme
        /// </summary>
        /// <param name="id">The ID of the field configuration scheme.</param>
        /// <param name="content">The list of issue type IDs to be removed from the field configuration scheme.</param>
        [Post("/rest/api/3/fieldconfigurationscheme/{id}/mapping/delete")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<RemoveIssueTypesFromGlobalFieldConfigurationSchemeResult, ErrorCollection>>> RemoveIssueTypesFromGlobalFieldConfigurationSchemeAsync([Path] long id, [Body] IssueTypeIdsToRemove content);

        /// <summary>
        /// Get filters
        /// </summary>
        /// <param name="expand">Use [expand](#expansion) to include additional information about filter in the response. This parameter accepts a comma-separated list. Expand options include: *  `sharedUsers` Returns the users that the filter is shared with. This includes users that can browse projects that the filter is shared with. If you don't specify `sharedUsers`, then the `sharedUsers` object is returned but it doesn't list any users. The list of users returned is limited to 1000, to access additional users append `[start-index:end-index]` to the expand request. For example, to access the next 1000 users, use `?expand=sharedUsers[1001:2000]`. *  `subscriptions` Returns the users that are subscribed to the filter. If you don't specify `subscriptions`, the `subscriptions` object is returned but it doesn't list any subscriptions. The list of subscriptions returned is limited to 1000, to access additional subscriptions append `[start-index:end-index]` to the expand request. For example, to access the next 1000 subscriptions, use `?expand=subscriptions[1001:2000]`.</param>
        [Get("/rest/api/3/filter")]
        Task<Response<AnyOf<Filter[], object>>> GetFiltersAsync([Query] string expand);

        /// <summary>
        /// Create filter
        /// </summary>
        /// <param name="content">Details about a filter.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about filter in the response. This parameter accepts a comma-separated list. Expand options include: *  `sharedUsers` Returns the users that the filter is shared with. This includes users that can browse projects that the filter is shared with. If you don't specify `sharedUsers`, then the `sharedUsers` object is returned but it doesn't list any users. The list of users returned is limited to 1000, to access additional users append `[start-index:end-index]` to the expand request. For example, to access the next 1000 users, use `?expand=sharedUsers[1001:2000]`. *  `subscriptions` Returns the users that are subscribed to the filter. If you don't specify `subscriptions`, the `subscriptions` object is returned but it doesn't list any subscriptions. The list of subscriptions returned is limited to 1000, to access additional subscriptions append `[start-index:end-index]` to the expand request. For example, to access the next 1000 subscriptions, use `?expand=subscriptions[1001:2000]`.</param>
        [Post("/rest/api/3/filter")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Filter, object>>> CreateFilterAsync([Body] Filter content, [Query] string expand);

        /// <summary>
        /// Get default share scope
        /// </summary>
        [Get("/rest/api/3/filter/defaultShareScope")]
        Task<Response<AnyOf<DefaultShareScope, object>>> GetDefaultShareScopeAsync();

        /// <summary>
        /// Set default share scope
        /// </summary>
        /// <param name="content">Details of the scope of the default sharing for new filters and dashboards.</param>
        [Put("/rest/api/3/filter/defaultShareScope")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<DefaultShareScope, object>>> SetDefaultShareScopeAsync([Body] DefaultShareScope content);

        /// <summary>
        /// Get favorite filters
        /// </summary>
        /// <param name="expand">Use [expand](#expansion) to include additional information about filter in the response. This parameter accepts a comma-separated list. Expand options include: *  `sharedUsers` Returns the users that the filter is shared with. This includes users that can browse projects that the filter is shared with. If you don't specify `sharedUsers`, then the `sharedUsers` object is returned but it doesn't list any users. The list of users returned is limited to 1000, to access additional users append `[start-index:end-index]` to the expand request. For example, to access the next 1000 users, use `?expand=sharedUsers[1001:2000]`. *  `subscriptions` Returns the users that are subscribed to the filter. If you don't specify `subscriptions`, the `subscriptions` object is returned but it doesn't list any subscriptions. The list of subscriptions returned is limited to 1000, to access additional subscriptions append `[start-index:end-index]` to the expand request. For example, to access the next 1000 subscriptions, use `?expand=subscriptions[1001:2000]`.</param>
        [Get("/rest/api/3/filter/favourite")]
        Task<Response<AnyOf<Filter[], object>>> GetFavouriteFiltersAsync([Query] string expand);

        /// <summary>
        /// Get my filters
        /// </summary>
        /// <param name="expand">Use [expand](#expansion) to include additional information about filter in the response. This parameter accepts a comma-separated list. Expand options include: *  `sharedUsers` Returns the users that the filter is shared with. This includes users that can browse projects that the filter is shared with. If you don't specify `sharedUsers`, then the `sharedUsers` object is returned but it doesn't list any users. The list of users returned is limited to 1000, to access additional users append `[start-index:end-index]` to the expand request. For example, to access the next 1000 users, use `?expand=sharedUsers[1001:2000]`. *  `subscriptions` Returns the users that are subscribed to the filter. If you don't specify `subscriptions`, the `subscriptions` object is returned but it doesn't list any subscriptions. The list of subscriptions returned is limited to 1000, to access additional subscriptions append `[start-index:end-index]` to the expand request. For example, to access the next 1000 subscriptions, use `?expand=subscriptions[1001:2000]`.</param>
        /// <param name="includeFavourites">Include the user's favorite filters in the response.</param>
        [Get("/rest/api/3/filter/my")]
        Task<Response<AnyOf<Filter[], object>>> GetMyFiltersAsync([Query] string expand, [Query] bool? includeFavourites);

        /// <summary>
        /// Search for filters
        /// </summary>
        /// <param name="filterName">String used to perform a case-insensitive partial match with `name`.</param>
        /// <param name="accountId">User account ID used to return filters with the matching `owner.accountId`. This parameter cannot be used with `owner`.</param>
        /// <param name="owner">This parameter is deprecated because of privacy changes. Use `accountId` instead. See the [migration guide](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details. User name used to return filters with the matching `owner.name`. This parameter cannot be used with `accountId`.</param>
        /// <param name="groupname">Group name used to returns filters that are shared with a group that matches `sharePermissions.group.groupname`.</param>
        /// <param name="projectId">Project ID used to returns filters that are shared with a project that matches `sharePermissions.project.id`.</param>
        /// <param name="id">The list of filter IDs. To include multiple IDs, provide an ampersand-separated list. For example, `id=10000&id=10001`.</param>
        /// <param name="orderBy">[Order](#ordering) the results by a field: *  `description` Sorts by filter description. Note that this sorting works independently of whether the expand to display the description field is in use. *  `favourite_count` Sorts by the count of how many users have this filter as a favorite. *  `is_favourite` Sorts by whether the filter is marked as a favorite. *  `id` Sorts by filter ID. *  `name` Sorts by filter name. *  `owner` Sorts by the ID of the filter owner. *  `is_shared` Sorts by whether the filter is shared.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about filter in the response. This parameter accepts a comma-separated list. Expand options include: *  `description` Returns the description of the filter. *  `favourite` Returns an indicator of whether the user has set the filter as a favorite. *  `favouritedCount` Returns a count of how many users have set this filter as a favorite. *  `jql` Returns the JQL query that the filter uses. *  `owner` Returns the owner of the filter. *  `searchUrl` Returns a URL to perform the filter's JQL query. *  `sharePermissions` Returns the share permissions defined for the filter. *  `editPermissions` Returns the edit permissions defined for the filter. *  `isWritable` Returns whether the current user has permission to edit the filter. *  `subscriptions` Returns the users that are subscribed to the filter. *  `viewUrl` Returns a URL to view the filter.</param>
        [Get("/rest/api/3/filter/search")]
        Task<Response<AnyOf<PageBeanFilterDetails, ErrorCollection, object>>> GetFiltersPaginatedAsync([Query] string filterName, [Query] string accountId, [Query] string owner, [Query] string groupname, [Query] long? projectId, [Query] long[] id, [Query] string orderBy, [Query] long? startAt, [Query] int? maxResults, [Query] string expand);

        /// <summary>
        /// Get filter
        /// </summary>
        /// <param name="id">The ID of the filter to return.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about filter in the response. This parameter accepts a comma-separated list. Expand options include: *  `sharedUsers` Returns the users that the filter is shared with. This includes users that can browse projects that the filter is shared with. If you don't specify `sharedUsers`, then the `sharedUsers` object is returned but it doesn't list any users. The list of users returned is limited to 1000, to access additional users append `[start-index:end-index]` to the expand request. For example, to access the next 1000 users, use `?expand=sharedUsers[1001:2000]`. *  `subscriptions` Returns the users that are subscribed to the filter. If you don't specify `subscriptions`, the `subscriptions` object is returned but it doesn't list any subscriptions. The list of subscriptions returned is limited to 1000, to access additional subscriptions append `[start-index:end-index]` to the expand request. For example, to access the next 1000 subscriptions, use `?expand=subscriptions[1001:2000]`.</param>
        [Get("/rest/api/3/filter/{id}")]
        Task<Response<AnyOf<Filter, object>>> GetFilterAsync([Path] long id, [Query] string expand);

        /// <summary>
        /// Update filter
        /// </summary>
        /// <param name="id">The ID of the filter to update.</param>
        /// <param name="content">Details about a filter.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about filter in the response. This parameter accepts a comma-separated list. Expand options include: *  `sharedUsers` Returns the users that the filter is shared with. This includes users that can browse projects that the filter is shared with. If you don't specify `sharedUsers`, then the `sharedUsers` object is returned but it doesn't list any users. The list of users returned is limited to 1000, to access additional users append `[start-index:end-index]` to the expand request. For example, to access the next 1000 users, use `?expand=sharedUsers[1001:2000]`. *  `subscriptions` Returns the users that are subscribed to the filter. If you don't specify `subscriptions`, the `subscriptions` object is returned but it doesn't list any subscriptions. The list of subscriptions returned is limited to 1000, to access additional subscriptions append `[start-index:end-index]` to the expand request. For example, to access the next 1000 subscriptions, use `?expand=subscriptions[1001:2000]`.</param>
        [Put("/rest/api/3/filter/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Filter, object>>> UpdateFilterAsync([Path] long id, [Body] Filter content, [Query] string expand);

        /// <summary>
        /// Delete filter
        /// </summary>
        /// <param name="id">The ID of the filter to delete.</param>
        [Delete("/rest/api/3/filter/{id}")]
        Task<object> DeleteFilterAsync([Path] long id);

        /// <summary>
        /// Get columns
        /// </summary>
        /// <param name="id">The ID of the filter.</param>
        [Get("/rest/api/3/filter/{id}/columns")]
        Task<Response<AnyOf<ColumnItem[], object>>> GetColumnsAsync([Path] long id);

        /// <summary>
        /// Set columns
        /// </summary>
        /// <param name="contentType">The Content-Type</param>
        /// <param name="id">The ID of the filter.</param>
        /// <param name="content">An extension method is generated to support the exact parameters.</param>
        [Put("/rest/api/3/filter/{id}/columns")]
        Task<Response<AnyOf<SetColumnsResult, object>>> SetColumnsAsync([Header("Content-Type")] string contentType, [Path] long id, [Body] HttpContent content);

        /// <summary>
        /// Reset columns
        /// </summary>
        /// <param name="id">The ID of the filter.</param>
        [Delete("/rest/api/3/filter/{id}/columns")]
        Task<object> ResetColumnsAsync([Path] long id);

        /// <summary>
        /// Add filter as favorite
        /// </summary>
        /// <param name="id">The ID of the filter.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about filter in the response. This parameter accepts a comma-separated list. Expand options include: *  `sharedUsers` Returns the users that the filter is shared with. This includes users that can browse projects that the filter is shared with. If you don't specify `sharedUsers`, then the `sharedUsers` object is returned but it doesn't list any users. The list of users returned is limited to 1000, to access additional users append `[start-index:end-index]` to the expand request. For example, to access the next 1000 users, use `?expand=sharedUsers[1001:2000]`. *  `subscriptions` Returns the users that are subscribed to the filter. If you don't specify `subscriptions`, the `subscriptions` object is returned but it doesn't list any subscriptions. The list of subscriptions returned is limited to 1000, to access additional subscriptions append `[start-index:end-index]` to the expand request. For example, to access the next 1000 subscriptions, use `?expand=subscriptions[1001:2000]`.</param>
        [Put("/rest/api/3/filter/{id}/favourite")]
        Task<Response<AnyOf<Filter, object>>> SetFavouriteForFilterAsync([Path] long id, [Query] string expand);

        /// <summary>
        /// Remove filter as favorite
        /// </summary>
        /// <param name="id">The ID of the filter.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about filter in the response. This parameter accepts a comma-separated list. Expand options include: *  `sharedUsers` Returns the users that the filter is shared with. This includes users that can browse projects that the filter is shared with. If you don't specify `sharedUsers`, then the `sharedUsers` object is returned but it doesn't list any users. The list of users returned is limited to 1000, to access additional users append `[start-index:end-index]` to the expand request. For example, to access the next 1000 users, use `?expand=sharedUsers[1001:2000]`. *  `subscriptions` Returns the users that are subscribed to the filter. If you don't specify `subscriptions`, the `subscriptions` object is returned but it doesn't list any subscriptions. The list of subscriptions returned is limited to 1000, to access additional subscriptions append `[start-index:end-index]` to the expand request. For example, to access the next 1000 subscriptions, use `?expand=subscriptions[1001:2000]`.</param>
        [Delete("/rest/api/3/filter/{id}/favourite")]
        Task<Response<AnyOf<Filter, object>>> DeleteFavouriteForFilterAsync([Path] long id, [Query] string expand);

        /// <summary>
        /// Get share permissions
        /// </summary>
        /// <param name="id">The ID of the filter.</param>
        [Get("/rest/api/3/filter/{id}/permission")]
        Task<Response<AnyOf<SharePermission[], object>>> GetSharePermissionsAsync([Path] long id);

        /// <summary>
        /// Add share permission
        /// </summary>
        /// <param name="id">The ID of the filter.</param>
        /// <param name="content"></param>
        [Post("/rest/api/3/filter/{id}/permission")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SharePermission[], object>>> AddSharePermissionAsync([Path] long id, [Body] SharePermissionInputBean content);

        /// <summary>
        /// Get share permission
        /// </summary>
        /// <param name="id">The ID of the filter.</param>
        /// <param name="permissionId">The ID of the share permission.</param>
        [Get("/rest/api/3/filter/{id}/permission/{permissionId}")]
        Task<Response<AnyOf<SharePermission, object>>> GetSharePermissionAsync([Path] long id, [Path] long permissionId);

        /// <summary>
        /// Delete share permission
        /// </summary>
        /// <param name="id">The ID of the filter.</param>
        /// <param name="permissionId">The ID of the share permission.</param>
        [Delete("/rest/api/3/filter/{id}/permission/{permissionId}")]
        Task<object> DeleteSharePermissionAsync([Path] long id, [Path] long permissionId);

        /// <summary>
        /// Get group
        /// </summary>
        /// <param name="groupname">The name of the group.</param>
        /// <param name="expand">List of fields to expand.</param>
        [Get("/rest/api/3/group")]
        Task<Response<AnyOf<Group, object>>> GetGroupAsync([Query] string groupname, [Query] string expand);

        /// <summary>
        /// Create group
        /// </summary>
        /// <param name="content">The name of the group.</param>
        [Post("/rest/api/3/group")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Group, object>>> CreateGroupAsync([Body] AddGroupBean content);

        /// <summary>
        /// Remove group
        /// </summary>
        /// <param name="groupname">The name of the group.</param>
        /// <param name="swapGroup">The group to transfer restrictions to. Only comments and worklogs are transferred. If restrictions are not transferred, comments and worklogs are inaccessible after the deletion.</param>
        [Delete("/rest/api/3/group")]
        Task<object> RemoveGroupAsync([Query] string groupname, [Query] string swapGroup);

        /// <summary>
        /// Bulk get groups
        /// </summary>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="groupId">The ID of a group. To specify multiple IDs, pass multiple `groupId` parameters. For example, `groupId=5b10a2844c20165700ede21g&groupId=5b10ac8d82e05b22cc7d4ef5`.</param>
        /// <param name="groupName">The name of a group. To specify multiple names, pass multiple `groupName` parameters. For example, `groupName=administrators&groupName=jira-software-users`.</param>
        [Get("/rest/api/3/group/bulk")]
        Task<Response<AnyOf<PageBeanGroupDetails, object>>> BulkGetGroupsAsync([Query] long? startAt, [Query] int? maxResults, [Query] string[] groupId, [Query] string[] groupName);

        /// <summary>
        /// Get users from group
        /// </summary>
        /// <param name="groupname">The name of the group.</param>
        /// <param name="includeInactiveUsers">Include inactive users.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/group/member")]
        Task<Response<AnyOf<PageBeanUserDetails, object>>> GetUsersFromGroupAsync([Query] string groupname, [Query] bool? includeInactiveUsers, [Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Add user to group
        /// </summary>
        /// <param name="content">The user to add to the group.</param>
        /// <param name="groupname">The name of the group (case sensitive).</param>
        [Post("/rest/api/3/group/user")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Group, object>>> AddUserToGroupAsync([Body] UpdateUserToGroupBean content, [Query] string groupname);

        /// <summary>
        /// Remove user from group
        /// </summary>
        /// <param name="groupname">The name of the group.</param>
        /// <param name="accountId">The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.</param>
        /// <param name="username">This parameter is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        [Delete("/rest/api/3/group/user")]
        Task<object> RemoveUserFromGroupAsync([Query] string groupname, [Query] string accountId, [Query] string username);

        /// <summary>
        /// Find groups
        /// </summary>
        /// <param name="accountId">This parameter is deprecated, setting it does not affect the results. To find groups containing a particular user, use [Get user groups](#api-rest-api-3-user-groups-get).</param>
        /// <param name="query">The string to find in group names.</param>
        /// <param name="exclude">A group to exclude from the result. To exclude multiple groups, provide an ampersand-separated list. For example, `exclude=group1&exclude=group2`.</param>
        /// <param name="maxResults">The maximum number of groups to return. The maximum number of groups that can be returned is limited by the system property `jira.ajax.autocomplete.limit`.</param>
        /// <param name="userName">This parameter is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        [Get("/rest/api/3/groups/picker")]
        Task<FoundGroups> FindGroupsAsync([Query] string accountId, [Query] string query, [Query] string[] exclude, [Query] int? maxResults, [Query] string userName);

        /// <summary>
        /// Find users and groups
        /// </summary>
        /// <param name="query">The search string.</param>
        /// <param name="maxResults">The maximum number of items to return in each list.</param>
        /// <param name="showAvatar">Whether the user avatar should be returned. If an invalid value is provided, the default value is used.</param>
        /// <param name="fieldId">The custom field ID of the field this request is for.</param>
        /// <param name="projectId">The ID of a project that returned users and groups must have permission to view. To include multiple projects, provide an ampersand-separated list. For example, `projectId=10000&projectId=10001`. This parameter is only used when `fieldId` is present.</param>
        /// <param name="issueTypeId">The ID of an issue type that returned users and groups must have permission to view. To include multiple issue types, provide an ampersand-separated list. For example, `issueTypeId=10000&issueTypeId=10001`. Special values, such as `-1` (all standard issue types) and `-2` (all subtask issue types), are supported. This parameter is only used when `fieldId` is present.</param>
        /// <param name="avatarSize">The size of the avatar to return. If an invalid value is provided, the default value is used.</param>
        /// <param name="caseInsensitive">Whether the search for groups should be case insensitive.</param>
        /// <param name="excludeConnectAddons">Whether Connect app users and groups should be excluded from the search results. If an invalid value is provided, the default value is used.</param>
        [Get("/rest/api/3/groupuserpicker")]
        Task<Response<AnyOf<FoundUsersAndGroups, object>>> FindUsersAndGroupsAsync([Query] string query, [Query] int? maxResults, [Query] bool? showAvatar, [Query] string fieldId, [Query] string[] projectId, [Query] string[] issueTypeId, [Query] string avatarSize, [Query] bool? caseInsensitive, [Query] bool? excludeConnectAddons);

        /// <summary>
        /// Get license
        /// </summary>
        [Get("/rest/api/3/instance/license")]
        Task<Response<AnyOf<License, object>>> GetLicenseAsync();

        /// <summary>
        /// Create issue
        /// </summary>
        /// <param name="content">Details of an issue update request.</param>
        /// <param name="updateHistory">Whether the project in which the issue is created is added to the user's **Recently viewed** project list, as shown under **Projects** in Jira. When provided, the issue type and request type are added to the user's history for a project. These values are then used to provide defaults on the issue create screen.</param>
        [Post("/rest/api/3/issue")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<CreatedIssue, ErrorCollection>>> CreateIssueAsync([Body] IssueUpdateDetails content, [Query] bool? updateHistory);

        /// <summary>
        /// Bulk create issue
        /// </summary>
        /// <param name="content"></param>
        [Post("/rest/api/3/issue/bulk")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<CreatedIssues, object>>> CreateIssuesAsync([Body] IssuesUpdateBean content);

        /// <summary>
        /// Get create issue metadata
        /// </summary>
        /// <param name="projectIds">List of project IDs. This parameter accepts a comma-separated list. Multiple project IDs can also be provided using an ampersand-separated list. For example, `projectIds=10000,10001&projectIds=10020,10021`. This parameter may be provided with `projectKeys`.</param>
        /// <param name="projectKeys">List of project keys. This parameter accepts a comma-separated list. Multiple project keys can also be provided using an ampersand-separated list. For example, `projectKeys=proj1,proj2&projectKeys=proj3`. This parameter may be provided with `projectIds`.</param>
        /// <param name="issuetypeIds">List of issue type IDs. This parameter accepts a comma-separated list. Multiple issue type IDs can also be provided using an ampersand-separated list. For example, `issuetypeIds=10000,10001&issuetypeIds=10020,10021`. This parameter may be provided with `issuetypeNames`.</param>
        /// <param name="issuetypeNames">List of issue type names. This parameter accepts a comma-separated list. Multiple issue type names can also be provided using an ampersand-separated list. For example, `issuetypeNames=name1,name2&issuetypeNames=name3`. This parameter may be provided with `issuetypeIds`.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about issue metadata in the response. This parameter accepts `projects.issuetypes.fields`, which returns information about the fields in the issue creation screen for each issue type. Fields hidden from the screen are not returned. Use the information to populate the `fields` and `update` fields in [Create issue](#api-rest-api-3-issue-post) and [Create issues](#api-rest-api-3-issue-bulk-post).</param>
        [Get("/rest/api/3/issue/createmeta")]
        Task<Response<AnyOf<IssueCreateMetadata, object>>> GetCreateIssueMetaAsync([Query] string[] projectIds, [Query] string[] projectKeys, [Query] string[] issuetypeIds, [Query] string[] issuetypeNames, [Query] string expand);

        /// <summary>
        /// Get issue picker suggestions
        /// </summary>
        /// <param name="query">A string to match against text fields in the issue such as title, description, or comments.</param>
        /// <param name="currentJQL">A JQL query defining a list of issues to search for the query term. Note that `username` and `userkey` cannot be used as search terms for this parameter, due to privacy reasons. Use `accountId` instead.</param>
        /// <param name="currentIssueKey">The key of an issue to exclude from search results. For example, the issue the user is viewing when they perform this query.</param>
        /// <param name="currentProjectId">The ID of a project that suggested issues must belong to.</param>
        /// <param name="showSubTasks">Indicate whether to include subtasks in the suggestions list.</param>
        /// <param name="showSubTaskParent">When `currentIssueKey` is a subtask, whether to include the parent issue in the suggestions if it matches the query.</param>
        [Get("/rest/api/3/issue/picker")]
        Task<Response<AnyOf<IssuePickerSuggestions, object>>> GetIssuePickerResourceAsync([Query] string query, [Query] string currentJQL, [Query] string currentIssueKey, [Query] string currentProjectId, [Query] bool? showSubTasks, [Query] bool? showSubTaskParent);

        /// <summary>
        /// Bulk set issues properties by list
        /// </summary>
        /// <param name="content">Lists of issues and entity properties. See [Entity properties](https://developer.atlassian.com/cloud/jira/platform/jira-entity-properties/) for more information.</param>
        [Post("/rest/api/3/issue/properties")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, ErrorCollection>>> BulkSetIssuesPropertiesListAsync([Body] IssueEntityProperties content);

        /// <summary>
        /// Bulk set issue properties by issue
        /// </summary>
        /// <param name="content">A list of issues and their respective properties to set or update. See [Entity properties](https://developer.atlassian.com/cloud/jira/platform/jira-entity-properties/) for more information.</param>
        [Post("/rest/api/3/issue/properties/multi")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, ErrorCollection>>> BulkSetIssuePropertiesByIssueAsync([Body] MultiIssueEntityProperties content);

        /// <summary>
        /// Bulk set issue property
        /// </summary>
        /// <param name="propertyKey">The key of the property. The maximum length is 255 characters.</param>
        /// <param name="content">Bulk issue property update request details.</param>
        [Put("/rest/api/3/issue/properties/{propertyKey}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, ErrorCollection>>> BulkSetIssuePropertyAsync([Path] string propertyKey, [Body] BulkIssuePropertyUpdateRequest content);

        /// <summary>
        /// Bulk delete issue property
        /// </summary>
        /// <param name="propertyKey">The key of the property.</param>
        /// <param name="content">Bulk operation filter details.</param>
        [Delete("/rest/api/3/issue/properties/{propertyKey}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, ErrorCollection>>> BulkDeleteIssuePropertyAsync([Path] string propertyKey, [Body] IssueFilterForBulkPropertyDelete content);

        /// <summary>
        /// Get is watching issue bulk
        /// </summary>
        /// <param name="content">A list of issue IDs.</param>
        [Post("/rest/api/3/issue/watching")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<BulkIssueIsWatching, object>>> GetIsWatchingIssueBulkAsync([Body] IssueList content);

        /// <summary>
        /// Get issue
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="fields">A list of fields to return for the issue. This parameter accepts a comma-separated list. Use it to retrieve a subset of fields. Allowed values: *  `*all` Returns all fields. *  `*navigable` Returns navigable fields. *  Any issue field, prefixed with a minus to exclude.Examples: *  `summary,comment` Returns only the summary and comments fields. *  `-description` Returns all (default) fields except description. *  `*navigable,-comment` Returns all navigable fields except comment.This parameter may be specified multiple times. For example, `fields=field1,field2& fields=field3`.Note: All fields are returned by default. This differs from [Search for issues using JQL (GET)](#api-rest-api-3-search-get) and [Search for issues using JQL (POST)](#api-rest-api-3-search-post) where the default is all navigable fields.</param>
        /// <param name="fieldsByKeys">Whether fields in `fields` are referenced by keys rather than IDs. This parameter is useful where fields have been added by a connect app and a field's key may differ from its ID.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about the issues in the response. This parameter accepts a comma-separated list. Expand options include: *  `renderedFields` Returns field values rendered in HTML format. *  `names` Returns the display name of each field. *  `schema` Returns the schema describing a field type. *  `transitions` Returns all possible transitions for the issue. *  `editmeta` Returns information about how each field can be edited. *  `changelog` Returns a list of recent updates to an issue, sorted by date, starting from the most recent. *  `versionedRepresentations` Returns a JSON array for each version of a field's value, with the highest number representing the most recent version. Note: When included in the request, the `fields` parameter is ignored.</param>
        /// <param name="properties">A list of issue properties to return for the issue. This parameter accepts a comma-separated list. Allowed values: *  `*all` Returns all issue properties. *  Any issue property key, prefixed with a minus to exclude.Examples: *  `*all` Returns all properties. *  `*all,-prop1` Returns all properties except `prop1`. *  `prop1,prop2` Returns `prop1` and `prop2` properties.This parameter may be specified multiple times. For example, `properties=prop1,prop2& properties=prop3`.</param>
        /// <param name="updateHistory">Whether the project in which the issue is created is added to the user's **Recently viewed** project list, as shown under **Projects** in Jira. This also populates the [JQL issues search](#api-rest-api-3-search-get) `lastViewed` field.</param>
        [Get("/rest/api/3/issue/{issueIdOrKey}")]
        Task<Response<AnyOf<IssueBean, object>>> GetIssueAsync([Path] string issueIdOrKey, [Query] string[] fields, [Query] bool? fieldsByKeys, [Query] string expand, [Query] string[] properties, [Query] bool? updateHistory);

        /// <summary>
        /// Edit issue
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="content">Details of an issue update request.</param>
        /// <param name="notifyUsers">Whether a notification email about the issue update is sent to all watchers. To disable the notification, administer Jira or administer project permissions are required. If the user doesn't have the necessary permission the request is ignored.</param>
        /// <param name="overrideScreenSecurity">Whether screen security is overridden to enable hidden fields to be edited. Available to Connect app users with admin permission and Forge app users with the `manage:jira-configuration` scope.</param>
        /// <param name="overrideEditableFlag">Whether screen security is overridden to enable uneditable fields to be edited. Available to Connect app users with admin permission and Forge app users with the `manage:jira-configuration` scope.</param>
        [Put("/rest/api/3/issue/{issueIdOrKey}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<EditIssueResult, object>>> EditIssueAsync([Path] string issueIdOrKey, [Body] IssueUpdateDetails content, [Query] bool? notifyUsers, [Query] bool? overrideScreenSecurity, [Query] bool? overrideEditableFlag);

        /// <summary>
        /// Delete issue
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="deleteSubtasks">Whether the issue's subtasks are deleted when the issue is deleted.</param>
        [Delete("/rest/api/3/issue/{issueIdOrKey}")]
        Task<object> DeleteIssueAsync([Path] string issueIdOrKey, [Query] string deleteSubtasks);

        /// <summary>
        /// Assign issue
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue to be assigned.</param>
        /// <param name="content">A user with details as permitted by the user's Atlassian Account privacy settings. However, be aware of these exceptions: *  User record deleted from Atlassian: This occurs as the result of a right to be forgotten request. In this case, `displayName` provides an indication and other parameters have default values or are blank (for example, email is blank). *  User record corrupted: This occurs as a results of events such as a server import and can only happen to deleted users. In this case, `accountId` returns *unknown* and all other parameters have fallback values. *  User record unavailable: This usually occurs due to an internal service outage. In this case, all parameters have fallback values.</param>
        [Put("/rest/api/3/issue/{issueIdOrKey}/assignee")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<AssignIssueResult, object>>> AssignIssueAsync([Path] string issueIdOrKey, [Body] User content);

        /// <summary>
        /// Add attachment
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue that attachments are added to.</param>
        /// <param name="content">An extension method is generated to support the exact parameters.</param>
        [Post("/rest/api/3/issue/{issueIdOrKey}/attachments")]
        [Header("Content-Type", "multipart/form-data")]
        Task<Response<AnyOf<Attachment[], object>>> AddAttachmentAsync([Path] string issueIdOrKey, [Body] HttpContent content);

        /// <summary>
        /// Get changelogs
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/issue/{issueIdOrKey}/changelog")]
        Task<Response<AnyOf<PageBeanChangelog, object>>> GetChangeLogsAsync([Path] string issueIdOrKey, [Query] int? startAt, [Query] int? maxResults);

        /// <summary>
        /// Get changelogs by IDs
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="content">A list of changelog IDs.</param>
        [Post("/rest/api/3/issue/{issueIdOrKey}/changelog/list")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PageOfChangelogs, object>>> GetChangeLogsByIdsAsync([Path] string issueIdOrKey, [Body] IssueChangelogIds content);

        /// <summary>
        /// Get comments
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="orderBy">[Order](#ordering) the results by a field. Accepts *created* to sort comments by their created date.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about comments in the response. This parameter accepts `renderedBody`, which returns the comment body rendered in HTML.</param>
        [Get("/rest/api/3/issue/{issueIdOrKey}/comment")]
        Task<Response<AnyOf<PageOfComments, object>>> GetCommentsAsync([Path] string issueIdOrKey, [Query] long? startAt, [Query] int? maxResults, [Query] string orderBy, [Query] string expand);

        /// <summary>
        /// Add comment
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="content">A comment.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about comments in the response. This parameter accepts `renderedBody`, which returns the comment body rendered in HTML.</param>
        [Post("/rest/api/3/issue/{issueIdOrKey}/comment")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Comment, object>>> AddCommentAsync([Path] string issueIdOrKey, [Body] Comment content, [Query] string expand);

        /// <summary>
        /// Get comment
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="id">The ID of the comment.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about comments in the response. This parameter accepts `renderedBody`, which returns the comment body rendered in HTML.</param>
        [Get("/rest/api/3/issue/{issueIdOrKey}/comment/{id}")]
        Task<Response<AnyOf<Comment, object>>> GetCommentAsync([Path] string issueIdOrKey, [Path] string id, [Query] string expand);

        /// <summary>
        /// Update comment
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="id">The ID of the comment.</param>
        /// <param name="content">A comment.</param>
        /// <param name="notifyUsers">Set to false to stop users being notified that a comment is updated</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about comments in the response. This parameter accepts `renderedBody`, which returns the comment body rendered in HTML.</param>
        [Put("/rest/api/3/issue/{issueIdOrKey}/comment/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Comment, object>>> UpdateCommentAsync([Path] string issueIdOrKey, [Path] string id, [Body] Comment content, [Query] bool? notifyUsers, [Query] string expand);

        /// <summary>
        /// Delete comment
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="id">The ID of the comment.</param>
        [Delete("/rest/api/3/issue/{issueIdOrKey}/comment/{id}")]
        Task<object> DeleteCommentAsync([Path] string issueIdOrKey, [Path] string id);

        /// <summary>
        /// Get edit issue metadata
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="overrideScreenSecurity">Whether hidden fields are returned. Available to Connect app users with admin permission and Forge app users with the `manage:jira-configuration` scope.</param>
        /// <param name="overrideEditableFlag">Whether non-editable fields are returned. Available to Connect app users with admin permission and Forge app users with the `manage:jira-configuration` scope.</param>
        [Get("/rest/api/3/issue/{issueIdOrKey}/editmeta")]
        Task<Response<AnyOf<IssueUpdateMetadata, object>>> GetEditIssueMetaAsync([Path] string issueIdOrKey, [Query] bool? overrideScreenSecurity, [Query] bool? overrideEditableFlag);

        /// <summary>
        /// Send notification for issue
        /// </summary>
        /// <param name="issueIdOrKey">ID or key of the issue that the notification is sent for.</param>
        /// <param name="content">Details about a notification.</param>
        [Post("/rest/api/3/issue/{issueIdOrKey}/notify")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<NotifyResult, object>>> NotifyAsync([Path] string issueIdOrKey, [Body] Notification content);

        /// <summary>
        /// Get issue property keys
        /// </summary>
        /// <param name="issueIdOrKey">The key or ID of the issue.</param>
        [Get("/rest/api/3/issue/{issueIdOrKey}/properties")]
        Task<Response<AnyOf<PropertyKeys, object>>> GetIssuePropertyKeysAsync([Path] string issueIdOrKey);

        /// <summary>
        /// Get issue property
        /// </summary>
        /// <param name="issueIdOrKey">The key or ID of the issue.</param>
        /// <param name="propertyKey">The key of the property.</param>
        [Get("/rest/api/3/issue/{issueIdOrKey}/properties/{propertyKey}")]
        Task<Response<AnyOf<EntityProperty, object>>> GetIssuePropertyAsync([Path] string issueIdOrKey, [Path] string propertyKey);

        /// <summary>
        /// Set issue property
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="propertyKey">The key of the issue property. The maximum length is 255 characters.</param>
        [Put("/rest/api/3/issue/{issueIdOrKey}/properties/{propertyKey}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SetIssuePropertyResult, object>>> SetIssuePropertyAsync([Path] string issueIdOrKey, [Path] string propertyKey);

        /// <summary>
        /// Delete issue property
        /// </summary>
        /// <param name="issueIdOrKey">The key or ID of the issue.</param>
        /// <param name="propertyKey">The key of the property.</param>
        [Delete("/rest/api/3/issue/{issueIdOrKey}/properties/{propertyKey}")]
        Task<object> DeleteIssuePropertyAsync([Path] string issueIdOrKey, [Path] string propertyKey);

        /// <summary>
        /// Get remote issue links
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="globalId">The global ID of the remote issue link.</param>
        [Get("/rest/api/3/issue/{issueIdOrKey}/remotelink")]
        Task<Response<AnyOf<RemoteIssueLink, object>>> GetRemoteIssueLinksAsync([Path] string issueIdOrKey, [Query] string globalId);

        /// <summary>
        /// Create or update remote issue link
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="content">Details of a remote issue link.</param>
        [Post("/rest/api/3/issue/{issueIdOrKey}/remotelink")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<RemoteIssueLinkIdentifies, object>>> CreateOrUpdateRemoteIssueLinkAsync([Path] string issueIdOrKey, [Body] RemoteIssueLinkRequest content);

        /// <summary>
        /// Delete remote issue link by global ID
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="globalId">The global ID of a remote issue link.</param>
        [Delete("/rest/api/3/issue/{issueIdOrKey}/remotelink")]
        Task<object> DeleteRemoteIssueLinkByGlobalIdAsync([Path] string issueIdOrKey, [Query] string globalId);

        /// <summary>
        /// Get remote issue link by ID
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="linkId">The ID of the remote issue link.</param>
        [Get("/rest/api/3/issue/{issueIdOrKey}/remotelink/{linkId}")]
        Task<Response<AnyOf<RemoteIssueLink, object>>> GetRemoteIssueLinkByIdAsync([Path] string issueIdOrKey, [Path] string linkId);

        /// <summary>
        /// Update remote issue link by ID
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="linkId">The ID of the remote issue link.</param>
        /// <param name="content">Details of a remote issue link.</param>
        [Put("/rest/api/3/issue/{issueIdOrKey}/remotelink/{linkId}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<UpdateRemoteIssueLinkResult, object>>> UpdateRemoteIssueLinkAsync([Path] string issueIdOrKey, [Path] string linkId, [Body] RemoteIssueLinkRequest content);

        /// <summary>
        /// Delete remote issue link by ID
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="linkId">The ID of a remote issue link.</param>
        [Delete("/rest/api/3/issue/{issueIdOrKey}/remotelink/{linkId}")]
        Task<object> DeleteRemoteIssueLinkByIdAsync([Path] string issueIdOrKey, [Path] string linkId);

        /// <summary>
        /// Get transitions
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about transitions in the response. This parameter accepts `transitions.fields`, which returns information about the fields in the transition screen for each transition. Fields hidden from the screen are not returned. Use this information to populate the `fields` and `update` fields in [Transition issue](#api-rest-api-3-issue-issueIdOrKey-transitions-post).</param>
        /// <param name="transitionId">The ID of the transition.</param>
        /// <param name="skipRemoteOnlyCondition">Whether transitions with the condition *Hide From User Condition* are included in the response.</param>
        /// <param name="includeUnavailableTransitions">Whether details of transitions that fail a condition are included in the response</param>
        /// <param name="sortByOpsBarAndStatus">Whether the transitions are sorted by ops-bar sequence value first then category order (Todo, In Progress, Done) or only by ops-bar sequence value.</param>
        [Get("/rest/api/3/issue/{issueIdOrKey}/transitions")]
        Task<Response<AnyOf<Transitions, object>>> GetTransitionsAsync([Path] string issueIdOrKey, [Query] string expand, [Query] string transitionId, [Query] bool? skipRemoteOnlyCondition, [Query] bool? includeUnavailableTransitions, [Query] bool? sortByOpsBarAndStatus);

        /// <summary>
        /// Transition issue
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="content">Details of an issue update request.</param>
        [Post("/rest/api/3/issue/{issueIdOrKey}/transitions")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<DoTransitionResult, object>>> DoTransitionAsync([Path] string issueIdOrKey, [Body] IssueUpdateDetails content);

        /// <summary>
        /// Get votes
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        [Get("/rest/api/3/issue/{issueIdOrKey}/votes")]
        Task<Response<AnyOf<Votes, object>>> GetVotesAsync([Path] string issueIdOrKey);

        /// <summary>
        /// Add vote
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        [Post("/rest/api/3/issue/{issueIdOrKey}/votes")]
        Task<Response<AnyOf<AddVoteResult, object>>> AddVoteAsync([Path] string issueIdOrKey);

        /// <summary>
        /// Delete vote
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        [Delete("/rest/api/3/issue/{issueIdOrKey}/votes")]
        Task<object> RemoveVoteAsync([Path] string issueIdOrKey);

        /// <summary>
        /// Get issue watchers
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        [Get("/rest/api/3/issue/{issueIdOrKey}/watchers")]
        Task<Response<AnyOf<Watchers, object>>> GetIssueWatchersAsync([Path] string issueIdOrKey);

        /// <summary>
        /// Add watcher
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        [Post("/rest/api/3/issue/{issueIdOrKey}/watchers")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<AddWatcherResult, object>>> AddWatcherAsync([Path] string issueIdOrKey);

        /// <summary>
        /// Delete watcher
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="username">This parameter is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        /// <param name="accountId">The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*. Required.</param>
        [Delete("/rest/api/3/issue/{issueIdOrKey}/watchers")]
        Task<object> RemoveWatcherAsync([Path] string issueIdOrKey, [Query] string username, [Query] string accountId);

        /// <summary>
        /// Get issue worklogs
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="startedAfter">The worklog start date and time, as a UNIX timestamp in milliseconds, after which worklogs are returned.</param>
        /// <param name="startedBefore">The worklog start date and time, as a UNIX timestamp in milliseconds, before which worklogs are returned.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about worklogs in the response. This parameter accepts`properties`, which returns worklog properties.</param>
        [Get("/rest/api/3/issue/{issueIdOrKey}/worklog")]
        Task<Response<AnyOf<PageOfWorklogs, object>>> GetIssueWorklogAsync([Path] string issueIdOrKey, [Query] long? startAt, [Query] int? maxResults, [Query] long? startedAfter, [Query] long? startedBefore, [Query] string expand);

        /// <summary>
        /// Add worklog
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key the issue.</param>
        /// <param name="content">Details of a worklog.</param>
        /// <param name="notifyUsers">Whether users watching the issue are notified by email.</param>
        /// <param name="adjustEstimate">Defines how to update the issue's time estimate, the options are: *  `new` Sets the estimate to a specific value, defined in `newEstimate`. *  `leave` Leaves the estimate unchanged. *  `manual` Reduces the estimate by amount specified in `reduceBy`. *  `auto` Reduces the estimate by the value of `timeSpent` in the worklog.</param>
        /// <param name="newEstimate">The value to set as the issue's remaining time estimate, as days (\#d), hours (\#h), or minutes (\#m or \#). For example, *2d*. Required when `adjustEstimate` is `new`.</param>
        /// <param name="reduceBy">The amount to reduce the issue's remaining estimate by, as days (\#d), hours (\#h), or minutes (\#m). For example, *2d*. Required when `adjustEstimate` is `manual`.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about work logs in the response. This parameter accepts `properties`, which returns worklog properties.</param>
        /// <param name="overrideEditableFlag">Whether the worklog entry should be added to the issue even if the issue is not editable, because jira.issue.editable set to false or missing. For example, the issue is closed. Connect app users with admin permission and Forge app users with the `manage:jira-configuration` scope can use this flag.</param>
        [Post("/rest/api/3/issue/{issueIdOrKey}/worklog")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Worklog, object>>> AddWorklogAsync([Path] string issueIdOrKey, [Body] Worklog content, [Query] bool? notifyUsers, [Query] string adjustEstimate, [Query] string newEstimate, [Query] string reduceBy, [Query] string expand, [Query] bool? overrideEditableFlag);

        /// <summary>
        /// Get worklog
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="id">The ID of the worklog.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about work logs in the response. This parameter accepts`properties`, which returns worklog properties.</param>
        [Get("/rest/api/3/issue/{issueIdOrKey}/worklog/{id}")]
        Task<Response<AnyOf<Worklog, object>>> GetWorklogAsync([Path] string issueIdOrKey, [Path] string id, [Query] string expand);

        /// <summary>
        /// Update worklog
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key the issue.</param>
        /// <param name="id">The ID of the worklog.</param>
        /// <param name="content">Details of a worklog.</param>
        /// <param name="notifyUsers">Whether users watching the issue are notified by email.</param>
        /// <param name="adjustEstimate">Defines how to update the issue's time estimate, the options are: *  `new` Sets the estimate to a specific value, defined in `newEstimate`. *  `leave` Leaves the estimate unchanged. *  `auto` Updates the estimate by the difference between the original and updated value of `timeSpent` or `timeSpentSeconds`.</param>
        /// <param name="newEstimate">The value to set as the issue's remaining time estimate, as days (\#d), hours (\#h), or minutes (\#m or \#). For example, *2d*. Required when `adjustEstimate` is `new`.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about worklogs in the response. This parameter accepts `properties`, which returns worklog properties.</param>
        /// <param name="overrideEditableFlag">Whether the worklog should be added to the issue even if the issue is not editable. For example, because the issue is closed. Connect app users with admin permission and Forge app users with the `manage:jira-configuration` scope can use this flag.</param>
        [Put("/rest/api/3/issue/{issueIdOrKey}/worklog/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Worklog, object>>> UpdateWorklogAsync([Path] string issueIdOrKey, [Path] string id, [Body] Worklog content, [Query] bool? notifyUsers, [Query] string adjustEstimate, [Query] string newEstimate, [Query] string expand, [Query] bool? overrideEditableFlag);

        /// <summary>
        /// Delete worklog
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="id">The ID of the worklog.</param>
        /// <param name="notifyUsers">Whether users watching the issue are notified by email.</param>
        /// <param name="adjustEstimate">Defines how to update the issue's time estimate, the options are: *  `new` Sets the estimate to a specific value, defined in `newEstimate`. *  `leave` Leaves the estimate unchanged. *  `manual` Increases the estimate by amount specified in `increaseBy`. *  `auto` Reduces the estimate by the value of `timeSpent` in the worklog.</param>
        /// <param name="newEstimate">The value to set as the issue's remaining time estimate, as days (\#d), hours (\#h), or minutes (\#m or \#). For example, *2d*. Required when `adjustEstimate` is `new`.</param>
        /// <param name="increaseBy">The amount to increase the issue's remaining estimate by, as days (\#d), hours (\#h), or minutes (\#m or \#). For example, *2d*. Required when `adjustEstimate` is `manual`.</param>
        /// <param name="overrideEditableFlag">Whether the work log entry should be added to the issue even if the issue is not editable, because jira.issue.editable set to false or missing. For example, the issue is closed. Connect app users with admin permission and Forge app users with the `manage:jira-configuration` scope can use this flag.</param>
        [Delete("/rest/api/3/issue/{issueIdOrKey}/worklog/{id}")]
        Task<object> DeleteWorklogAsync([Path] string issueIdOrKey, [Path] string id, [Query] bool? notifyUsers, [Query] string adjustEstimate, [Query] string newEstimate, [Query] string increaseBy, [Query] bool? overrideEditableFlag);

        /// <summary>
        /// Get worklog property keys
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="worklogId">The ID of the worklog.</param>
        [Get("/rest/api/3/issue/{issueIdOrKey}/worklog/{worklogId}/properties")]
        Task<Response<AnyOf<PropertyKeys, object>>> GetWorklogPropertyKeysAsync([Path] string issueIdOrKey, [Path] string worklogId);

        /// <summary>
        /// Get worklog property
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="worklogId">The ID of the worklog.</param>
        /// <param name="propertyKey">The key of the property.</param>
        [Get("/rest/api/3/issue/{issueIdOrKey}/worklog/{worklogId}/properties/{propertyKey}")]
        Task<Response<AnyOf<EntityProperty, object>>> GetWorklogPropertyAsync([Path] string issueIdOrKey, [Path] string worklogId, [Path] string propertyKey);

        /// <summary>
        /// Set worklog property
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="worklogId">The ID of the worklog.</param>
        /// <param name="propertyKey">The key of the issue property. The maximum length is 255 characters.</param>
        [Put("/rest/api/3/issue/{issueIdOrKey}/worklog/{worklogId}/properties/{propertyKey}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SetWorklogPropertyResult, object>>> SetWorklogPropertyAsync([Path] string issueIdOrKey, [Path] string worklogId, [Path] string propertyKey);

        /// <summary>
        /// Delete worklog property
        /// </summary>
        /// <param name="issueIdOrKey">The ID or key of the issue.</param>
        /// <param name="worklogId">The ID of the worklog.</param>
        /// <param name="propertyKey">The key of the property.</param>
        [Delete("/rest/api/3/issue/{issueIdOrKey}/worklog/{worklogId}/properties/{propertyKey}")]
        Task<object> DeleteWorklogPropertyAsync([Path] string issueIdOrKey, [Path] string worklogId, [Path] string propertyKey);

        /// <summary>
        /// Create issue link
        /// </summary>
        /// <param name="content">The issue link request.</param>
        [Post("/rest/api/3/issueLink")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<LinkIssuesResult, object>>> LinkIssuesAsync([Body] LinkIssueRequestJsonBean content);

        /// <summary>
        /// Get issue link
        /// </summary>
        /// <param name="linkId">The ID of the issue link.</param>
        [Get("/rest/api/3/issueLink/{linkId}")]
        Task<Response<AnyOf<IssueLink, object>>> GetIssueLinkAsync([Path] string linkId);

        /// <summary>
        /// Delete issue link
        /// </summary>
        /// <param name="linkId">The ID of the issue link.</param>
        [Delete("/rest/api/3/issueLink/{linkId}")]
        Task<object> DeleteIssueLinkAsync([Path] string linkId);

        /// <summary>
        /// Get issue link types
        /// </summary>
        [Get("/rest/api/3/issueLinkType")]
        Task<Response<AnyOf<IssueLinkTypes, object>>> GetIssueLinkTypesAsync();

        /// <summary>
        /// Create issue link type
        /// </summary>
        /// <param name="content">This object is used as follows: *  In the [ issueLink](#api-rest-api-3-issueLink-post) resource it defines and reports on the type of link between the issues. Find a list of issue link types with [Get issue link types](#api-rest-api-3-issueLinkType-get). *  In the [ issueLinkType](#api-rest-api-3-issueLinkType-post) resource it defines and reports on issue link types.</param>
        [Post("/rest/api/3/issueLinkType")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<IssueLinkType, object>>> CreateIssueLinkTypeAsync([Body] IssueLinkType content);

        /// <summary>
        /// Get issue link type
        /// </summary>
        /// <param name="issueLinkTypeId">The ID of the issue link type.</param>
        [Get("/rest/api/3/issueLinkType/{issueLinkTypeId}")]
        Task<Response<AnyOf<IssueLinkType, object>>> GetIssueLinkTypeAsync([Path] string issueLinkTypeId);

        /// <summary>
        /// Update issue link type
        /// </summary>
        /// <param name="issueLinkTypeId">The ID of the issue link type.</param>
        /// <param name="content">This object is used as follows: *  In the [ issueLink](#api-rest-api-3-issueLink-post) resource it defines and reports on the type of link between the issues. Find a list of issue link types with [Get issue link types](#api-rest-api-3-issueLinkType-get). *  In the [ issueLinkType](#api-rest-api-3-issueLinkType-post) resource it defines and reports on issue link types.</param>
        [Put("/rest/api/3/issueLinkType/{issueLinkTypeId}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<IssueLinkType, object>>> UpdateIssueLinkTypeAsync([Path] string issueLinkTypeId, [Body] IssueLinkType content);

        /// <summary>
        /// Delete issue link type
        /// </summary>
        /// <param name="issueLinkTypeId">The ID of the issue link type.</param>
        [Delete("/rest/api/3/issueLinkType/{issueLinkTypeId}")]
        Task<object> DeleteIssueLinkTypeAsync([Path] string issueLinkTypeId);

        /// <summary>
        /// Get issue security schemes
        /// </summary>
        [Get("/rest/api/3/issuesecurityschemes")]
        Task<Response<AnyOf<SecuritySchemes, object>>> GetIssueSecuritySchemesAsync();

        /// <summary>
        /// Get issue security scheme
        /// </summary>
        /// <param name="id">The ID of the issue security scheme. Use the [Get issue security schemes](#api-rest-api-3-issuesecurityschemes-get) operation to get a list of issue security scheme IDs.</param>
        [Get("/rest/api/3/issuesecurityschemes/{id}")]
        Task<Response<AnyOf<SecurityScheme, object>>> GetIssueSecuritySchemeAsync([Path] long id);

        /// <summary>
        /// Get issue security level members
        /// </summary>
        /// <param name="issueSecuritySchemeId">The ID of the issue security scheme. Use the [Get issue security schemes](#api-rest-api-3-issuesecurityschemes-get) operation to get a list of issue security scheme IDs.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="issueSecurityLevelId">The list of issue security level IDs. To include multiple issue security levels separate IDs with ampersand: `issueSecurityLevelId=10000&issueSecurityLevelId=10001`.</param>
        /// <param name="expand">Use expand to include additional information in the response. This parameter accepts a comma-separated list. Expand options include: *  `all` Returns all expandable information. *  `field` Returns information about the custom field granted the permission. *  `group` Returns information about the group that is granted the permission. *  `projectRole` Returns information about the project role granted the permission. *  `user` Returns information about the user who is granted the permission.</param>
        [Get("/rest/api/3/issuesecurityschemes/{issueSecuritySchemeId}/members")]
        Task<Response<AnyOf<PageBeanIssueSecurityLevelMember, object>>> GetIssueSecurityLevelMembersAsync([Path] long issueSecuritySchemeId, [Query] long? startAt, [Query] int? maxResults, [Query] long[] issueSecurityLevelId, [Query] string expand);

        /// <summary>
        /// Get all issue types for user
        /// </summary>
        [Get("/rest/api/3/issuetype")]
        Task<Response<AnyOf<IssueTypeDetails[], object>>> GetIssueAllTypesAsync();

        /// <summary>
        /// Create issue type
        /// </summary>
        /// <param name="content"></param>
        [Post("/rest/api/3/issuetype")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<IssueTypeDetails, object>>> CreateIssueTypeAsync([Body] IssueTypeCreateBean content);

        /// <summary>
        /// Get issue types for project
        /// </summary>
        /// <param name="projectId">The ID of the project.</param>
        /// <param name="level">The level of the issue type to filter by. Use: *  `-1` for Subtask. *  `0` for Base. *  `1` for Epic.</param>
        [Get("/rest/api/3/issuetype/project")]
        Task<Response<AnyOf<IssueTypeDetails[], object>>> GetIssueTypesForProjectAsync([Query] long projectId, [Query] int? level);

        /// <summary>
        /// Get issue type
        /// </summary>
        /// <param name="id">The ID of the issue type.</param>
        [Get("/rest/api/3/issuetype/{id}")]
        Task<Response<AnyOf<IssueTypeDetails, object>>> GetIssueTypeAsync([Path] string id);

        /// <summary>
        /// Update issue type
        /// </summary>
        /// <param name="id">The ID of the issue type.</param>
        /// <param name="content"></param>
        [Put("/rest/api/3/issuetype/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<IssueTypeDetails, object>>> UpdateIssueTypeAsync([Path] string id, [Body] IssueTypeUpdateBean content);

        /// <summary>
        /// Delete issue type
        /// </summary>
        /// <param name="id">The ID of the issue type.</param>
        /// <param name="alternativeIssueTypeId">The ID of the replacement issue type.</param>
        [Delete("/rest/api/3/issuetype/{id}")]
        Task<object> DeleteIssueTypeAsync([Path] string id, [Query] string alternativeIssueTypeId);

        /// <summary>
        /// Get alternative issue types
        /// </summary>
        /// <param name="id">The ID of the issue type.</param>
        [Get("/rest/api/3/issuetype/{id}/alternatives")]
        Task<Response<AnyOf<IssueTypeDetails[], object>>> GetAlternativeIssueTypesAsync([Path] string id);

        /// <summary>
        /// Load issue type avatar
        /// </summary>
        /// <param name="id">The ID of the issue type.</param>
        /// <param name="size">The length of each side of the crop region.</param>
        /// <param name="x">The X coordinate of the top-left corner of the crop region.</param>
        /// <param name="y">The Y coordinate of the top-left corner of the crop region.</param>
        [Post("/rest/api/3/issuetype/{id}/avatar2")]
        Task<Response<AnyOf<Avatar, object>>> CreateIssueTypeAvatarAsync([Path] string id, [Query] int size, [Query] int? x, [Query] int? y);

        /// <summary>
        /// Get issue type property keys
        /// </summary>
        /// <param name="issueTypeId">The ID of the issue type.</param>
        [Get("/rest/api/3/issuetype/{issueTypeId}/properties")]
        Task<Response<AnyOf<PropertyKeys, object>>> GetIssueTypePropertyKeysAsync([Path] string issueTypeId);

        /// <summary>
        /// Get issue type property
        /// </summary>
        /// <param name="issueTypeId">The ID of the issue type.</param>
        /// <param name="propertyKey">The key of the property. Use [Get issue type property keys](#api-rest-api-3-issuetype-issueTypeId-properties-get) to get a list of all issue type property keys.</param>
        [Get("/rest/api/3/issuetype/{issueTypeId}/properties/{propertyKey}")]
        Task<Response<AnyOf<EntityProperty, object>>> GetIssueTypePropertyAsync([Path] string issueTypeId, [Path] string propertyKey);

        /// <summary>
        /// Set issue type property
        /// </summary>
        /// <param name="issueTypeId">The ID of the issue type.</param>
        /// <param name="propertyKey">The key of the issue type property. The maximum length is 255 characters.</param>
        [Put("/rest/api/3/issuetype/{issueTypeId}/properties/{propertyKey}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SetIssueTypePropertyResult, object>>> SetIssueTypePropertyAsync([Path] string issueTypeId, [Path] string propertyKey);

        /// <summary>
        /// Delete issue type property
        /// </summary>
        /// <param name="issueTypeId">The ID of the issue type.</param>
        /// <param name="propertyKey">The key of the property. Use [Get issue type property keys](#api-rest-api-3-issuetype-issueTypeId-properties-get) to get a list of all issue type property keys.</param>
        [Delete("/rest/api/3/issuetype/{issueTypeId}/properties/{propertyKey}")]
        Task<object> DeleteIssueTypePropertyAsync([Path] string issueTypeId, [Path] string propertyKey);

        /// <summary>
        /// Get all issue type schemes
        /// </summary>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="id">The list of issue type schemes IDs. To include multiple IDs, provide an ampersand-separated list. For example, `id=10000&id=10001`.</param>
        [Get("/rest/api/3/issuetypescheme")]
        Task<Response<AnyOf<PageBeanIssueTypeScheme, object>>> GetAllIssueTypeSchemesAsync([Query] long? startAt, [Query] int? maxResults, [Query] long[] id);

        /// <summary>
        /// Create issue type scheme
        /// </summary>
        /// <param name="content">Details of an issue type scheme and its associated issue types.</param>
        [Post("/rest/api/3/issuetypescheme")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<IssueTypeSchemeID, object>>> CreateIssueTypeSchemeAsync([Body] IssueTypeSchemeDetails content);

        /// <summary>
        /// Get issue type scheme items
        /// </summary>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="issueTypeSchemeId">The list of issue type scheme IDs. To include multiple IDs, provide an ampersand-separated list. For example, `issueTypeSchemeId=10000&issueTypeSchemeId=10001`.</param>
        [Get("/rest/api/3/issuetypescheme/mapping")]
        Task<Response<AnyOf<PageBeanIssueTypeSchemeMapping, object>>> GetIssueTypeSchemesMappingAsync([Query] long? startAt, [Query] int? maxResults, [Query] long[] issueTypeSchemeId);

        /// <summary>
        /// Get issue type schemes for projects
        /// </summary>
        /// <param name="projectId">The list of project IDs. To include multiple project IDs, provide an ampersand-separated list. For example, `projectId=10000&projectId=10001`.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/issuetypescheme/project")]
        Task<Response<AnyOf<PageBeanIssueTypeSchemeProjects, object>>> GetIssueTypeSchemeForProjectsAsync([Query] long[] projectId, [Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Assign issue type scheme to project
        /// </summary>
        /// <param name="content">Details of the association between an issue type scheme and project.</param>
        [Put("/rest/api/3/issuetypescheme/project")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<AssignIssueTypeSchemeToProjectResult, object>>> AssignIssueTypeSchemeToProjectAsync([Body] IssueTypeSchemeProjectAssociation content);

        /// <summary>
        /// Update issue type scheme
        /// </summary>
        /// <param name="issueTypeSchemeId">The ID of the issue type scheme.</param>
        /// <param name="content">Details of the name, description, and default issue type for an issue type scheme.</param>
        [Put("/rest/api/3/issuetypescheme/{issueTypeSchemeId}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<UpdateIssueTypeSchemeResult, object>>> UpdateIssueTypeSchemeAsync([Path] long issueTypeSchemeId, [Body] IssueTypeSchemeUpdateDetails content);

        /// <summary>
        /// Delete issue type scheme
        /// </summary>
        /// <param name="issueTypeSchemeId">The ID of the issue type scheme.</param>
        [Delete("/rest/api/3/issuetypescheme/{issueTypeSchemeId}")]
        Task<Response<AnyOf<DeleteIssueTypeSchemeResult, object>>> DeleteIssueTypeSchemeAsync([Path] long issueTypeSchemeId);

        /// <summary>
        /// Add issue types to issue type scheme
        /// </summary>
        /// <param name="issueTypeSchemeId">The ID of the issue type scheme.</param>
        /// <param name="content">The list of issue type IDs.</param>
        [Put("/rest/api/3/issuetypescheme/{issueTypeSchemeId}/issuetype")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<AddIssueTypesToIssueTypeSchemeResult, object>>> AddIssueTypesToIssueTypeSchemeAsync([Path] long issueTypeSchemeId, [Body] IssueTypeIds content);

        /// <summary>
        /// Change order of issue types
        /// </summary>
        /// <param name="issueTypeSchemeId">The ID of the issue type scheme.</param>
        /// <param name="content">An ordered list of issue type IDs and information about where to move them.</param>
        [Put("/rest/api/3/issuetypescheme/{issueTypeSchemeId}/issuetype/move")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ReorderIssueTypesInIssueTypeSchemeResult, object>>> ReorderIssueTypesInIssueTypeSchemeAsync([Path] long issueTypeSchemeId, [Body] OrderOfIssueTypes content);

        /// <summary>
        /// Remove issue type from issue type scheme
        /// </summary>
        /// <param name="issueTypeSchemeId">The ID of the issue type scheme.</param>
        /// <param name="issueTypeId">The ID of the issue type.</param>
        [Delete("/rest/api/3/issuetypescheme/{issueTypeSchemeId}/issuetype/{issueTypeId}")]
        Task<Response<AnyOf<RemoveIssueTypeFromIssueTypeSchemeResult, object>>> RemoveIssueTypeFromIssueTypeSchemeAsync([Path] long issueTypeSchemeId, [Path] long issueTypeId);

        /// <summary>
        /// Get issue type screen schemes
        /// </summary>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="id">The list of issue type screen scheme IDs. To include multiple IDs, provide an ampersand-separated list. For example, `id=10000&id=10001`.</param>
        [Get("/rest/api/3/issuetypescreenscheme")]
        Task<Response<AnyOf<PageBeanIssueTypeScreenScheme, object>>> GetIssueTypeScreenSchemesAsync([Query] long? startAt, [Query] int? maxResults, [Query] long[] id);

        /// <summary>
        /// Create issue type screen scheme
        /// </summary>
        /// <param name="content">The details of an issue type screen scheme.</param>
        [Post("/rest/api/3/issuetypescreenscheme")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<IssueTypeScreenSchemeId, object>>> CreateIssueTypeScreenSchemeAsync([Body] IssueTypeScreenSchemeDetails content);

        /// <summary>
        /// Get issue type screen scheme items
        /// </summary>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="issueTypeScreenSchemeId">The list of issue type screen scheme IDs. To include multiple issue type screen schemes, separate IDs with ampersand: `issueTypeScreenSchemeId=10000&issueTypeScreenSchemeId=10001`.</param>
        [Get("/rest/api/3/issuetypescreenscheme/mapping")]
        Task<Response<AnyOf<PageBeanIssueTypeScreenSchemeItem, object>>> GetIssueTypeScreenSchemeMappingsAsync([Query] long? startAt, [Query] int? maxResults, [Query] long[] issueTypeScreenSchemeId);

        /// <summary>
        /// Get issue type screen schemes for projects
        /// </summary>
        /// <param name="projectId">The list of project IDs. To include multiple projects, separate IDs with ampersand: `projectId=10000&projectId=10001`.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/issuetypescreenscheme/project")]
        Task<Response<AnyOf<PageBeanIssueTypeScreenSchemesProjects, object>>> GetIssueTypeScreenSchemeProjectAssociationsAsync([Query] long[] projectId, [Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Assign issue type screen scheme to project
        /// </summary>
        /// <param name="content">Associated issue type screen scheme and project.</param>
        [Put("/rest/api/3/issuetypescreenscheme/project")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<AssignIssueTypeScreenSchemeToProjectResult, object>>> AssignIssueTypeScreenSchemeToProjectAsync([Body] IssueTypeScreenSchemeProjectAssociation content);

        /// <summary>
        /// Update issue type screen scheme
        /// </summary>
        /// <param name="issueTypeScreenSchemeId">The ID of the issue type screen scheme.</param>
        /// <param name="content">Details of an issue type screen scheme.</param>
        [Put("/rest/api/3/issuetypescreenscheme/{issueTypeScreenSchemeId}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<UpdateIssueTypeScreenSchemeResult, object>>> UpdateIssueTypeScreenSchemeAsync([Path] string issueTypeScreenSchemeId, [Body] IssueTypeScreenSchemeUpdateDetails content);

        /// <summary>
        /// Delete issue type screen scheme
        /// </summary>
        /// <param name="issueTypeScreenSchemeId">The ID of the issue type screen scheme.</param>
        [Delete("/rest/api/3/issuetypescreenscheme/{issueTypeScreenSchemeId}")]
        Task<Response<AnyOf<DeleteIssueTypeScreenSchemeResult, object>>> DeleteIssueTypeScreenSchemeAsync([Path] string issueTypeScreenSchemeId);

        /// <summary>
        /// Append mappings to issue type screen scheme
        /// </summary>
        /// <param name="issueTypeScreenSchemeId">The ID of the issue type screen scheme.</param>
        /// <param name="content">A list of issue type screen scheme mappings.</param>
        [Put("/rest/api/3/issuetypescreenscheme/{issueTypeScreenSchemeId}/mapping")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<AppendMappingsForIssueTypeScreenSchemeResult, object>>> AppendMappingsForIssueTypeScreenSchemeAsync([Path] string issueTypeScreenSchemeId, [Body] IssueTypeScreenSchemeMappingDetails content);

        /// <summary>
        /// Update issue type screen scheme default screen scheme
        /// </summary>
        /// <param name="issueTypeScreenSchemeId">The ID of the issue type screen scheme.</param>
        /// <param name="content">The ID of a screen scheme.</param>
        [Put("/rest/api/3/issuetypescreenscheme/{issueTypeScreenSchemeId}/mapping/default")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<UpdateDefaultScreenSchemeResult, object>>> UpdateDefaultScreenSchemeAsync([Path] string issueTypeScreenSchemeId, [Body] UpdateDefaultScreenScheme content);

        /// <summary>
        /// Remove mappings from issue type screen scheme
        /// </summary>
        /// <param name="issueTypeScreenSchemeId">The ID of the issue type screen scheme.</param>
        /// <param name="content">The list of issue type IDs.</param>
        [Post("/rest/api/3/issuetypescreenscheme/{issueTypeScreenSchemeId}/mapping/remove")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<RemoveMappingsFromIssueTypeScreenSchemeResult, object>>> RemoveMappingsFromIssueTypeScreenSchemeAsync([Path] string issueTypeScreenSchemeId, [Body] IssueTypeIds content);

        /// <summary>
        /// Get issue type screen scheme projects
        /// </summary>
        /// <param name="issueTypeScreenSchemeId">The ID of the issue type screen scheme.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/issuetypescreenscheme/{issueTypeScreenSchemeId}/project")]
        Task<Response<AnyOf<PageBeanProjectDetails, object>>> GetProjectsForIssueTypeScreenSchemeAsync([Path] long issueTypeScreenSchemeId, [Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Get field reference data (GET)
        /// </summary>
        [Get("/rest/api/3/jql/autocompletedata")]
        Task<Response<AnyOf<JQLReferenceData, object>>> GetAutoCompleteAsync();

        /// <summary>
        /// Get field reference data (POST)
        /// </summary>
        /// <param name="content">Details of how to filter and list search auto complete information.</param>
        [Post("/rest/api/3/jql/autocompletedata")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<JQLReferenceData, object>>> GetAutoCompletePostAsync([Body] SearchAutoCompleteFilter content);

        /// <summary>
        /// Get field auto complete suggestions
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="fieldValue">The partial field item name entered by the user.</param>
        /// <param name="predicateName">The name of the [ CHANGED operator predicate](https://confluence.atlassian.com/x/hQORLQ#Advancedsearching-operatorsreference-CHANGEDCHANGED) for which the suggestions are generated. The valid predicate operators are *by*, *from*, and *to*.</param>
        /// <param name="predicateValue">The partial predicate item name entered by the user.</param>
        [Get("/rest/api/3/jql/autocompletedata/suggestions")]
        Task<Response<AnyOf<AutoCompleteSuggestions, object>>> GetFieldAutoCompleteForQueryStringAsync([Query] string fieldName, [Query] string fieldValue, [Query] string predicateName, [Query] string predicateValue);

        /// <summary>
        /// Check issues against JQL
        /// </summary>
        /// <param name="content">List of issues and JQL queries.</param>
        [Post("/rest/api/3/jql/match")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<IssueMatches, object>>> MatchIssuesAsync([Body] IssuesAndJQLQueries content);

        /// <summary>
        /// Parse JQL query
        /// </summary>
        /// <param name="content">A list of JQL queries to parse.</param>
        /// <param name="validation">How to validate the JQL query and treat the validation results. Validation options include: *  `strict` Returns all errors. If validation fails, the query structure is not returned. *  `warn` Returns all errors. If validation fails but the JQL query is correctly formed, the query structure is returned. *  `none` No validation is performed. If JQL query is correctly formed, the query structure is returned.</param>
        [Post("/rest/api/3/jql/parse")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ParsedJqlQueries, ErrorCollection, object>>> ParseJqlQueriesAsync([Body] JqlQueriesToParse content, [Query] string validation);

        /// <summary>
        /// Convert user identifiers to account IDs in JQL queries
        /// </summary>
        /// <param name="content">The JQL queries to be converted.</param>
        [Post("/rest/api/3/jql/pdcleaner")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ConvertedJQLQueries, object>>> MigrateQueriesAsync([Body] JQLPersonalDataMigrationRequest content);

        /// <summary>
        /// Get all labels
        /// </summary>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/label")]
        Task<PageBeanString> GetAllLabelsAsync([Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Get my permissions
        /// </summary>
        /// <param name="projectKey">The key of project. Ignored if `projectId` is provided.</param>
        /// <param name="projectId">The ID of project.</param>
        /// <param name="issueKey">The key of the issue. Ignored if `issueId` is provided.</param>
        /// <param name="issueId">The ID of the issue.</param>
        /// <param name="permissions">A list of permission keys. (Required) This parameter accepts a comma-separated list. To get the list of available permissions, use [Get all permissions](#api-rest-api-3-permissions-get).</param>
        /// <param name="projectUuid"></param>
        /// <param name="projectConfigurationUuid"></param>
        [Get("/rest/api/3/mypermissions")]
        Task<Response<AnyOf<Permissions, ErrorCollection>>> GetMyPermissionsAsync([Query] string projectKey, [Query] string projectId, [Query] string issueKey, [Query] string issueId, [Query] string permissions, [Query] string projectUuid, [Query] string projectConfigurationUuid);

        /// <summary>
        /// Get preference
        /// </summary>
        /// <param name="key">The key of the preference.</param>
        [Get("/rest/api/3/mypreferences")]
        Task<Response<AnyOf<string, object>>> GetPreferenceAsync([Query] string key);

        /// <summary>
        /// Set preference
        /// </summary>
        /// <param name="contentType">The Content-Type</param>
        /// <param name="key">The key of the preference. The maximum length is 255 characters.</param>
        [Put("/rest/api/3/mypreferences")]
        Task<Response<AnyOf<SetPreferenceResult, object>>> SetPreferenceAsync([Header("Content-Type")] string contentType, [Query] string key);

        /// <summary>
        /// Delete preference
        /// </summary>
        /// <param name="key">The key of the preference.</param>
        [Delete("/rest/api/3/mypreferences")]
        Task<object> RemovePreferenceAsync([Query] string key);

        /// <summary>
        /// Get locale
        /// </summary>
        [Get("/rest/api/3/mypreferences/locale")]
        Task<Response<AnyOf<Locale, object>>> GetLocaleAsync();

        /// <summary>
        /// Set locale
        /// </summary>
        /// <param name="content">Details of a locale.</param>
        [Put("/rest/api/3/mypreferences/locale")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SetLocaleResult, object>>> SetLocaleAsync([Body] Locale content);

        /// <summary>
        /// Delete locale
        /// </summary>
        [Delete("/rest/api/3/mypreferences/locale")]
        Task<Response<AnyOf<DeleteLocaleResult, object>>> DeleteLocaleAsync();

        /// <summary>
        /// Get current user
        /// </summary>
        /// <param name="expand">Use [expand](#expansion) to include additional information about user in the response. This parameter accepts a comma-separated list. Expand options include: *  `groups` Returns all groups, including nested groups, the user belongs to. *  `applicationRoles` Returns the application roles the user is assigned to.</param>
        [Get("/rest/api/3/myself")]
        Task<Response<AnyOf<User, object>>> GetCurrentUserAsync([Query] string expand);

        /// <summary>
        /// Get notification schemes paginated
        /// </summary>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information in the response. This parameter accepts a comma-separated list. Expand options include: *  `all` Returns all expandable information. *  `field` Returns information about any custom fields assigned to receive an event. *  `group` Returns information about any groups assigned to receive an event. *  `notificationSchemeEvents` Returns a list of event associations. This list is returned for all expandable information. *  `projectRole` Returns information about any project roles assigned to receive an event. *  `user` Returns information about any users assigned to receive an event.</param>
        [Get("/rest/api/3/notificationscheme")]
        Task<Response<AnyOf<PageBeanNotificationScheme, object>>> GetNotificationSchemesAsync([Query] long? startAt, [Query] int? maxResults, [Query] string expand);

        /// <summary>
        /// Get notification scheme
        /// </summary>
        /// <param name="id">The ID of the notification scheme. Use [Get notification schemes paginated](#api-rest-api-3-notificationscheme-get) to get a list of notification scheme IDs.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information in the response. This parameter accepts a comma-separated list. Expand options include: *  `all` Returns all expandable information. *  `field` Returns information about any custom fields assigned to receive an event. *  `group` Returns information about any groups assigned to receive an event. *  `notificationSchemeEvents` Returns a list of event associations. This list is returned for all expandable information. *  `projectRole` Returns information about any project roles assigned to receive an event. *  `user` Returns information about any users assigned to receive an event.</param>
        [Get("/rest/api/3/notificationscheme/{id}")]
        Task<Response<AnyOf<NotificationScheme, object>>> GetNotificationSchemeAsync([Path] long id, [Query] string expand);

        /// <summary>
        /// Get all permissions
        /// </summary>
        [Get("/rest/api/3/permissions")]
        Task<Response<AnyOf<Permissions, object>>> GetAllPermissionsAsync();

        /// <summary>
        /// Get bulk permissions
        /// </summary>
        /// <param name="content">Details of global permissions to look up and project permissions with associated projects and issues to look up.</param>
        [Post("/rest/api/3/permissions/check")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<BulkPermissionGrants, ErrorCollection>>> GetBulkPermissionsAsync([Body] BulkPermissionsRequestBean content);

        /// <summary>
        /// Get permitted projects
        /// </summary>
        /// <param name="content"></param>
        [Post("/rest/api/3/permissions/project")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PermittedProjects, object>>> GetPermittedProjectsAsync([Body] PermissionsKeysBean content);

        /// <summary>
        /// Get all permission schemes
        /// </summary>
        /// <param name="expand">Use expand to include additional information in the response. This parameter accepts a comma-separated list. Note that permissions are included when you specify any value. Expand options include: *  `all` Returns all expandable information. *  `field` Returns information about the custom field granted the permission. *  `group` Returns information about the group that is granted the permission. *  `permissions` Returns all permission grants for each permission scheme. *  `projectRole` Returns information about the project role granted the permission. *  `user` Returns information about the user who is granted the permission.</param>
        [Get("/rest/api/3/permissionscheme")]
        Task<Response<AnyOf<PermissionSchemes, object>>> GetAllPermissionSchemesAsync([Query] string expand);

        /// <summary>
        /// Create permission scheme
        /// </summary>
        /// <param name="content">Details of a permission scheme.</param>
        /// <param name="expand">Use expand to include additional information in the response. This parameter accepts a comma-separated list. Note that permissions are always included when you specify any value. Expand options include: *  `all` Returns all expandable information. *  `field` Returns information about the custom field granted the permission. *  `group` Returns information about the group that is granted the permission. *  `permissions` Returns all permission grants for each permission scheme. *  `projectRole` Returns information about the project role granted the permission. *  `user` Returns information about the user who is granted the permission.</param>
        [Post("/rest/api/3/permissionscheme")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PermissionScheme, object>>> CreatePermissionSchemeAsync([Body] PermissionScheme content, [Query] string expand);

        /// <summary>
        /// Get permission scheme
        /// </summary>
        /// <param name="schemeId">The ID of the permission scheme to return.</param>
        /// <param name="expand">Use expand to include additional information in the response. This parameter accepts a comma-separated list. Note that permissions are included when you specify any value. Expand options include: *  `all` Returns all expandable information. *  `field` Returns information about the custom field granted the permission. *  `group` Returns information about the group that is granted the permission. *  `permissions` Returns all permission grants for each permission scheme. *  `projectRole` Returns information about the project role granted the permission. *  `user` Returns information about the user who is granted the permission.</param>
        [Get("/rest/api/3/permissionscheme/{schemeId}")]
        Task<Response<AnyOf<PermissionScheme, object>>> GetPermissionSchemeAsync([Path] long schemeId, [Query] string expand);

        /// <summary>
        /// Update permission scheme
        /// </summary>
        /// <param name="schemeId">The ID of the permission scheme to update.</param>
        /// <param name="content">Details of a permission scheme.</param>
        /// <param name="expand">Use expand to include additional information in the response. This parameter accepts a comma-separated list. Note that permissions are always included when you specify any value. Expand options include: *  `all` Returns all expandable information. *  `field` Returns information about the custom field granted the permission. *  `group` Returns information about the group that is granted the permission. *  `permissions` Returns all permission grants for each permission scheme. *  `projectRole` Returns information about the project role granted the permission. *  `user` Returns information about the user who is granted the permission.</param>
        [Put("/rest/api/3/permissionscheme/{schemeId}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PermissionScheme, object>>> UpdatePermissionSchemeAsync([Path] long schemeId, [Body] PermissionScheme content, [Query] string expand);

        /// <summary>
        /// Delete permission scheme
        /// </summary>
        /// <param name="schemeId">The ID of the permission scheme being deleted.</param>
        [Delete("/rest/api/3/permissionscheme/{schemeId}")]
        Task<object> DeletePermissionSchemeAsync([Path] long schemeId);

        /// <summary>
        /// Get permission scheme grants
        /// </summary>
        /// <param name="schemeId">The ID of the permission scheme.</param>
        /// <param name="expand">Use expand to include additional information in the response. This parameter accepts a comma-separated list. Note that permissions are always included when you specify any value. Expand options include: *  `permissions` Returns all permission grants for each permission scheme. *  `user` Returns information about the user who is granted the permission. *  `group` Returns information about the group that is granted the permission. *  `projectRole` Returns information about the project role granted the permission. *  `field` Returns information about the custom field granted the permission. *  `all` Returns all expandable information.</param>
        [Get("/rest/api/3/permissionscheme/{schemeId}/permission")]
        Task<Response<AnyOf<PermissionGrants, object>>> GetPermissionSchemeGrantsAsync([Path] long schemeId, [Query] string expand);

        /// <summary>
        /// Create permission grant
        /// </summary>
        /// <param name="schemeId">The ID of the permission scheme in which to create a new permission grant.</param>
        /// <param name="content">Details about a permission granted to a user or group.</param>
        /// <param name="expand">Use expand to include additional information in the response. This parameter accepts a comma-separated list. Note that permissions are always included when you specify any value. Expand options include: *  `permissions` Returns all permission grants for each permission scheme. *  `user` Returns information about the user who is granted the permission. *  `group` Returns information about the group that is granted the permission. *  `projectRole` Returns information about the project role granted the permission. *  `field` Returns information about the custom field granted the permission. *  `all` Returns all expandable information.</param>
        [Post("/rest/api/3/permissionscheme/{schemeId}/permission")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PermissionGrant, object>>> CreatePermissionGrantAsync([Path] long schemeId, [Body] PermissionGrant content, [Query] string expand);

        /// <summary>
        /// Get permission scheme grant
        /// </summary>
        /// <param name="schemeId">The ID of the permission scheme.</param>
        /// <param name="permissionId">The ID of the permission grant.</param>
        /// <param name="expand">Use expand to include additional information in the response. This parameter accepts a comma-separated list. Note that permissions are always included when you specify any value. Expand options include: *  `all` Returns all expandable information. *  `field` Returns information about the custom field granted the permission. *  `group` Returns information about the group that is granted the permission. *  `permissions` Returns all permission grants for each permission scheme. *  `projectRole` Returns information about the project role granted the permission. *  `user` Returns information about the user who is granted the permission.</param>
        [Get("/rest/api/3/permissionscheme/{schemeId}/permission/{permissionId}")]
        Task<Response<AnyOf<PermissionGrant, object>>> GetPermissionSchemeGrantAsync([Path] long schemeId, [Path] long permissionId, [Query] string expand);

        /// <summary>
        /// Delete permission scheme grant
        /// </summary>
        /// <param name="schemeId">The ID of the permission scheme to delete the permission grant from.</param>
        /// <param name="permissionId">The ID of the permission grant to delete.</param>
        [Delete("/rest/api/3/permissionscheme/{schemeId}/permission/{permissionId}")]
        Task<object> DeletePermissionSchemeEntityAsync([Path] long schemeId, [Path] long permissionId);

        /// <summary>
        /// Get priorities
        /// </summary>
        [Get("/rest/api/3/priority")]
        Task<Response<AnyOf<Priority[], object>>> GetPrioritiesAsync();

        /// <summary>
        /// Get priority
        /// </summary>
        /// <param name="id">The ID of the issue priority.</param>
        [Get("/rest/api/3/priority/{id}")]
        Task<Response<AnyOf<Priority, object>>> GetPriorityAsync([Path] string id);

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <param name="expand">Use [expand](#expansion) to include additional information in the response. This parameter accepts a comma-separated list. Expanded options include: *  `description` Returns the project description. *  `issueTypes` Returns all issue types associated with the project. *  `lead` Returns information about the project lead. *  `projectKeys` Returns all project keys associated with the project.</param>
        /// <param name="recent">Returns the user's most recently accessed projects. You may specify the number of results to return up to a maximum of 20. If access is anonymous, then the recently accessed projects are based on the current HTTP session.</param>
        /// <param name="properties">A list of project properties to return for the project. This parameter accepts a comma-separated list.</param>
        [Get("/rest/api/3/project")]
        Task<Response<AnyOf<Project[], object>>> GetAllProjectsAsync([Query] string expand, [Query] int? recent, [Query] string[] properties);

        /// <summary>
        /// Create project
        /// </summary>
        /// <param name="content">Details about the project.</param>
        [Post("/rest/api/3/project")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ProjectIdentifiers, object>>> CreateProjectAsync([Body] CreateProjectDetails content);

        /// <summary>
        /// Get recent projects
        /// </summary>
        /// <param name="expand">Use [expand](#expansion) to include additional information in the response. This parameter accepts a comma-separated list. Expanded options include: *  `description` Returns the project description. *  `projectKeys` Returns all project keys associated with a project. *  `lead` Returns information about the project lead. *  `issueTypes` Returns all issue types associated with the project. *  `url` Returns the URL associated with the project. *  `permissions` Returns the permissions associated with the project. *  `insight` EXPERIMENTAL. Returns the insight details of total issue count and last issue update time for the project. *  `*` Returns the project with all available expand options.</param>
        /// <param name="properties">EXPERIMENTAL. A list of project properties to return for the project. This parameter accepts a comma-separated list. Invalid property names are ignored.</param>
        [Get("/rest/api/3/project/recent")]
        Task<Response<AnyOf<Project[], object>>> GetRecentAsync([Query] string expand, [Query] StringList[] properties);

        /// <summary>
        /// Get projects paginated
        /// </summary>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="orderBy">[Order](#ordering) the results by a field. *  `category` Sorts by project category. A complete list of category IDs is found using [Get all project categories](#api-rest-api-3-projectCategory-get). *  `issueCount` Sorts by the total number of issues in each project. *  `key` Sorts by project key. *  `lastIssueUpdatedTime` Sorts by the last issue update time. *  `name` Sorts by project name. *  `owner` Sorts by project lead. *  `archivedDate` EXPERIMENTAL. Sorts by project archived date. *  `deletedDate` EXPERIMENTAL. Sorts by project deleted date.</param>
        /// <param name="id">The project IDs to filter the results by. To include multiple IDs, provide an ampersand-separated list. For example, `id=10000&id=10001`. Up to 50 project IDs can be provided.</param>
        /// <param name="keys">The project keys to filter the results by. To include multiple keys, provide an ampersand-separated list. For example, `keys=PA&keys=PB`. Up to 50 project keys can be provided.</param>
        /// <param name="query">Filter the results using a literal string. Projects with a matching `key` or `name` are returned (case insensitive).</param>
        /// <param name="typeKey">Orders results by the [project type](https://confluence.atlassian.com/x/GwiiLQ#Jiraapplicationsoverview-Productfeaturesandprojecttypes). This parameter accepts a comma-separated list. Valid values are `business`, `service_desk`, and `software`.</param>
        /// <param name="categoryId">The ID of the project's category. A complete list of category IDs is found using the [Get all project categories](#api-rest-api-3-projectCategory-get) operation.</param>
        /// <param name="action">Filter results by projects for which the user can: *  `view` the project, meaning that they have one of the following permissions:         *  *Browse projects* [project permission](https://confluence.atlassian.com/x/yodKLg) for the project.     *  *Administer projects* [project permission](https://confluence.atlassian.com/x/yodKLg) for the project.     *  *Administer Jira* [global permission](https://confluence.atlassian.com/x/x4dKLg). *  `browse` the project, meaning that they have the *Browse projects* [project permission](https://confluence.atlassian.com/x/yodKLg) for the project. *  `edit` the project, meaning that they have one of the following permissions:         *  *Administer projects* [project permission](https://confluence.atlassian.com/x/yodKLg) for the project.     *  *Administer Jira* [global permission](https://confluence.atlassian.com/x/x4dKLg).</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information in the response. This parameter accepts a comma-separated list. Expanded options include: *  `description` Returns the project description. *  `projectKeys` Returns all project keys associated with a project. *  `lead` Returns information about the project lead. *  `issueTypes` Returns all issue types associated with the project. *  `url` Returns the URL associated with the project. *  `insight` EXPERIMENTAL. Returns the insight details of total issue count and last issue update time for the project.</param>
        /// <param name="status">EXPERIMENTAL. Filter results by project status: *  `live` Search live projects. *  `archived` Search archived projects. *  `deleted` Search deleted projects, those in the recycle bin.</param>
        /// <param name="properties">EXPERIMENTAL. A list of project properties to return for the project. This parameter accepts a comma-separated list.</param>
        /// <param name="propertyQuery">EXPERIMENTAL. A query string used to search properties. The query string cannot be specified using a JSON object. For example, to search for the value of `nested` from `{"something":{"nested":1,"other":2}}` use `[thepropertykey].something.nested=1`. Note that the propertyQuery key is enclosed in square brackets to enable searching where the propertyQuery key includes dot (.) or equals (=) characters. Note that `thepropertykey` is only returned when included in `properties`.</param>
        [Get("/rest/api/3/project/search")]
        Task<Response<AnyOf<PageBeanProject, object>>> SearchProjectsAsync([Query] long? startAt, [Query] int? maxResults, [Query] string orderBy, [Query] long[] id, [Query] string[] keys, [Query] string query, [Query] string typeKey, [Query] long? categoryId, [Query] string action, [Query] string expand, [Query] string[] status, [Query] StringList[] properties, [Query] string propertyQuery);

        /// <summary>
        /// Get all project types
        /// </summary>
        [Get("/rest/api/3/project/type")]
        Task<Response<AnyOf<ProjectType[], object>>> GetAllProjectTypesAsync();

        /// <summary>
        /// Get licensed project types
        /// </summary>
        [Get("/rest/api/3/project/type/accessible")]
        Task<ProjectType[]> GetAllAccessibleProjectTypesAsync();

        /// <summary>
        /// Get project type by key
        /// </summary>
        /// <param name="projectTypeKey">The key of the project type.</param>
        [Get("/rest/api/3/project/type/{projectTypeKey}")]
        Task<Response<AnyOf<ProjectType, object>>> GetProjectTypeByKeyAsync([Path] string projectTypeKey);

        /// <summary>
        /// Get accessible project type by key
        /// </summary>
        /// <param name="projectTypeKey">The key of the project type.</param>
        [Get("/rest/api/3/project/type/{projectTypeKey}/accessible")]
        Task<Response<AnyOf<ProjectType, object>>> GetAccessibleProjectTypeByKeyAsync([Path] string projectTypeKey);

        /// <summary>
        /// Get project
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information in the response. This parameter accepts a comma-separated list. Note that the project description, issue types, and project lead are included in all responses by default. Expand options include: *  `description` The project description. *  `issueTypes` The issue types associated with the project. *  `lead` The project lead. *  `projectKeys` All project keys associated with the project. *  `issueTypeHierarchy` The project issue type hierarchy.</param>
        /// <param name="properties">A list of project properties to return for the project. This parameter accepts a comma-separated list.</param>
        [Get("/rest/api/3/project/{projectIdOrKey}")]
        Task<Response<AnyOf<Project, object>>> GetProjectAsync([Path] string projectIdOrKey, [Query] string expand, [Query] string[] properties);

        /// <summary>
        /// Update project
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// <param name="content">Details about the project.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information in the response. This parameter accepts a comma-separated list. Note that the project description, issue types, and project lead are included in all responses by default. Expand options include: *  `description` The project description. *  `issueTypes` The issue types associated with the project. *  `lead` The project lead. *  `projectKeys` All project keys associated with the project.</param>
        [Put("/rest/api/3/project/{projectIdOrKey}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Project, object>>> UpdateProjectAsync([Path] string projectIdOrKey, [Body] UpdateProjectDetails content, [Query] string expand);

        /// <summary>
        /// Delete project
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// <param name="enableUndo">Whether this project is placed in the Jira recycle bin where it will be available for restoration.</param>
        [Delete("/rest/api/3/project/{projectIdOrKey}")]
        Task<object> DeleteProjectAsync([Path] string projectIdOrKey, [Query] bool? enableUndo);

        /// <summary>
        /// Archive project
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        [Post("/rest/api/3/project/{projectIdOrKey}/archive")]
        Task<Response<AnyOf<ArchiveProjectResult, object>>> ArchiveProjectAsync([Path] string projectIdOrKey);

        /// <summary>
        /// Set project avatar
        /// </summary>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="content">Details of an avatar.</param>
        [Put("/rest/api/3/project/{projectIdOrKey}/avatar")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<UpdateProjectAvatarResult, object>>> UpdateProjectAvatarAsync([Path] string projectIdOrKey, [Body] Avatar content);

        /// <summary>
        /// Delete project avatar
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or (case-sensitive) key.</param>
        /// <param name="id">The ID of the avatar.</param>
        [Delete("/rest/api/3/project/{projectIdOrKey}/avatar/{id}")]
        Task<object> DeleteProjectAvatarAsync([Path] string projectIdOrKey, [Path] long id);

        /// <summary>
        /// Load project avatar
        /// </summary>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="x">The X coordinate of the top-left corner of the crop region.</param>
        /// <param name="y">The Y coordinate of the top-left corner of the crop region.</param>
        /// <param name="size">The length of each side of the crop region.</param>
        [Post("/rest/api/3/project/{projectIdOrKey}/avatar2")]
        Task<Response<AnyOf<Avatar, object>>> CreateProjectAvatarAsync([Path] string projectIdOrKey, [Query] int? x, [Query] int? y, [Query] int? size);

        /// <summary>
        /// Get all project avatars
        /// </summary>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        [Get("/rest/api/3/project/{projectIdOrKey}/avatars")]
        Task<Response<AnyOf<ProjectAvatars, object>>> GetAllProjectAvatarsAsync([Path] string projectIdOrKey);

        /// <summary>
        /// Get project components paginated
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="orderBy">[Order](#ordering) the results by a field: *  `description` Sorts by the component description. *  `issueCount` Sorts by the count of issues associated with the component. *  `lead` Sorts by the user key of the component's project lead. *  `name` Sorts by component name.</param>
        /// <param name="query">Filter the results using a literal string. Components with a matching `name` or `description` are returned (case insensitive).</param>
        [Get("/rest/api/3/project/{projectIdOrKey}/component")]
        Task<Response<AnyOf<PageBeanComponentWithIssueCount, object>>> GetProjectComponentsPaginatedAsync([Path] string projectIdOrKey, [Query] long? startAt, [Query] int? maxResults, [Query] string orderBy, [Query] string query);

        /// <summary>
        /// Get project components
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        [Get("/rest/api/3/project/{projectIdOrKey}/components")]
        Task<Response<AnyOf<ProjectComponent[], object>>> GetProjectComponentsAsync([Path] string projectIdOrKey);

        /// <summary>
        /// Delete project asynchronously
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        [Post("/rest/api/3/project/{projectIdOrKey}/delete")]
        Task<Response<AnyOf<TaskProgressBeanObject, object>>> DeleteProjectAsynchronouslyAsync([Path] string projectIdOrKey);

        /// <summary>
        /// Get project features
        /// </summary>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        [Get("/rest/api/3/project/{projectIdOrKey}/features")]
        Task<Response<AnyOf<ContainerForProjectFeatures, object>>> GetFeaturesForProjectAsync([Path] string projectIdOrKey);

        /// <summary>
        /// Set project feature state
        /// </summary>
        /// <param name="projectIdOrKey">The ID or (case-sensitive) key of the project.</param>
        /// <param name="featureKey">The key of the feature.</param>
        /// <param name="content">Details of the feature state.</param>
        [Put("/rest/api/3/project/{projectIdOrKey}/features/{featureKey}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ContainerForProjectFeatures, object>>> ToggleFeatureForProjectAsync([Path] string projectIdOrKey, [Path] string featureKey, [Body] ProjectFeatureState content);

        /// <summary>
        /// Get project property keys
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        [Get("/rest/api/3/project/{projectIdOrKey}/properties")]
        Task<Response<AnyOf<PropertyKeys, object>>> GetProjectPropertyKeysAsync([Path] string projectIdOrKey);

        /// <summary>
        /// Get project property
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// <param name="propertyKey">The project property key. Use [Get project property keys](#api-rest-api-3-project-projectIdOrKey-properties-get) to get a list of all project property keys.</param>
        [Get("/rest/api/3/project/{projectIdOrKey}/properties/{propertyKey}")]
        Task<Response<AnyOf<EntityProperty, object>>> GetProjectPropertyAsync([Path] string projectIdOrKey, [Path] string propertyKey);

        /// <summary>
        /// Set project property
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// <param name="propertyKey">The key of the project property. The maximum length is 255 characters.</param>
        [Put("/rest/api/3/project/{projectIdOrKey}/properties/{propertyKey}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SetProjectPropertyResult, object>>> SetProjectPropertyAsync([Path] string projectIdOrKey, [Path] string propertyKey);

        /// <summary>
        /// Delete project property
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// <param name="propertyKey">The project property key. Use [Get project property keys](#api-rest-api-3-project-projectIdOrKey-properties-get) to get a list of all project property keys.</param>
        [Delete("/rest/api/3/project/{projectIdOrKey}/properties/{propertyKey}")]
        Task<object> DeleteProjectPropertyAsync([Path] string projectIdOrKey, [Path] string propertyKey);

        /// <summary>
        /// Restore deleted project
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        [Post("/rest/api/3/project/{projectIdOrKey}/restore")]
        Task<Response<AnyOf<Project, object>>> RestoreAsync([Path] string projectIdOrKey);

        /// <summary>
        /// Get project roles for project
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        [Get("/rest/api/3/project/{projectIdOrKey}/role")]
        Task<Response<AnyOf<string, object>>> GetProjectRolesAsync([Path] string projectIdOrKey);

        /// <summary>
        /// Get project role for project
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// <param name="id">The ID of the project role. Use [Get all project roles](#api-rest-api-3-role-get) to get a list of project role IDs.</param>
        [Get("/rest/api/3/project/{projectIdOrKey}/role/{id}")]
        Task<Response<AnyOf<ProjectRole, object>>> GetProjectRoleAsync([Path] string projectIdOrKey, [Path] long id);

        /// <summary>
        /// Set actors for project role
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// <param name="id">The ID of the project role. Use [Get all project roles](#api-rest-api-3-role-get) to get a list of project role IDs.</param>
        /// <param name="content">The groups or users to associate with the project role for this project. Provide the user account ID or group name.</param>
        [Put("/rest/api/3/project/{projectIdOrKey}/role/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ProjectRole, object>>> SetActorsAsync([Path] string projectIdOrKey, [Path] long id, [Body] ProjectRoleActorsUpdateBean content);

        /// <summary>
        /// Add actors to project role
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// <param name="id">The ID of the project role. Use [Get all project roles](#api-rest-api-3-role-get) to get a list of project role IDs.</param>
        /// <param name="content">The groups or users to associate with the project role for this project. Provide the user account ID or group name.</param>
        [Post("/rest/api/3/project/{projectIdOrKey}/role/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ProjectRole, object>>> AddActorUsersAsync([Path] string projectIdOrKey, [Path] long id, [Body] ActorsMap content);

        /// <summary>
        /// Delete actors from project role
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// <param name="id">The ID of the project role. Use [Get all project roles](#api-rest-api-3-role-get) to get a list of project role IDs.</param>
        /// <param name="user">The user account ID of the user to remove from the project role.</param>
        /// <param name="xfa2020ad bc50 408f 9eba f6938d11dc16">The name of the group to remove from the project role.</param>
        [Delete("/rest/api/3/project/{projectIdOrKey}/role/{id}")]
        Task<object> DeleteActorAsync([Path] string projectIdOrKey, [Path] long id, [Query] string user, [Query(Name = "group")] string xfa2020ad bc50 408f 9eba f6938d11dc16);

        /// <summary>
        /// Get project role details
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// <param name="currentMember">Whether the roles should be filtered to include only those the user is assigned to.</param>
        /// <param name="excludeConnectAddons"></param>
        [Get("/rest/api/3/project/{projectIdOrKey}/roledetails")]
        Task<Response<AnyOf<ProjectRoleDetails[], object>>> GetProjectRoleDetailsAsync([Path] string projectIdOrKey, [Query] bool? currentMember, [Query] bool? excludeConnectAddons);

        /// <summary>
        /// Get all statuses for project
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        [Get("/rest/api/3/project/{projectIdOrKey}/statuses")]
        Task<Response<AnyOf<IssueTypeWithStatus[], object>>> GetAllStatusesAsync([Path] string projectIdOrKey);

        /// <summary>
        /// Update project type
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// <param name="newProjectTypeKey">The key of the new project type.</param>
        [Put("/rest/api/3/project/{projectIdOrKey}/type/{newProjectTypeKey}")]
        Task<Response<AnyOf<Project, object>>> UpdateProjectTypeAsync([Path] string projectIdOrKey, [Path] string newProjectTypeKey);

        /// <summary>
        /// Get project versions paginated
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="orderBy">[Order](#ordering) the results by a field: *  `description` Sorts by version description. *  `name` Sorts by version name. *  `releaseDate` Sorts by release date, starting with the oldest date. Versions with no release date are listed last. *  `sequence` Sorts by the order of appearance in the user interface. *  `startDate` Sorts by start date, starting with the oldest date. Versions with no start date are listed last.</param>
        /// <param name="query">Filter the results using a literal string. Versions with matching `name` or `description` are returned (case insensitive).</param>
        /// <param name="status">A list of status values used to filter the results by version status. This parameter accepts a comma-separated list. The status values are `released`, `unreleased`, and `archived`.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information in the response. This parameter accepts a comma-separated list. Expand options include: *  `issuesstatus` Returns the number of issues in each status category for each version. *  `operations` Returns actions that can be performed on the specified version.</param>
        [Get("/rest/api/3/project/{projectIdOrKey}/version")]
        Task<Response<AnyOf<PageBeanVersion, object>>> GetProjectVersionsPaginatedAsync([Path] string projectIdOrKey, [Query] long? startAt, [Query] int? maxResults, [Query] string orderBy, [Query] string query, [Query] string status, [Query] string expand);

        /// <summary>
        /// Get project versions
        /// </summary>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information in the response. This parameter accepts `operations`, which returns actions that can be performed on the version.</param>
        [Get("/rest/api/3/project/{projectIdOrKey}/versions")]
        Task<Response<AnyOf<Version[], object>>> GetProjectVersionsAsync([Path] string projectIdOrKey, [Query] string expand);

        /// <summary>
        /// Get project's sender email
        /// </summary>
        /// <param name="projectId">The project ID.</param>
        [Get("/rest/api/3/project/{projectId}/email")]
        Task<Response<AnyOf<ProjectEmailAddress, object>>> GetProjectEmailAsync([Path] long projectId);

        /// <summary>
        /// Set project's sender email
        /// </summary>
        /// <param name="projectId">The project ID.</param>
        /// <param name="content">A project's sender email address.</param>
        [Put("/rest/api/3/project/{projectId}/email")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<UpdateProjectEmailResult, object>>> UpdateProjectEmailAsync([Path] long projectId, [Body] ProjectEmailAddress content);

        /// <summary>
        /// Get project issue type hierarchy
        /// </summary>
        /// <param name="projectId">The ID of the project.</param>
        [Get("/rest/api/3/project/{projectId}/hierarchy")]
        Task<Response<AnyOf<ProjectIssueTypeHierarchy, object>>> GetHierarchyAsync([Path] long projectId);

        /// <summary>
        /// Get project issue security scheme
        /// </summary>
        /// <param name="projectKeyOrId">The project ID or project key (case sensitive).</param>
        [Get("/rest/api/3/project/{projectKeyOrId}/issuesecuritylevelscheme")]
        Task<Response<AnyOf<SecurityScheme, object>>> GetProjectIssueSecuritySchemeAsync([Path] string projectKeyOrId);

        /// <summary>
        /// Get project notification scheme
        /// </summary>
        /// <param name="projectKeyOrId">The project ID or project key (case sensitive).</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information in the response. This parameter accepts a comma-separated list. Expand options include: *  `all` Returns all expandable information. *  `field` Returns information about any custom fields assigned to receive an event. *  `group` Returns information about any groups assigned to receive an event. *  `notificationSchemeEvents` Returns a list of event associations. This list is returned for all expandable information. *  `projectRole` Returns information about any project roles assigned to receive an event. *  `user` Returns information about any users assigned to receive an event.</param>
        [Get("/rest/api/3/project/{projectKeyOrId}/notificationscheme")]
        Task<Response<AnyOf<NotificationScheme, object>>> GetNotificationSchemeForProjectAsync([Path] string projectKeyOrId, [Query] string expand);

        /// <summary>
        /// Get assigned permission scheme
        /// </summary>
        /// <param name="projectKeyOrId">The project ID or project key (case sensitive).</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information in the response. This parameter accepts a comma-separated list. Note that permissions are included when you specify any value. Expand options include: *  `all` Returns all expandable information. *  `field` Returns information about the custom field granted the permission. *  `group` Returns information about the group that is granted the permission. *  `permissions` Returns all permission grants for each permission scheme. *  `projectRole` Returns information about the project role granted the permission. *  `user` Returns information about the user who is granted the permission.</param>
        [Get("/rest/api/3/project/{projectKeyOrId}/permissionscheme")]
        Task<Response<AnyOf<PermissionScheme, object>>> GetAssignedPermissionSchemeAsync([Path] string projectKeyOrId, [Query] string expand);

        /// <summary>
        /// Assign permission scheme
        /// </summary>
        /// <param name="projectKeyOrId">The project ID or project key (case sensitive).</param>
        /// <param name="content"></param>
        /// <param name="expand">Use [expand](#expansion) to include additional information in the response. This parameter accepts a comma-separated list. Note that permissions are included when you specify any value. Expand options include: *  `all` Returns all expandable information. *  `field` Returns information about the custom field granted the permission. *  `group` Returns information about the group that is granted the permission. *  `permissions` Returns all permission grants for each permission scheme. *  `projectRole` Returns information about the project role granted the permission. *  `user` Returns information about the user who is granted the permission.</param>
        [Put("/rest/api/3/project/{projectKeyOrId}/permissionscheme")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<PermissionScheme, object>>> AssignPermissionSchemeAsync([Path] string projectKeyOrId, [Body] IdBean content, [Query] string expand);

        /// <summary>
        /// Get project issue security levels
        /// </summary>
        /// <param name="projectKeyOrId">The project ID or project key (case sensitive).</param>
        [Get("/rest/api/3/project/{projectKeyOrId}/securitylevel")]
        Task<Response<AnyOf<ProjectIssueSecurityLevels, object>>> GetSecurityLevelsForProjectAsync([Path] string projectKeyOrId);

        /// <summary>
        /// Get all project categories
        /// </summary>
        [Get("/rest/api/3/projectCategory")]
        Task<Response<AnyOf<ProjectCategory[], object>>> GetAllProjectCategoriesAsync();

        /// <summary>
        /// Create project category
        /// </summary>
        /// <param name="content">A project category.</param>
        [Post("/rest/api/3/projectCategory")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ProjectCategory, object>>> CreateProjectCategoryAsync([Body] ProjectCategory content);

        /// <summary>
        /// Get project category by ID
        /// </summary>
        /// <param name="id">The ID of the project category.</param>
        [Get("/rest/api/3/projectCategory/{id}")]
        Task<Response<AnyOf<ProjectCategory, object>>> GetProjectCategoryByIdAsync([Path] long id);

        /// <summary>
        /// Update project category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="content">A project category.</param>
        [Put("/rest/api/3/projectCategory/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<UpdatedProjectCategory, object>>> UpdateProjectCategoryAsync([Path] long id, [Body] ProjectCategory content);

        /// <summary>
        /// Delete project category
        /// </summary>
        /// <param name="id">ID of the project category to delete.</param>
        [Delete("/rest/api/3/projectCategory/{id}")]
        Task<object> RemoveProjectCategoryAsync([Path] long id);

        /// <summary>
        /// Validate project key
        /// </summary>
        /// <param name="key">The project key.</param>
        [Get("/rest/api/3/projectvalidate/key")]
        Task<Response<AnyOf<ErrorCollection, object>>> ValidateProjectKeyAsync([Query] string key);

        /// <summary>
        /// Get valid project key
        /// </summary>
        /// <param name="key">The project key.</param>
        [Get("/rest/api/3/projectvalidate/validProjectKey")]
        Task<Response<AnyOf<string, object>>> GetValidProjectKeyAsync([Query] string key);

        /// <summary>
        /// Get valid project name
        /// </summary>
        /// <param name="name">The project name.</param>
        [Get("/rest/api/3/projectvalidate/validProjectName")]
        Task<Response<AnyOf<string, object>>> GetValidProjectNameAsync([Query] string name);

        /// <summary>
        /// Get resolutions
        /// </summary>
        [Get("/rest/api/3/resolution")]
        Task<Response<AnyOf<Resolution[], object>>> GetResolutionsAsync();

        /// <summary>
        /// Get resolution
        /// </summary>
        /// <param name="id">The ID of the issue resolution value.</param>
        [Get("/rest/api/3/resolution/{id}")]
        Task<Response<AnyOf<Resolution, object>>> GetResolutionAsync([Path] string id);

        /// <summary>
        /// Get all project roles
        /// </summary>
        [Get("/rest/api/3/role")]
        Task<Response<AnyOf<ProjectRole[], object>>> GetAllProjectRolesAsync();

        /// <summary>
        /// Create project role
        /// </summary>
        /// <param name="content"></param>
        [Post("/rest/api/3/role")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ProjectRole, object>>> CreateProjectRoleAsync([Body] CreateUpdateRoleRequestBean content);

        /// <summary>
        /// Get project role by ID
        /// </summary>
        /// <param name="id">The ID of the project role. Use [Get all project roles](#api-rest-api-3-role-get) to get a list of project role IDs.</param>
        [Get("/rest/api/3/role/{id}")]
        Task<Response<AnyOf<ProjectRole, object>>> GetProjectRoleByIdAsync([Path] long id);

        /// <summary>
        /// Fully update project role
        /// </summary>
        /// <param name="id">The ID of the project role. Use [Get all project roles](#api-rest-api-3-role-get) to get a list of project role IDs.</param>
        /// <param name="content"></param>
        [Put("/rest/api/3/role/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ProjectRole, object>>> FullyUpdateProjectRoleAsync([Path] long id, [Body] CreateUpdateRoleRequestBean content);

        /// <summary>
        /// Partial update project role
        /// </summary>
        /// <param name="id">The ID of the project role. Use [Get all project roles](#api-rest-api-3-role-get) to get a list of project role IDs.</param>
        /// <param name="content"></param>
        [Post("/rest/api/3/role/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ProjectRole, object>>> PartialUpdateProjectRoleAsync([Path] long id, [Body] CreateUpdateRoleRequestBean content);

        /// <summary>
        /// Delete project role
        /// </summary>
        /// <param name="id">The ID of the project role to delete. Use [Get all project roles](#api-rest-api-3-role-get) to get a list of project role IDs.</param>
        /// <param name="swap">The ID of the project role that will replace the one being deleted.</param>
        [Delete("/rest/api/3/role/{id}")]
        Task<object> DeleteProjectRoleAsync([Path] long id, [Query] long? swap);

        /// <summary>
        /// Get default actors for project role
        /// </summary>
        /// <param name="id">The ID of the project role. Use [Get all project roles](#api-rest-api-3-role-get) to get a list of project role IDs.</param>
        [Get("/rest/api/3/role/{id}/actors")]
        Task<Response<AnyOf<ProjectRole, object>>> GetProjectRoleActorsForRoleAsync([Path] long id);

        /// <summary>
        /// Add default actors to project role
        /// </summary>
        /// <param name="id">The ID of the project role. Use [Get all project roles](#api-rest-api-3-role-get) to get a list of project role IDs.</param>
        /// <param name="content"></param>
        [Post("/rest/api/3/role/{id}/actors")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ProjectRole, object>>> AddProjectRoleActorsToRoleAsync([Path] long id, [Body] ActorInputBean content);

        /// <summary>
        /// Delete default actors from project role
        /// </summary>
        /// <param name="id">The ID of the project role. Use [Get all project roles](#api-rest-api-3-role-get) to get a list of project role IDs.</param>
        /// <param name="user">The user account ID of the user to remove as a default actor.</param>
        /// <param name="x41d4c5e7 423b 4bb2 b07b 255b6c3ff82d">The group name of the group to be removed as a default actor.</param>
        [Delete("/rest/api/3/role/{id}/actors")]
        Task<Response<AnyOf<ProjectRole, object>>> DeleteProjectRoleActorsFromRoleAsync([Path] long id, [Query] string user, [Query(Name = "group")] string x41d4c5e7 423b 4bb2 b07b 255b6c3ff82d);

        /// <summary>
        /// Get screens
        /// </summary>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="id">The list of screen IDs. To include multiple IDs, provide an ampersand-separated list. For example, `id=10000&id=10001`.</param>
        [Get("/rest/api/3/screens")]
        Task<Response<AnyOf<PageBeanScreen, object>>> GetScreensAsync([Query] long? startAt, [Query] int? maxResults, [Query] long[] id);

        /// <summary>
        /// Create screen
        /// </summary>
        /// <param name="content">Details of a screen.</param>
        [Post("/rest/api/3/screens")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Screen, object>>> CreateScreenAsync([Body] ScreenDetails content);

        /// <summary>
        /// Add field to default screen
        /// </summary>
        /// <param name="fieldId">The ID of the field.</param>
        [Post("/rest/api/3/screens/addToDefault/{fieldId}")]
        Task<Response<AnyOf<AddFieldToDefaultScreenResult, object>>> AddFieldToDefaultScreenAsync([Path] string fieldId);

        /// <summary>
        /// Update screen
        /// </summary>
        /// <param name="screenId">The ID of the screen.</param>
        /// <param name="content">Details of a screen.</param>
        [Put("/rest/api/3/screens/{screenId}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Screen, object>>> UpdateScreenAsync([Path] long screenId, [Body] UpdateScreenDetails content);

        /// <summary>
        /// Delete screen
        /// </summary>
        /// <param name="screenId">The ID of the screen.</param>
        [Delete("/rest/api/3/screens/{screenId}")]
        Task<object> DeleteScreenAsync([Path] long screenId);

        /// <summary>
        /// Get available screen fields
        /// </summary>
        /// <param name="screenId">The ID of the screen.</param>
        [Get("/rest/api/3/screens/{screenId}/availableFields")]
        Task<Response<AnyOf<ScreenableField[], object>>> GetAvailableScreenFieldsAsync([Path] long screenId);

        /// <summary>
        /// Get all screen tabs
        /// </summary>
        /// <param name="screenId">The ID of the screen.</param>
        /// <param name="projectKey">The key of the project.</param>
        [Get("/rest/api/3/screens/{screenId}/tabs")]
        Task<Response<AnyOf<ScreenableTab[], object>>> GetAllScreenTabsAsync([Path] long screenId, [Query] string projectKey);

        /// <summary>
        /// Create screen tab
        /// </summary>
        /// <param name="screenId">The ID of the screen.</param>
        /// <param name="content">A screen tab.</param>
        [Post("/rest/api/3/screens/{screenId}/tabs")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ScreenableTab, object>>> AddScreenTabAsync([Path] long screenId, [Body] ScreenableTab content);

        /// <summary>
        /// Update screen tab
        /// </summary>
        /// <param name="screenId">The ID of the screen.</param>
        /// <param name="tabId">The ID of the screen tab.</param>
        /// <param name="content">A screen tab.</param>
        [Put("/rest/api/3/screens/{screenId}/tabs/{tabId}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ScreenableTab, object>>> RenameScreenTabAsync([Path] long screenId, [Path] long tabId, [Body] ScreenableTab content);

        /// <summary>
        /// Delete screen tab
        /// </summary>
        /// <param name="screenId">The ID of the screen.</param>
        /// <param name="tabId">The ID of the screen tab.</param>
        [Delete("/rest/api/3/screens/{screenId}/tabs/{tabId}")]
        Task<object> DeleteScreenTabAsync([Path] long screenId, [Path] long tabId);

        /// <summary>
        /// Get all screen tab fields
        /// </summary>
        /// <param name="screenId">The ID of the screen.</param>
        /// <param name="tabId">The ID of the screen tab.</param>
        /// <param name="projectKey">The key of the project.</param>
        [Get("/rest/api/3/screens/{screenId}/tabs/{tabId}/fields")]
        Task<Response<AnyOf<ScreenableField[], object>>> GetAllScreenTabFieldsAsync([Path] long screenId, [Path] long tabId, [Query] string projectKey);

        /// <summary>
        /// Add screen tab field
        /// </summary>
        /// <param name="screenId">The ID of the screen.</param>
        /// <param name="tabId">The ID of the screen tab.</param>
        /// <param name="content"></param>
        [Post("/rest/api/3/screens/{screenId}/tabs/{tabId}/fields")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ScreenableField, object>>> AddScreenTabFieldAsync([Path] long screenId, [Path] long tabId, [Body] AddFieldBean content);

        /// <summary>
        /// Remove screen tab field
        /// </summary>
        /// <param name="screenId">The ID of the screen.</param>
        /// <param name="tabId">The ID of the screen tab.</param>
        /// <param name="id">The ID of the field.</param>
        [Delete("/rest/api/3/screens/{screenId}/tabs/{tabId}/fields/{id}")]
        Task<object> RemoveScreenTabFieldAsync([Path] long screenId, [Path] long tabId, [Path] string id);

        /// <summary>
        /// Move screen tab field
        /// </summary>
        /// <param name="screenId">The ID of the screen.</param>
        /// <param name="tabId">The ID of the screen tab.</param>
        /// <param name="id">The ID of the field.</param>
        /// <param name="content"></param>
        [Post("/rest/api/3/screens/{screenId}/tabs/{tabId}/fields/{id}/move")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<MoveScreenTabFieldResult, object>>> MoveScreenTabFieldAsync([Path] long screenId, [Path] long tabId, [Path] string id, [Body] MoveFieldBean content);

        /// <summary>
        /// Move screen tab
        /// </summary>
        /// <param name="screenId">The ID of the screen.</param>
        /// <param name="tabId">The ID of the screen tab.</param>
        /// <param name="pos">The position of tab. The base index is 0.</param>
        [Post("/rest/api/3/screens/{screenId}/tabs/{tabId}/move/{pos}")]
        Task<Response<AnyOf<MoveScreenTabResult, object>>> MoveScreenTabAsync([Path] long screenId, [Path] long tabId, [Path] int pos);

        /// <summary>
        /// Get screen schemes
        /// </summary>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="id">The list of screen scheme IDs. To include multiple IDs, provide an ampersand-separated list. For example, `id=10000&id=10001`.</param>
        [Get("/rest/api/3/screenscheme")]
        Task<Response<AnyOf<PageBeanScreenScheme, object>>> GetScreenSchemesAsync([Query] long? startAt, [Query] int? maxResults, [Query] long[] id);

        /// <summary>
        /// Create screen scheme
        /// </summary>
        /// <param name="content">Details of a screen scheme.</param>
        [Post("/rest/api/3/screenscheme")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ScreenSchemeId, object>>> CreateScreenSchemeAsync([Body] ScreenSchemeDetails content);

        /// <summary>
        /// Update screen scheme
        /// </summary>
        /// <param name="screenSchemeId">The ID of the screen scheme.</param>
        /// <param name="content">Details of a screen scheme.</param>
        [Put("/rest/api/3/screenscheme/{screenSchemeId}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<UpdateScreenSchemeResult, object>>> UpdateScreenSchemeAsync([Path] string screenSchemeId, [Body] UpdateScreenSchemeDetails content);

        /// <summary>
        /// Delete screen scheme
        /// </summary>
        /// <param name="screenSchemeId">The ID of the screen scheme.</param>
        [Delete("/rest/api/3/screenscheme/{screenSchemeId}")]
        Task<object> DeleteScreenSchemeAsync([Path] string screenSchemeId);

        /// <summary>
        /// Search for issues using JQL (GET)
        /// </summary>
        /// <param name="jql">The [JQL](https://confluence.atlassian.com/x/egORLQ) that defines the search. Note: *  If no JQL expression is provided, all issues are returned. *  `username` and `userkey` cannot be used as search terms due to privacy reasons. Use `accountId` instead. *  If a user has hidden their email address in their user profile, partial matches of the email address will not find the user. An exact match is required.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page. To manage page size, Jira may return fewer items per page where a large number of fields are requested. The greatest number of items returned per page is achieved when requesting `id` or `key` only.</param>
        /// <param name="validateQuery">Determines how to validate the JQL query and treat the validation results. Supported values are: *  `strict` Returns a 400 response code if any errors are found, along with a list of all errors (and warnings). *  `warn` Returns all errors as warnings. *  `none` No validation is performed. *  `true` *Deprecated* A legacy synonym for `strict`. *  `false` *Deprecated* A legacy synonym for `warn`.Note: If the JQL is not correctly formed a 400 response code is returned, regardless of the `validateQuery` value.</param>
        /// <param name="fields">A list of fields to return for each issue, use it to retrieve a subset of fields. This parameter accepts a comma-separated list. Expand options include: *  `*all` Returns all fields. *  `*navigable` Returns navigable fields. *  Any issue field, prefixed with a minus to exclude.Examples: *  `summary,comment` Returns only the summary and comments fields. *  `-description` Returns all navigable (default) fields except description. *  `*all,-comment` Returns all fields except comments.This parameter may be specified multiple times. For example, `fields=field1,field2&fields=field3`.Note: All navigable fields are returned by default. This differs from [GET issue](#api-rest-api-3-issue-issueIdOrKey-get) where the default is all fields.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about issues in the response. This parameter accepts a comma-separated list. Expand options include: *  `renderedFields` Returns field values rendered in HTML format. *  `names` Returns the display name of each field. *  `schema` Returns the schema describing a field type. *  `transitions` Returns all possible transitions for the issue. *  `operations` Returns all possible operations for the issue. *  `editmeta` Returns information about how each field can be edited. *  `changelog` Returns a list of recent updates to an issue, sorted by date, starting from the most recent. *  `versionedRepresentations` Instead of `fields`, returns `versionedRepresentations` a JSON array containing each version of a field's value, with the highest numbered item representing the most recent version.</param>
        /// <param name="properties">A list of issue property keys for issue properties to include in the results. This parameter accepts a comma-separated list. Multiple properties can also be provided using an ampersand separated list. For example, `properties=prop1,prop2&properties=prop3`. A maximum of 5 issue property keys can be specified.</param>
        /// <param name="fieldsByKeys">Reference fields by their key (rather than ID).</param>
        [Get("/rest/api/3/search")]
        Task<Response<AnyOf<SearchResults, object>>> SearchForIssuesUsingJqlAsync([Query] string jql, [Query] int? startAt, [Query] int? maxResults, [Query] string validateQuery, [Query] string[] fields, [Query] string expand, [Query] string[] properties, [Query] bool? fieldsByKeys);

        /// <summary>
        /// Search for issues using JQL (POST)
        /// </summary>
        /// <param name="content">A JSON object containing the search request.</param>
        [Post("/rest/api/3/search")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SearchResults, object>>> SearchForIssuesUsingJqlPostAsync([Body] SearchRequestBean content);

        /// <summary>
        /// Get issue security level
        /// </summary>
        /// <param name="id">The ID of the issue security level.</param>
        [Get("/rest/api/3/securitylevel/{id}")]
        Task<Response<AnyOf<SecurityLevel, object>>> GetIssueSecurityLevelAsync([Path] string id);

        /// <summary>
        /// Get Jira instance info
        /// </summary>
        [Get("/rest/api/3/serverInfo")]
        Task<Response<AnyOf<ServerInformation, object>>> GetServerInfoAsync();

        /// <summary>
        /// Get issue navigator default columns
        /// </summary>
        [Get("/rest/api/3/settings/columns")]
        Task<Response<AnyOf<ColumnItem[], object>>> GetIssueNavigatorDefaultColumnsAsync();

        /// <summary>
        /// Set issue navigator default columns
        /// </summary>
        /// <param name="contentType">The Content-Type</param>
        /// <param name="content">An extension method is generated to support the exact parameters.</param>
        [Put("/rest/api/3/settings/columns")]
        Task<Response<AnyOf<SetIssueNavigatorDefaultColumnsResult, object>>> SetIssueNavigatorDefaultColumnsAsync([Header("Content-Type")] string contentType, [Body] HttpContent content);

        /// <summary>
        /// Get all statuses
        /// </summary>
        [Get("/rest/api/3/status")]
        Task<Response<AnyOf<StatusDetails[], object>>> GetStatusesAsync();

        /// <summary>
        /// Get status
        /// </summary>
        /// <param name="idOrName">The ID or name of the status.</param>
        [Get("/rest/api/3/status/{idOrName}")]
        Task<Response<AnyOf<StatusDetails, object>>> GetStatusAsync([Path] string idOrName);

        /// <summary>
        /// Get all status categories
        /// </summary>
        [Get("/rest/api/3/statuscategory")]
        Task<Response<AnyOf<StatusCategory[], object>>> GetStatusCategoriesAsync();

        /// <summary>
        /// Get status category
        /// </summary>
        /// <param name="idOrKey">The ID or key of the status category.</param>
        [Get("/rest/api/3/statuscategory/{idOrKey}")]
        Task<Response<AnyOf<StatusCategory, object>>> GetStatusCategoryAsync([Path] string idOrKey);

        /// <summary>
        /// Get task
        /// </summary>
        /// <param name="taskId">The ID of the task.</param>
        [Get("/rest/api/3/task/{taskId}")]
        Task<Response<AnyOf<TaskProgressBeanObject, object>>> GetTaskAsync([Path] string taskId);

        /// <summary>
        /// Cancel task
        /// </summary>
        /// <param name="taskId">The ID of the task.</param>
        [Post("/rest/api/3/task/{taskId}/cancel")]
        Task<Response<AnyOf<CancelTaskResult, string[]>>> CancelTaskAsync([Path] string taskId);

        /// <summary>
        /// Get avatars
        /// </summary>
        /// <param name="type">The avatar type.</param>
        /// <param name="entityId">The ID of the item the avatar is associated with.</param>
        [Get("/rest/api/3/universal_avatar/type/{type}/owner/{entityId}")]
        Task<Response<AnyOf<Avatars, object>>> GetAvatarsAsync([Path] string type, [Path] string entityId);

        /// <summary>
        /// Load avatar
        /// </summary>
        /// <param name="type">The avatar type.</param>
        /// <param name="entityId">The ID of the item the avatar is associated with.</param>
        /// <param name="size">The length of each side of the crop region.</param>
        /// <param name="x">The X coordinate of the top-left corner of the crop region.</param>
        /// <param name="y">The Y coordinate of the top-left corner of the crop region.</param>
        [Post("/rest/api/3/universal_avatar/type/{type}/owner/{entityId}")]
        Task<Response<AnyOf<Avatar, object>>> StoreAvatarAsync([Path] string type, [Path] string entityId, [Query] int size, [Query] int? x, [Query] int? y);

        /// <summary>
        /// Delete avatar
        /// </summary>
        /// <param name="type">The avatar type.</param>
        /// <param name="owningObjectId">The ID of the item the avatar is associated with.</param>
        /// <param name="id">The ID of the avatar.</param>
        [Delete("/rest/api/3/universal_avatar/type/{type}/owner/{owningObjectId}/avatar/{id}")]
        Task<object> DeleteAvatarAsync([Path] string type, [Path] string owningObjectId, [Path] long id);

        /// <summary>
        /// Get avatar image by type
        /// </summary>
        /// <param name="type">The icon type of the avatar.</param>
        /// <param name="size">The size of the avatar image. If not provided the default size is returned.</param>
        /// <param name="format">The format to return the avatar image in. If not provided the original content format is returned.</param>
        [Get("/rest/api/3/universal_avatar/view/type/{type}")]
        Task<Response<AnyOf<GetAvatarImageByTypeResult, ErrorCollection>>> GetAvatarImageByTypeAsync([Path] string type, [Query] string size, [Query] string format);

        /// <summary>
        /// Get avatar image by ID
        /// </summary>
        /// <param name="type">The icon type of the avatar.</param>
        /// <param name="id">The ID of the avatar.</param>
        /// <param name="size">The size of the avatar image. If not provided the default size is returned.</param>
        /// <param name="format">The format to return the avatar image in. If not provided the original content format is returned.</param>
        [Get("/rest/api/3/universal_avatar/view/type/{type}/avatar/{id}")]
        Task<Response<AnyOf<GetAvatarImageByIDResult, ErrorCollection>>> GetAvatarImageByIDAsync([Path] string type, [Path] long id, [Query] string size, [Query] string format);

        /// <summary>
        /// Get avatar image by owner
        /// </summary>
        /// <param name="type">The icon type of the avatar.</param>
        /// <param name="entityId">The ID of the project or issue type the avatar belongs to.</param>
        /// <param name="size">The size of the avatar image. If not provided the default size is returned.</param>
        /// <param name="format">The format to return the avatar image in. If not provided the original content format is returned.</param>
        [Get("/rest/api/3/universal_avatar/view/type/{type}/owner/{entityId}")]
        Task<Response<AnyOf<GetAvatarImageByOwnerResult, ErrorCollection>>> GetAvatarImageByOwnerAsync([Path] string type, [Path] string entityId, [Query] string size, [Query] string format);

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="accountId">The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*. Required.</param>
        /// <param name="username">This parameter is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide) for details.</param>
        /// <param name="key">This parameter is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide) for details.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about users in the response. This parameter accepts a comma-separated list. Expand options include: *  `groups` includes all groups and nested groups to which the user belongs. *  `applicationRoles` includes details of all the applications to which the user has access.</param>
        [Get("/rest/api/3/user")]
        Task<Response<AnyOf<User, object>>> GetUserAsync([Query] string accountId, [Query] string username, [Query] string key, [Query] string expand);

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="content">The user details.</param>
        [Post("/rest/api/3/user")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<User, object>>> CreateUserAsync([Body] NewUserDetails content);

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="accountId">The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.</param>
        /// <param name="username">This parameter is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        /// <param name="key">This parameter is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        [Delete("/rest/api/3/user")]
        Task<object> RemoveUserAsync([Query] string accountId, [Query] string username, [Query] string key);

        /// <summary>
        /// Find users assignable to projects
        /// </summary>
        /// <param name="projectKeys">A list of project keys (case sensitive). This parameter accepts a comma-separated list.</param>
        /// <param name="query">A query string that is matched against user attributes, such as `displayName` and `emailAddress`, to find relevant users. The string can match the prefix of the attribute's value. For example, *query=john* matches a user with a `displayName` of *John Smith* and a user with an `emailAddress` of *johnson@example.com*. Required, unless `accountId` is specified.</param>
        /// <param name="username">This parameter is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        /// <param name="accountId">A query string that is matched exactly against user `accountId`. Required, unless `query` is specified.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/user/assignable/multiProjectSearch")]
        Task<Response<AnyOf<User[], object>>> FindBulkAssignableUsersAsync([Query] string projectKeys, [Query] string query, [Query] string username, [Query] string accountId, [Query] int? startAt, [Query] int? maxResults);

        /// <summary>
        /// Find users assignable to issues
        /// </summary>
        /// <param name="query">A query string that is matched against user attributes, such as `displayName`, and `emailAddress`, to find relevant users. The string can match the prefix of the attribute's value. For example, *query=john* matches a user with a `displayName` of *John Smith* and a user with an `emailAddress` of *johnson@example.com*. Required, unless `username` or `accountId` is specified.</param>
        /// <param name="sessionId">The sessionId of this request. SessionId is the same until the assignee is set.</param>
        /// <param name="username">This parameter is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        /// <param name="accountId">A query string that is matched exactly against user `accountId`. Required, unless `query` is specified.</param>
        /// <param name="project">The project ID or project key (case sensitive). Required, unless `issueKey` is specified.</param>
        /// <param name="issueKey">The key of the issue. Required, unless `project` is specified.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return. This operation may return less than the maximum number of items even if more are available. The operation fetches users up to the maximum and then, from the fetched users, returns only the users that can be assigned to the issue.</param>
        /// <param name="actionDescriptorId">The ID of the transition.</param>
        /// <param name="recommend"></param>
        [Get("/rest/api/3/user/assignable/search")]
        Task<Response<AnyOf<User[], object>>> FindAssignableUsersAsync([Query] string query, [Query] string sessionId, [Query] string username, [Query] string accountId, [Query] string project, [Query] string issueKey, [Query] int? startAt, [Query] int? maxResults, [Query] int? actionDescriptorId, [Query] bool? recommend);

        /// <summary>
        /// Bulk get users
        /// </summary>
        /// <param name="accountId">The account ID of a user. To specify multiple users, pass multiple `accountId` parameters. For example, `accountId=5b10a2844c20165700ede21g&accountId=5b10ac8d82e05b22cc7d4ef5`.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="username">This parameter is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        /// <param name="key">This parameter is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        [Get("/rest/api/3/user/bulk")]
        Task<Response<AnyOf<PageBeanUser, object>>> BulkGetUsersAsync([Query] string[] accountId, [Query] long? startAt, [Query] int? maxResults, [Query] string[] username, [Query] string[] key);

        /// <summary>
        /// Get account IDs for users
        /// </summary>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="username">Username of a user. To specify multiple users, pass multiple copies of this parameter. For example, `username=fred&username=barney`. Required if `key` isn't provided. Cannot be provided if `key` is present.</param>
        /// <param name="key">Key of a user. To specify multiple users, pass multiple copies of this parameter. For example, `key=fred&key=barney`. Required if `username` isn't provided. Cannot be provided if `username` is present.</param>
        [Get("/rest/api/3/user/bulk/migration")]
        Task<Response<AnyOf<UserMigrationBean[], object>>> BulkGetUsersMigrationAsync([Query] long? startAt, [Query] int? maxResults, [Query] string[] username, [Query] string[] key);

        /// <summary>
        /// Get user default columns
        /// </summary>
        /// <param name="accountId">The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.</param>
        /// <param name="username">This parameter is no longer available See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        [Get("/rest/api/3/user/columns")]
        Task<Response<AnyOf<ColumnItem[], object>>> GetUserDefaultColumnsAsync([Query] string accountId, [Query] string username);

        /// <summary>
        /// Set user default columns
        /// </summary>
        /// <param name="contentType">The Content-Type</param>
        /// <param name="content">An extension method is generated to support the exact parameters.</param>
        /// <param name="accountId">The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.</param>
        [Put("/rest/api/3/user/columns")]
        Task<Response<AnyOf<SetUserColumnsResult, object>>> SetUserColumnsAsync([Header("Content-Type")] string contentType, [Body] HttpContent content, [Query] string accountId);

        /// <summary>
        /// Reset user default columns
        /// </summary>
        /// <param name="accountId">The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.</param>
        /// <param name="username">This parameter is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        [Delete("/rest/api/3/user/columns")]
        Task<object> ResetUserColumnsAsync([Query] string accountId, [Query] string username);

        /// <summary>
        /// Get user email
        /// </summary>
        /// <param name="accountId">The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, `5b10ac8d82e05b22cc7d4ef5`.</param>
        [Get("/rest/api/3/user/email")]
        Task<Response<AnyOf<UnrestrictedUserEmail, object>>> GetUserEmailAsync([Query] string accountId);

        /// <summary>
        /// Get user email bulk
        /// </summary>
        /// <param name="accountId">The account IDs of the users for which emails are required. An `accountId` is an identifier that uniquely identifies the user across all Atlassian products. For example, `5b10ac8d82e05b22cc7d4ef5`. Note, this should be treated as an opaque identifier (that is, do not assume any structure in the value).</param>
        [Get("/rest/api/3/user/email/bulk")]
        Task<Response<AnyOf<UnrestrictedUserEmail, object>>> GetUserEmailBulkAsync([Query] string[] accountId);

        /// <summary>
        /// Get user groups
        /// </summary>
        /// <param name="accountId">The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.</param>
        /// <param name="username">This parameter is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        /// <param name="key">This parameter is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        [Get("/rest/api/3/user/groups")]
        Task<Response<AnyOf<GroupName[], object>>> GetUserGroupsAsync([Query] string accountId, [Query] string username, [Query] string key);

        /// <summary>
        /// Find users with permissions
        /// </summary>
        /// <param name="permissions">A comma separated list of permissions. Permissions can be specified as any: *  permission returned by [Get all permissions](#api-rest-api-3-permissions-get). *  custom project permission added by Connect apps. *  (deprecated) one of the following:         *  ASSIGNABLE\_USER     *  ASSIGN\_ISSUE     *  ATTACHMENT\_DELETE\_ALL     *  ATTACHMENT\_DELETE\_OWN     *  BROWSE     *  CLOSE\_ISSUE     *  COMMENT\_DELETE\_ALL     *  COMMENT\_DELETE\_OWN     *  COMMENT\_EDIT\_ALL     *  COMMENT\_EDIT\_OWN     *  COMMENT\_ISSUE     *  CREATE\_ATTACHMENT     *  CREATE\_ISSUE     *  DELETE\_ISSUE     *  EDIT\_ISSUE     *  LINK\_ISSUE     *  MANAGE\_WATCHER\_LIST     *  MODIFY\_REPORTER     *  MOVE\_ISSUE     *  PROJECT\_ADMIN     *  RESOLVE\_ISSUE     *  SCHEDULE\_ISSUE     *  SET\_ISSUE\_SECURITY     *  TRANSITION\_ISSUE     *  VIEW\_VERSION\_CONTROL     *  VIEW\_VOTERS\_AND\_WATCHERS     *  VIEW\_WORKFLOW\_READONLY     *  WORKLOG\_DELETE\_ALL     *  WORKLOG\_DELETE\_OWN     *  WORKLOG\_EDIT\_ALL     *  WORKLOG\_EDIT\_OWN     *  WORK\_ISSUE</param>
        /// <param name="query">A query string that is matched against user attributes, such as `displayName` and `emailAddress`, to find relevant users. The string can match the prefix of the attribute's value. For example, *query=john* matches a user with a `displayName` of *John Smith* and a user with an `emailAddress` of *johnson@example.com*. Required, unless `accountId` is specified.</param>
        /// <param name="username">This parameter is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        /// <param name="accountId">A query string that is matched exactly against user `accountId`. Required, unless `query` is specified.</param>
        /// <param name="issueKey">The issue key for the issue.</param>
        /// <param name="projectKey">The project key for the project (case sensitive).</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/user/permission/search")]
        Task<Response<AnyOf<User[], object>>> FindUsersWithAllPermissionsAsync([Query] string permissions, [Query] string query, [Query] string username, [Query] string accountId, [Query] string issueKey, [Query] string projectKey, [Query] int? startAt, [Query] int? maxResults);

        /// <summary>
        /// Find users for picker
        /// </summary>
        /// <param name="query">A query string that is matched against user attributes, such as `displayName`, and `emailAddress`, to find relevant users. The string can match the prefix of the attribute's value. For example, *query=john* matches a user with a `displayName` of *John Smith* and a user with an `emailAddress` of *johnson@example.com*.</param>
        /// <param name="maxResults">The maximum number of items to return. The total number of matched users is returned in `total`.</param>
        /// <param name="showAvatar">Include the URI to the user's avatar.</param>
        /// <param name="exclude">This parameter is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        /// <param name="excludeAccountIds">A list of account IDs to exclude from the search results. This parameter accepts a comma-separated list. Multiple account IDs can also be provided using an ampersand-separated list. For example, `excludeAccountIds=5b10a2844c20165700ede21g,5b10a0effa615349cb016cd8&excludeAccountIds=5b10ac8d82e05b22cc7d4ef5`. Cannot be provided with `exclude`.</param>
        /// <param name="avatarSize"></param>
        /// <param name="excludeConnectUsers"></param>
        [Get("/rest/api/3/user/picker")]
        Task<Response<AnyOf<FoundUsers, object>>> FindUsersForPickerAsync([Query] string query, [Query] int? maxResults, [Query] bool? showAvatar, [Query] string[] exclude, [Query] string[] excludeAccountIds, [Query] string avatarSize, [Query] bool? excludeConnectUsers);

        /// <summary>
        /// Get user property keys
        /// </summary>
        /// <param name="accountId">The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.</param>
        /// <param name="userKey">This parameter is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        /// <param name="username">This parameter is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        [Get("/rest/api/3/user/properties")]
        Task<Response<AnyOf<PropertyKeys, object>>> GetUserPropertyKeysAsync([Query] string accountId, [Query] string userKey, [Query] string username);

        /// <summary>
        /// Get user property
        /// </summary>
        /// <param name="propertyKey">The key of the user's property.</param>
        /// <param name="accountId">The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.</param>
        /// <param name="userKey">This parameter is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        /// <param name="username">This parameter is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        [Get("/rest/api/3/user/properties/{propertyKey}")]
        Task<Response<AnyOf<EntityProperty, object>>> GetUserPropertyAsync([Path] string propertyKey, [Query] string accountId, [Query] string userKey, [Query] string username);

        /// <summary>
        /// Set user property
        /// </summary>
        /// <param name="propertyKey">The key of the user's property. The maximum length is 255 characters.</param>
        /// <param name="accountId">The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.</param>
        /// <param name="userKey">This parameter is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        /// <param name="username">This parameter is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        [Put("/rest/api/3/user/properties/{propertyKey}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<SetUserPropertyResult, object>>> SetUserPropertyAsync([Path] string propertyKey, [Query] string accountId, [Query] string userKey, [Query] string username);

        /// <summary>
        /// Delete user property
        /// </summary>
        /// <param name="propertyKey">The key of the user's property.</param>
        /// <param name="accountId">The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.</param>
        /// <param name="userKey">This parameter is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        /// <param name="username">This parameter is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        [Delete("/rest/api/3/user/properties/{propertyKey}")]
        Task<object> DeleteUserPropertyAsync([Path] string propertyKey, [Query] string accountId, [Query] string userKey, [Query] string username);

        /// <summary>
        /// Find users
        /// </summary>
        /// <param name="query">A query string that is matched against user attributes ( `displayName`, and `emailAddress`) to find relevant users. The string can match the prefix of the attribute's value. For example, *query=john* matches a user with a `displayName` of *John Smith* and a user with an `emailAddress` of *johnson@example.com*. Required, unless `accountId` or `property` is specified.</param>
        /// <param name="username"></param>
        /// <param name="accountId">A query string that is matched exactly against a user `accountId`. Required, unless `query` or `property` is specified.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="property">A query string used to search properties. Property keys are specified by path, so property keys containing dot (.) or equals (=) characters cannot be used. The query string cannot be specified using a JSON object. Example: To search for the value of `nested` from `{"something":{"nested":1,"other":2}}` use `thepropertykey.something.nested=1`. Required, unless `accountId` or `query` is specified.</param>
        [Get("/rest/api/3/user/search")]
        Task<Response<AnyOf<User[], object>>> FindUsersAsync([Query] string query, [Query] string username, [Query] string accountId, [Query] int? startAt, [Query] int? maxResults, [Query] string property);

        /// <summary>
        /// Find users by query
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/user/search/query")]
        Task<Response<AnyOf<PageBeanUser, object>>> FindUsersByQueryAsync([Query] string query, [Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Find user keys by query
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/user/search/query/key")]
        Task<Response<AnyOf<PageBeanUserKey, object>>> FindUserKeysByQueryAsync([Query] string query, [Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Find users with browse permission
        /// </summary>
        /// <param name="query">A query string that is matched against user attributes, such as `displayName` and `emailAddress`, to find relevant users. The string can match the prefix of the attribute's value. For example, *query=john* matches a user with a `displayName` of *John Smith* and a user with an `emailAddress` of *johnson@example.com*. Required, unless `accountId` is specified.</param>
        /// <param name="username">This parameter is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.</param>
        /// <param name="accountId">A query string that is matched exactly against user `accountId`. Required, unless `query` is specified.</param>
        /// <param name="issueKey">The issue key for the issue. Required, unless `projectKey` is specified.</param>
        /// <param name="projectKey">The project key for the project (case sensitive). Required, unless `issueKey` is specified.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/user/viewissue/search")]
        Task<Response<AnyOf<User[], object>>> FindUsersWithBrowsePermissionAsync([Query] string query, [Query] string username, [Query] string accountId, [Query] string issueKey, [Query] string projectKey, [Query] int? startAt, [Query] int? maxResults);

        /// <summary>
        /// Get all users default
        /// </summary>
        /// <param name="startAt">The index of the first item to return.</param>
        /// <param name="maxResults">The maximum number of items to return.</param>
        [Get("/rest/api/3/users")]
        Task<Response<AnyOf<User[], object>>> GetAllUsersDefaultAsync([Query] int? startAt, [Query] int? maxResults);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <param name="startAt">The index of the first item to return.</param>
        /// <param name="maxResults">The maximum number of items to return.</param>
        [Get("/rest/api/3/users/search")]
        Task<Response<AnyOf<User[], object>>> GetAllUsersAsync([Query] int? startAt, [Query] int? maxResults);

        /// <summary>
        /// Create version
        /// </summary>
        /// <param name="content">Details about a project version.</param>
        [Post("/rest/api/3/version")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Version, object>>> CreateVersionAsync([Body] Version content);

        /// <summary>
        /// Get version
        /// </summary>
        /// <param name="id">The ID of the version.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about version in the response. This parameter accepts a comma-separated list. Expand options include: *  `operations` Returns the list of operations available for this version. *  `issuesstatus` Returns the count of issues in this version for each of the status categories *to do*, *in progress*, *done*, and *unmapped*. The *unmapped* property represents the number of issues with a status other than *to do*, *in progress*, and *done*.</param>
        [Get("/rest/api/3/version/{id}")]
        Task<Response<AnyOf<Version, object>>> GetVersionAsync([Path] string id, [Query] string expand);

        /// <summary>
        /// Update version
        /// </summary>
        /// <param name="id">The ID of the version.</param>
        /// <param name="content">Details about a project version.</param>
        [Put("/rest/api/3/version/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Version, object>>> UpdateVersionAsync([Path] string id, [Body] Version content);

        /// <summary>
        /// Delete version
        /// </summary>
        /// <param name="id">The ID of the version.</param>
        /// <param name="moveFixIssuesTo">The ID of the version to update `fixVersion` to when the field contains the deleted version. The replacement version must be in the same project as the version being deleted and cannot be the version being deleted.</param>
        /// <param name="moveAffectedIssuesTo">The ID of the version to update `affectedVersion` to when the field contains the deleted version. The replacement version must be in the same project as the version being deleted and cannot be the version being deleted.</param>
        [Delete("/rest/api/3/version/{id}")]
        Task<object> DeleteVersionAsync([Path] string id, [Query] string moveFixIssuesTo, [Query] string moveAffectedIssuesTo);

        /// <summary>
        /// Merge versions
        /// </summary>
        /// <param name="id">The ID of the version to delete.</param>
        /// <param name="moveIssuesTo">The ID of the version to merge into.</param>
        [Put("/rest/api/3/version/{id}/mergeto/{moveIssuesTo}")]
        Task<Response<AnyOf<MergeVersionsResult, object>>> MergeVersionsAsync([Path] string id, [Path] string moveIssuesTo);

        /// <summary>
        /// Move version
        /// </summary>
        /// <param name="id">The ID of the version to be moved.</param>
        /// <param name="content"></param>
        [Post("/rest/api/3/version/{id}/move")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Version, object>>> MoveVersionAsync([Path] string id, [Body] VersionMoveBean content);

        /// <summary>
        /// Get version's related issues count
        /// </summary>
        /// <param name="id">The ID of the version.</param>
        [Get("/rest/api/3/version/{id}/relatedIssueCounts")]
        Task<Response<AnyOf<VersionIssueCounts, object>>> GetVersionRelatedIssuesAsync([Path] string id);

        /// <summary>
        /// Delete and replace version
        /// </summary>
        /// <param name="id">The ID of the version.</param>
        /// <param name="content"></param>
        [Post("/rest/api/3/version/{id}/removeAndSwap")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<DeleteAndReplaceVersionResult, object>>> DeleteAndReplaceVersionAsync([Path] string id, [Body] DeleteAndReplaceVersionBean content);

        /// <summary>
        /// Get version's unresolved issues count
        /// </summary>
        /// <param name="id">The ID of the version.</param>
        [Get("/rest/api/3/version/{id}/unresolvedIssueCount")]
        Task<Response<AnyOf<VersionUnresolvedIssuesCount, object>>> GetVersionUnresolvedIssuesAsync([Path] string id);

        /// <summary>
        /// Get dynamic webhooks for app
        /// </summary>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/webhook")]
        Task<Response<AnyOf<PageBeanWebhook, ErrorCollection>>> GetDynamicWebhooksForAppAsync([Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Register dynamic webhooks
        /// </summary>
        /// <param name="content">Details of webhooks to register.</param>
        [Post("/rest/api/3/webhook")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<ContainerForRegisteredWebhooks, ErrorCollection>>> RegisterDynamicWebhooksAsync([Body] WebhookRegistrationDetails content);

        /// <summary>
        /// Delete webhooks by ID
        /// </summary>
        /// <param name="content">Container for a list of webhook IDs.</param>
        [Delete("/rest/api/3/webhook")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, ErrorCollection>>> DeleteWebhookByIdAsync([Body] ContainerForWebhookIDs content);

        /// <summary>
        /// Get failed webhooks
        /// </summary>
        /// <param name="maxResults">The maximum number of webhooks to return per page. If obeying the maxResults directive would result in records with the same failure time being split across pages, the directive is ignored and all records with the same failure time included on the page.</param>
        /// <param name="after">The time after which any webhook failure must have occurred for the record to be returned, expressed as milliseconds since the UNIX epoch.</param>
        [Get("/rest/api/3/webhook/failed")]
        Task<Response<AnyOf<FailedWebhooks, ErrorCollection>>> GetFailedWebhooksAsync([Query] int? maxResults, [Query] long? after);

        /// <summary>
        /// Extend webhook life
        /// </summary>
        /// <param name="content">Container for a list of webhook IDs.</param>
        [Put("/rest/api/3/webhook/refresh")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<WebhooksExpirationDate, ErrorCollection>>> RefreshWebhooksAsync([Body] ContainerForWebhookIDs content);

        /// <summary>
        /// Get all workflows
        /// </summary>
        /// <param name="workflowName">The name of the workflow to be returned. Only one workflow can be specified.</param>
        [Get("/rest/api/3/workflow")]
        Task<Response<AnyOf<DeprecatedWorkflow[], object>>> GetAllWorkflowsAsync([Query] string workflowName);

        /// <summary>
        /// Create workflow
        /// </summary>
        /// <param name="content">The details of a workflow.</param>
        [Post("/rest/api/3/workflow")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<WorkflowIDs, object>>> CreateWorkflowAsync([Body] CreateWorkflowDetails content);

        /// <summary>
        /// Get workflow transition rule configurations
        /// </summary>
        /// <param name="types">The types of the transition rules to return.</param>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="keys">The transition rule class keys, as defined in the Connect app descriptor, of the transition rules to return.</param>
        /// <param name="workflowNames">EXPERIMENTAL: The list of workflow names to filter by.</param>
        /// <param name="withTags">EXPERIMENTAL: The list of `tags` to filter by.</param>
        /// <param name="draft">EXPERIMENTAL: Whether draft or published workflows are returned. If not provided, both workflow types are returned.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information in the response. This parameter accepts `transition`, which, for each rule, returns information about the transition the rule is assigned to.</param>
        [Get("/rest/api/3/workflow/rule/config")]
        Task<Response<AnyOf<PageBeanWorkflowTransitionRules, ErrorCollection, object>>> GetWorkflowTransitionRuleConfigurationsAsync([Query] string[] types, [Query] long? startAt, [Query] int? maxResults, [Query] string[] keys, [Query] string[] workflowNames, [Query] string[] withTags, [Query] bool? draft, [Query] string expand);

        /// <summary>
        /// Update workflow transition rule configurations
        /// </summary>
        /// <param name="content">Details about a workflow configuration update request.</param>
        [Put("/rest/api/3/workflow/rule/config")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<WorkflowTransitionRulesUpdateErrors, ErrorCollection>>> UpdateWorkflowTransitionRuleConfigurationsAsync([Body] WorkflowTransitionRulesUpdate content);

        /// <summary>
        /// Delete workflow transition rule configurations
        /// </summary>
        /// <param name="content">Details of workflows and their transition rules to delete.</param>
        [Put("/rest/api/3/workflow/rule/config/delete")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<WorkflowTransitionRulesUpdateErrors, ErrorCollection>>> DeleteWorkflowTransitionRuleConfigurationsAsync([Body] WorkflowsWithTransitionRulesDetails content);

        /// <summary>
        /// Get workflows paginated
        /// </summary>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        /// <param name="workflowName">The name of a workflow to return. To include multiple workflows, provide an ampersand-separated list. For example, `workflowName=name1&workflowName=name2`.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information in the response. This parameter accepts a comma-separated list. Expand options include: *  `transitions` For each workflow, returns information about the transitions inside the workflow. *  `transitions.rules` For each workflow transition, returns information about its rules. Transitions are included automatically if this expand is requested. *  `transitions.properties` For each workflow transition, returns information about its properties. Transitions are included automatically if this expand is requested. *  `statuses` For each workflow, returns information about the statuses inside the workflow. *  `statuses.properties` For each workflow status, returns information about its properties. Statuses are included automatically if this expand is requested. *  `default` For each workflow, returns information about whether this is the default workflow. *  `schemes` For each workflow, returns information about the workflow schemes the workflow is assigned to. *  `projects` For each workflow, returns information about the projects the workflow is assigned to, through workflow schemes. *  `hasDraftWorkflow` For each workflow, returns information about whether the workflow has a draft version. *  `operations` For each workflow, returns information about the actions that can be undertaken on the workflow.</param>
        /// <param name="queryString">String used to perform a case-insensitive partial match with workflow name.</param>
        /// <param name="orderBy">[Order](#ordering) the results by a field: *  `name` Sorts by workflow name. *  `created` Sorts by create time. *  `updated` Sorts by update time.</param>
        /// <param name="isActive">Filters active and inactive workflows.</param>
        [Get("/rest/api/3/workflow/search")]
        Task<Response<AnyOf<PageBeanWorkflow, object, ErrorCollection>>> GetWorkflowsPaginatedAsync([Query] long? startAt, [Query] int? maxResults, [Query] string[] workflowName, [Query] string expand, [Query] string queryString, [Query] string orderBy, [Query] bool? isActive);

        /// <summary>
        /// Get workflow transition properties
        /// </summary>
        /// <param name="transitionId">The ID of the transition. To get the ID, view the workflow in text mode in the Jira administration console. The ID is shown next to the transition.</param>
        /// <param name="workflowName">The name of the workflow that the transition belongs to.</param>
        /// <param name="includeReservedKeys">Some properties with keys that have the *jira.* prefix are reserved, which means they are not editable. To include these properties in the results, set this parameter to *true*.</param>
        /// <param name="key">The key of the property being returned, also known as the name of the property. If this parameter is not specified, all properties on the transition are returned.</param>
        /// <param name="workflowMode">The workflow status. Set to *live* for active and inactive workflows, or *draft* for draft workflows.</param>
        [Get("/rest/api/3/workflow/transitions/{transitionId}/properties")]
        Task<Response<AnyOf<WorkflowTransitionProperty, object>>> GetWorkflowTransitionPropertiesAsync([Path] long transitionId, [Query] string workflowName, [Query] bool? includeReservedKeys, [Query] string key, [Query] string workflowMode);

        /// <summary>
        /// Update workflow transition property
        /// </summary>
        /// <param name="transitionId">The ID of the transition. To get the ID, view the workflow in text mode in the Jira admin settings. The ID is shown next to the transition.</param>
        /// <param name="content">Details about the server Jira is running on.</param>
        /// <param name="key">The key of the property being updated, also known as the name of the property. Set this to the same value as the `key` defined in the request body.</param>
        /// <param name="workflowName">The name of the workflow that the transition belongs to.</param>
        /// <param name="workflowMode">The workflow status. Set to `live` for inactive workflows or `draft` for draft workflows. Active workflows cannot be edited.</param>
        [Put("/rest/api/3/workflow/transitions/{transitionId}/properties")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<WorkflowTransitionProperty, object>>> UpdateWorkflowTransitionPropertyAsync([Path] long transitionId, [Body] WorkflowTransitionProperty content, [Query] string key, [Query] string workflowName, [Query] string workflowMode);

        /// <summary>
        /// Create workflow transition property
        /// </summary>
        /// <param name="transitionId">The ID of the transition. To get the ID, view the workflow in text mode in the Jira admin settings. The ID is shown next to the transition.</param>
        /// <param name="content">Details about the server Jira is running on.</param>
        /// <param name="key">The key of the property being added, also known as the name of the property. Set this to the same value as the `key` defined in the request body.</param>
        /// <param name="workflowName">The name of the workflow that the transition belongs to.</param>
        /// <param name="workflowMode">The workflow status. Set to *live* for inactive workflows or *draft* for draft workflows. Active workflows cannot be edited.</param>
        [Post("/rest/api/3/workflow/transitions/{transitionId}/properties")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<WorkflowTransitionProperty, object>>> CreateWorkflowTransitionPropertyAsync([Path] long transitionId, [Body] WorkflowTransitionProperty content, [Query] string key, [Query] string workflowName, [Query] string workflowMode);

        /// <summary>
        /// Delete workflow transition property
        /// </summary>
        /// <param name="transitionId">The ID of the transition. To get the ID, view the workflow in text mode in the Jira admin settings. The ID is shown next to the transition.</param>
        /// <param name="key">The name of the transition property to delete, also known as the name of the property.</param>
        /// <param name="workflowName">The name of the workflow that the transition belongs to.</param>
        /// <param name="workflowMode">The workflow status. Set to `live` for inactive workflows or `draft` for draft workflows. Active workflows cannot be edited.</param>
        [Delete("/rest/api/3/workflow/transitions/{transitionId}/properties")]
        Task<object> DeleteWorkflowTransitionPropertyAsync([Path] long transitionId, [Query] string key, [Query] string workflowName, [Query] string workflowMode);

        /// <summary>
        /// Delete inactive workflow
        /// </summary>
        /// <param name="entityId">The entity ID of the workflow.</param>
        [Delete("/rest/api/3/workflow/{entityId}")]
        Task<object> DeleteInactiveWorkflowAsync([Path] string entityId);

        /// <summary>
        /// Get all workflow schemes
        /// </summary>
        /// <param name="startAt">The index of the first item to return in a page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page.</param>
        [Get("/rest/api/3/workflowscheme")]
        Task<Response<AnyOf<PageBeanWorkflowScheme, object>>> GetAllWorkflowSchemesAsync([Query] long? startAt, [Query] int? maxResults);

        /// <summary>
        /// Create workflow scheme
        /// </summary>
        /// <param name="content">Details about a workflow scheme.</param>
        [Post("/rest/api/3/workflowscheme")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<WorkflowScheme, object>>> CreateWorkflowSchemeAsync([Body] WorkflowScheme content);

        /// <summary>
        /// Get workflow scheme project associations
        /// </summary>
        /// <param name="projectId">The ID of a project to return the workflow schemes for. To include multiple projects, provide an ampersand-Jim: oneseparated list. For example, `projectId=10000&projectId=10001`.</param>
        [Get("/rest/api/3/workflowscheme/project")]
        Task<Response<AnyOf<ContainerOfWorkflowSchemeAssociations, object>>> GetWorkflowSchemeProjectAssociationsAsync([Query] long[] projectId);

        /// <summary>
        /// Assign workflow scheme to project
        /// </summary>
        /// <param name="content">An associated workflow scheme and project.</param>
        [Put("/rest/api/3/workflowscheme/project")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<AssignSchemeToProjectResult, object>>> AssignSchemeToProjectAsync([Body] WorkflowSchemeProjectAssociation content);

        /// <summary>
        /// Get workflow scheme
        /// </summary>
        /// <param name="id">The ID of the workflow scheme. Find this ID by editing the desired workflow scheme in Jira. The ID is shown in the URL as `schemeId`. For example, *schemeId=10301*.</param>
        /// <param name="returnDraftIfExists">Returns the workflow scheme's draft rather than scheme itself, if set to true. If the workflow scheme does not have a draft, then the workflow scheme is returned.</param>
        [Get("/rest/api/3/workflowscheme/{id}")]
        Task<Response<AnyOf<WorkflowScheme, object>>> GetWorkflowSchemeAsync([Path] long id, [Query] bool? returnDraftIfExists);

        /// <summary>
        /// Update workflow scheme
        /// </summary>
        /// <param name="id">The ID of the workflow scheme. Find this ID by editing the desired workflow scheme in Jira. The ID is shown in the URL as `schemeId`. For example, *schemeId=10301*.</param>
        /// <param name="content">Details about a workflow scheme.</param>
        [Put("/rest/api/3/workflowscheme/{id}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<WorkflowScheme, object>>> UpdateWorkflowSchemeAsync([Path] long id, [Body] WorkflowScheme content);

        /// <summary>
        /// Delete workflow scheme
        /// </summary>
        /// <param name="id">The ID of the workflow scheme. Find this ID by editing the desired workflow scheme in Jira. The ID is shown in the URL as `schemeId`. For example, *schemeId=10301*.</param>
        [Delete("/rest/api/3/workflowscheme/{id}")]
        Task<object> DeleteWorkflowSchemeAsync([Path] long id);

        /// <summary>
        /// Create draft workflow scheme
        /// </summary>
        /// <param name="id">The ID of the active workflow scheme that the draft is created from.</param>
        [Post("/rest/api/3/workflowscheme/{id}/createdraft")]
        Task<Response<AnyOf<WorkflowScheme, object>>> CreateWorkflowSchemeDraftFromParentAsync([Path] long id);

        /// <summary>
        /// Get default workflow
        /// </summary>
        /// <param name="id">The ID of the workflow scheme.</param>
        /// <param name="returnDraftIfExists">Set to `true` to return the default workflow for the workflow scheme's draft rather than scheme itself. If the workflow scheme does not have a draft, then the default workflow for the workflow scheme is returned.</param>
        [Get("/rest/api/3/workflowscheme/{id}/default")]
        Task<Response<AnyOf<DefaultWorkflow, object>>> GetDefaultWorkflowAsync([Path] long id, [Query] bool? returnDraftIfExists);

        /// <summary>
        /// Update default workflow
        /// </summary>
        /// <param name="id">The ID of the workflow scheme.</param>
        /// <param name="content">Details about the default workflow.</param>
        [Put("/rest/api/3/workflowscheme/{id}/default")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<WorkflowScheme, object>>> UpdateDefaultWorkflowAsync([Path] long id, [Body] DefaultWorkflow content);

        /// <summary>
        /// Delete default workflow
        /// </summary>
        /// <param name="id">The ID of the workflow scheme.</param>
        /// <param name="updateDraftIfNeeded">Set to true to create or update the draft of a workflow scheme and delete the mapping from the draft, when the workflow scheme cannot be edited. Defaults to `false`.</param>
        [Delete("/rest/api/3/workflowscheme/{id}/default")]
        Task<Response<AnyOf<WorkflowScheme, object>>> DeleteDefaultWorkflowAsync([Path] long id, [Query] bool? updateDraftIfNeeded);

        /// <summary>
        /// Get draft workflow scheme
        /// </summary>
        /// <param name="id">The ID of the active workflow scheme that the draft was created from.</param>
        [Get("/rest/api/3/workflowscheme/{id}/draft")]
        Task<Response<AnyOf<WorkflowScheme, object>>> GetWorkflowSchemeDraftAsync([Path] long id);

        /// <summary>
        /// Update draft workflow scheme
        /// </summary>
        /// <param name="id">The ID of the active workflow scheme that the draft was created from.</param>
        /// <param name="content">Details about a workflow scheme.</param>
        [Put("/rest/api/3/workflowscheme/{id}/draft")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<WorkflowScheme, object>>> UpdateWorkflowSchemeDraftAsync([Path] long id, [Body] WorkflowScheme content);

        /// <summary>
        /// Delete draft workflow scheme
        /// </summary>
        /// <param name="id">The ID of the active workflow scheme that the draft was created from.</param>
        [Delete("/rest/api/3/workflowscheme/{id}/draft")]
        Task<object> DeleteWorkflowSchemeDraftAsync([Path] long id);

        /// <summary>
        /// Get draft default workflow
        /// </summary>
        /// <param name="id">The ID of the workflow scheme that the draft belongs to.</param>
        [Get("/rest/api/3/workflowscheme/{id}/draft/default")]
        Task<Response<AnyOf<DefaultWorkflow, object>>> GetDraftDefaultWorkflowAsync([Path] long id);

        /// <summary>
        /// Update draft default workflow
        /// </summary>
        /// <param name="id">The ID of the workflow scheme that the draft belongs to.</param>
        /// <param name="content">Details about the default workflow.</param>
        [Put("/rest/api/3/workflowscheme/{id}/draft/default")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<WorkflowScheme, object>>> UpdateDraftDefaultWorkflowAsync([Path] long id, [Body] DefaultWorkflow content);

        /// <summary>
        /// Delete draft default workflow
        /// </summary>
        /// <param name="id">The ID of the workflow scheme that the draft belongs to.</param>
        [Delete("/rest/api/3/workflowscheme/{id}/draft/default")]
        Task<Response<AnyOf<WorkflowScheme, object>>> DeleteDraftDefaultWorkflowAsync([Path] long id);

        /// <summary>
        /// Get workflow for issue type in draft workflow scheme
        /// </summary>
        /// <param name="id">The ID of the workflow scheme that the draft belongs to.</param>
        /// <param name="issueType">The ID of the issue type.</param>
        [Get("/rest/api/3/workflowscheme/{id}/draft/issuetype/{issueType}")]
        Task<Response<AnyOf<IssueTypeWorkflowMapping, object>>> GetWorkflowSchemeDraftIssueTypeAsync([Path] long id, [Path] string issueType);

        /// <summary>
        /// Set workflow for issue type in draft workflow scheme
        /// </summary>
        /// <param name="id">The ID of the workflow scheme that the draft belongs to.</param>
        /// <param name="issueType">The ID of the issue type.</param>
        /// <param name="content">Details about the mapping between an issue type and a workflow.</param>
        [Put("/rest/api/3/workflowscheme/{id}/draft/issuetype/{issueType}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<WorkflowScheme, object>>> SetWorkflowSchemeDraftIssueTypeAsync([Path] long id, [Path] string issueType, [Body] IssueTypeWorkflowMapping content);

        /// <summary>
        /// Delete workflow for issue type in draft workflow scheme
        /// </summary>
        /// <param name="id">The ID of the workflow scheme that the draft belongs to.</param>
        /// <param name="issueType">The ID of the issue type.</param>
        [Delete("/rest/api/3/workflowscheme/{id}/draft/issuetype/{issueType}")]
        Task<Response<AnyOf<WorkflowScheme, object>>> DeleteWorkflowSchemeDraftIssueTypeAsync([Path] long id, [Path] string issueType);

        /// <summary>
        /// Publish draft workflow scheme
        /// </summary>
        /// <param name="id">The ID of the workflow scheme that the draft belongs to.</param>
        /// <param name="content">Details about the status mappings for publishing a draft workflow scheme.</param>
        /// <param name="validateOnly">Whether the request only performs a validation.</param>
        [Post("/rest/api/3/workflowscheme/{id}/draft/publish")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, TaskProgressBeanObject>>> PublishDraftWorkflowSchemeAsync([Path] long id, [Body] PublishDraftWorkflowScheme content, [Query] bool? validateOnly);

        /// <summary>
        /// Get issue types for workflows in draft workflow scheme
        /// </summary>
        /// <param name="id">The ID of the workflow scheme that the draft belongs to.</param>
        /// <param name="workflowName">The name of a workflow in the scheme. Limits the results to the workflow-issue type mapping for the specified workflow.</param>
        [Get("/rest/api/3/workflowscheme/{id}/draft/workflow")]
        Task<Response<AnyOf<IssueTypesWorkflowMapping, object>>> GetDraftWorkflowAsync([Path] long id, [Query] string workflowName);

        /// <summary>
        /// Set issue types for workflow in workflow scheme
        /// </summary>
        /// <param name="id">The ID of the workflow scheme that the draft belongs to.</param>
        /// <param name="content">Details about the mapping between issue types and a workflow.</param>
        /// <param name="workflowName">The name of the workflow.</param>
        [Put("/rest/api/3/workflowscheme/{id}/draft/workflow")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<WorkflowScheme, object>>> UpdateDraftWorkflowMappingAsync([Path] long id, [Body] IssueTypesWorkflowMapping content, [Query] string workflowName);

        /// <summary>
        /// Delete issue types for workflow in draft workflow scheme
        /// </summary>
        /// <param name="id">The ID of the workflow scheme that the draft belongs to.</param>
        /// <param name="workflowName">The name of the workflow.</param>
        [Delete("/rest/api/3/workflowscheme/{id}/draft/workflow")]
        Task<object> DeleteDraftWorkflowMappingAsync([Path] long id, [Query] string workflowName);

        /// <summary>
        /// Get workflow for issue type in workflow scheme
        /// </summary>
        /// <param name="id">The ID of the workflow scheme.</param>
        /// <param name="issueType">The ID of the issue type.</param>
        /// <param name="returnDraftIfExists">Returns the mapping from the workflow scheme's draft rather than the workflow scheme, if set to true. If no draft exists, the mapping from the workflow scheme is returned.</param>
        [Get("/rest/api/3/workflowscheme/{id}/issuetype/{issueType}")]
        Task<Response<AnyOf<IssueTypeWorkflowMapping, object>>> GetWorkflowSchemeIssueTypeAsync([Path] long id, [Path] string issueType, [Query] bool? returnDraftIfExists);

        /// <summary>
        /// Set workflow for issue type in workflow scheme
        /// </summary>
        /// <param name="id">The ID of the workflow scheme.</param>
        /// <param name="issueType">The ID of the issue type.</param>
        /// <param name="content">Details about the mapping between an issue type and a workflow.</param>
        [Put("/rest/api/3/workflowscheme/{id}/issuetype/{issueType}")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<WorkflowScheme, object>>> SetWorkflowSchemeIssueTypeAsync([Path] long id, [Path] string issueType, [Body] IssueTypeWorkflowMapping content);

        /// <summary>
        /// Delete workflow for issue type in workflow scheme
        /// </summary>
        /// <param name="id">The ID of the workflow scheme.</param>
        /// <param name="issueType">The ID of the issue type.</param>
        /// <param name="updateDraftIfNeeded">Set to true to create or update the draft of a workflow scheme and update the mapping in the draft, when the workflow scheme cannot be edited. Defaults to `false`.</param>
        [Delete("/rest/api/3/workflowscheme/{id}/issuetype/{issueType}")]
        Task<Response<AnyOf<WorkflowScheme, object>>> DeleteWorkflowSchemeIssueTypeAsync([Path] long id, [Path] string issueType, [Query] bool? updateDraftIfNeeded);

        /// <summary>
        /// Get issue types for workflows in workflow scheme
        /// </summary>
        /// <param name="id">The ID of the workflow scheme.</param>
        /// <param name="workflowName">The name of a workflow in the scheme. Limits the results to the workflow-issue type mapping for the specified workflow.</param>
        /// <param name="returnDraftIfExists">Returns the mapping from the workflow scheme's draft rather than the workflow scheme, if set to true. If no draft exists, the mapping from the workflow scheme is returned.</param>
        [Get("/rest/api/3/workflowscheme/{id}/workflow")]
        Task<Response<AnyOf<IssueTypesWorkflowMapping, object>>> GetWorkflowAsync([Path] long id, [Query] string workflowName, [Query] bool? returnDraftIfExists);

        /// <summary>
        /// Set issue types for workflow in workflow scheme
        /// </summary>
        /// <param name="id">The ID of the workflow scheme.</param>
        /// <param name="content">Details about the mapping between issue types and a workflow.</param>
        /// <param name="workflowName">The name of the workflow.</param>
        [Put("/rest/api/3/workflowscheme/{id}/workflow")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<WorkflowScheme, object>>> UpdateWorkflowMappingAsync([Path] long id, [Body] IssueTypesWorkflowMapping content, [Query] string workflowName);

        /// <summary>
        /// Delete issue types for workflow in workflow scheme
        /// </summary>
        /// <param name="id">The ID of the workflow scheme.</param>
        /// <param name="workflowName">The name of the workflow.</param>
        /// <param name="updateDraftIfNeeded">Set to true to create or update the draft of a workflow scheme and delete the mapping from the draft, when the workflow scheme cannot be edited. Defaults to `false`.</param>
        [Delete("/rest/api/3/workflowscheme/{id}/workflow")]
        Task<object> DeleteWorkflowMappingAsync([Path] long id, [Query] string workflowName, [Query] bool? updateDraftIfNeeded);

        /// <summary>
        /// Get IDs of deleted worklogs
        /// </summary>
        /// <param name="since">The date and time, as a UNIX timestamp in milliseconds, after which deleted worklogs are returned.</param>
        [Get("/rest/api/3/worklog/deleted")]
        Task<Response<AnyOf<ChangedWorklogs, object>>> GetIdsOfWorklogsDeletedSinceAsync([Query] long? since);

        /// <summary>
        /// Get worklogs
        /// </summary>
        /// <param name="content">A JSON object containing a list of worklog IDs.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about worklogs in the response. This parameter accepts `properties` that returns the properties of each worklog.</param>
        [Post("/rest/api/3/worklog/list")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Worklog[], object>>> GetWorklogsForIdsAsync([Body] WorklogIdsRequestBean content, [Query] string expand);

        /// <summary>
        /// Get IDs of updated worklogs
        /// </summary>
        /// <param name="since">The date and time, as a UNIX timestamp in milliseconds, after which updated worklogs are returned.</param>
        /// <param name="expand">Use [expand](#expansion) to include additional information about worklogs in the response. This parameter accepts `properties` that returns the properties of each worklog.</param>
        [Get("/rest/api/3/worklog/updated")]
        Task<Response<AnyOf<ChangedWorklogs, object>>> GetIdsOfWorklogsModifiedSinceAsync([Query] long? since, [Query] string expand);

        /// <summary>
        /// Get app properties
        /// </summary>
        /// <param name="addonKey">The key of the app, as defined in its descriptor.</param>
        [Get("/rest/atlassian-connect/1/addons/{addonKey}/properties")]
        Task<Response<AnyOf<PropertyKeys, OperationMessage>>> AddonPropertiesResourceGetAddonPropertiesGetAsync([Path] string addonKey);

        /// <summary>
        /// Get app property
        /// </summary>
        /// <param name="addonKey">The key of the app, as defined in its descriptor.</param>
        /// <param name="propertyKey">The key of the property.</param>
        [Get("/rest/atlassian-connect/1/addons/{addonKey}/properties/{propertyKey}")]
        Task<Response<AnyOf<EntityProperty, OperationMessage>>> AddonPropertiesResourceGetAddonPropertyGetAsync([Path] string addonKey, [Path] string propertyKey);

        /// <summary>
        /// Set app property
        /// </summary>
        /// <param name="addonKey">The key of the app, as defined in its descriptor.</param>
        /// <param name="propertyKey">The key of the property.</param>
        [Put("/rest/atlassian-connect/1/addons/{addonKey}/properties/{propertyKey}")]
        [Header("Content-Type", "application/json")]
        Task<OperationMessage> AddonPropertiesResourcePutAddonPropertyPutAsync([Path] string addonKey, [Path] string propertyKey);

        /// <summary>
        /// Delete app property
        /// </summary>
        /// <param name="addonKey">The key of the app, as defined in its descriptor.</param>
        /// <param name="propertyKey">The key of the property.</param>
        [Delete("/rest/atlassian-connect/1/addons/{addonKey}/properties/{propertyKey}")]
        Task<Response<AnyOf<object, OperationMessage>>> AddonPropertiesResourceDeleteAddonPropertyDeleteAsync([Path] string addonKey, [Path] string propertyKey);

        /// <summary>
        /// Get modules
        /// </summary>
        [Get("/rest/atlassian-connect/1/app/module/dynamic")]
        Task<Response<AnyOf<ConnectModules, ErrorMessage>>> DynamicModulesResourceGetModulesGetAsync();

        /// <summary>
        /// Register modules
        /// </summary>
        /// <param name="content"></param>
        [Post("/rest/atlassian-connect/1/app/module/dynamic")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<object, ErrorMessage>>> DynamicModulesResourceRegisterModulesPostAsync([Body] ConnectModules content);

        /// <summary>
        /// Remove modules
        /// </summary>
        /// <param name="moduleKey">The key of the module to remove. To include multiple module keys, provide multiple copies of this parameter.For example, `moduleKey=dynamic-attachment-entity-property&moduleKey=dynamic-select-field`.Nonexistent keys are ignored.</param>
        [Delete("/rest/atlassian-connect/1/app/module/dynamic")]
        Task<Response<AnyOf<object, ErrorMessage>>> DynamicModulesResourceRemoveModulesDeleteAsync([Query] string[] moduleKey);

        /// <summary>
        /// Bulk update custom field value
        /// </summary>
        /// <param name="atlassianTransferId">The ID of the transfer.</param>
        /// <param name="atlassianAccountId">The Atlassian account ID of the impersonated user. This user must be a member of the site admin group.</param>
        /// <param name="content">Details of updates for a custom field.</param>
        [Put("/rest/atlassian-connect/1/migration/field")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<AppIssueFieldValueUpdateResourceUpdateIssueFieldsPutResult, object>>> AppIssueFieldValueUpdateResourceUpdateIssueFieldsPutAsync([Header("Atlassian-Transfer-Id")] string atlassianTransferId, [Header("Atlassian-Account-Id")] string atlassianAccountId, [Body] ConnectCustomFieldValues content);

        /// <summary>
        /// Bulk update entity properties
        /// </summary>
        /// <param name="atlassianTransferId">The app migration transfer ID.</param>
        /// <param name="atlassianAccountId">The Atlassian account ID of the impersonated user. This user must be a member of the site admin group.</param>
        /// <param name="entityType">The type indicating the object that contains the entity properties.</param>
        /// <param name="content"></param>
        [Put("/rest/atlassian-connect/1/migration/properties/{entityType}")]
        [Header("Content-Type", "application/json")]
        Task<object> MigrationResourceUpdateEntityPropertiesValuePutAsync([Header("Atlassian-Transfer-Id")] string atlassianTransferId, [Header("Atlassian-Account-Id")] string atlassianAccountId, [Path] string entityType, [Body] EntityPropertyDetails[] content);

        /// <summary>
        /// Get workflow transition rule configurations
        /// </summary>
        /// <param name="atlassianTransferId">The app migration transfer ID.</param>
        /// <param name="content">Details of the workflow and its transition rules.</param>
        [Post("/rest/atlassian-connect/1/migration/workflow/rule/search")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<WorkflowRulesSearchDetails, object>>> MigrationResourceWorkflowRuleSearchPostAsync([Header("Atlassian-Transfer-Id")] string atlassianTransferId, [Body] WorkflowRulesSearch content);
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Api
{
    public static class JiraApiExtensions
    {
        /// <summary>
        /// Set columns
        /// </summary>
        /// <param name="api">The Api</param>
        /// <param name="contentType">The Content-Type</param>
        /// <param name="id">The ID of the filter.</param>
        public static Task<Response<AnyOf<SetColumnsResult, object>>> SetColumnsAsync(this IJiraApi api, string contentType, long id)
        {
            return api.SetColumnsAsync(contentType, id, content);
        }

        /// <summary>
        /// Add attachment
        /// </summary>
        /// <param name="api">The Api</param>
        /// <param name="issueIdOrKey">The ID or key of the issue that attachments are added to.</param>
        public static Task<Response<AnyOf<Attachment[], object>>> AddAttachmentAsync(this IJiraApi api, string issueIdOrKey)
        {
            var content = new MultipartFormDataContent();

            return api.AddAttachmentAsync(issueIdOrKey, content);
        }

        /// <summary>
        /// Set issue navigator default columns
        /// </summary>
        /// <param name="api">The Api</param>
        /// <param name="contentType">The Content-Type</param>
        public static Task<Response<AnyOf<SetIssueNavigatorDefaultColumnsResult, object>>> SetIssueNavigatorDefaultColumnsAsync(this IJiraApi api, string contentType)
        {
            return api.SetIssueNavigatorDefaultColumnsAsync(contentType, content);
        }

        /// <summary>
        /// Set user default columns
        /// </summary>
        /// <param name="api">The Api</param>
        /// <param name="contentType">The Content-Type</param>
        /// <param name="accountId">The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.</param>
        public static Task<Response<AnyOf<SetUserColumnsResult, object>>> SetUserColumnsAsync(this IJiraApi api, string contentType, string accountId)
        {
            return api.SetUserColumnsAsync(contentType, content, accountId);
        }
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Actor : HistoryMetadataParticipant
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ActorGroup : ProjectRoleGroup
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ActorInputBean
    {
        /// <summary>
        /// The account IDs of the users to add as default actors. This parameter accepts a comma-separated list. For example, `"user":["5b10a2844c20165700ede21g", "5b109f2e9729b51b54dc274d"]`.
        /// </summary>
        public string[] User { get; set; }

        /// <summary>
        /// The name of the group to add as a default actor. This parameter accepts a comma-separated list. For example, `"group":["project-admin", "jira-developers"]`.
        /// </summary>
        public string[] Group { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ActorsMap
    {
        /// <summary>
        /// The user account ID of the user to add.
        /// </summary>
        public string[] User { get; set; }

        /// <summary>
        /// The name of the group to add.
        /// </summary>
        public string[] Group { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ActorUser : ProjectRoleUser
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Add
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AddFieldBean
    {
        /// <summary>
        /// The ID of the field to add.
        /// </summary>
        public string FieldId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AddFieldToDefaultScreenResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AddGroupBean
    {
        /// <summary>
        /// The name of the group.
        /// </summary>
        public string Name { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AddIssueTypesToContextResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AddIssueTypesToIssueTypeSchemeResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AddVoteResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AddWatcherResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AppendMappingsForIssueTypeScreenSchemeResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AppIssueFieldValueUpdateResourceUpdateIssueFieldsPutResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The application the linked item is in.
    /// </summary>
    public class Application
    {
        /// <summary>
        /// The name-spaced type of the application, used by registered rendering apps.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The name of the application. Used in conjunction with the (remote) object icon title to display a tooltip for the link's icon. The tooltip takes the format "\[application name\] icon title". Blank items are excluded from the tooltip title. If both items are blank, the icon tooltop displays as "Web Link". Grouping and sorting of links may place links without an application name last.
        /// </summary>
        public string Name { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an application property.
    /// </summary>
    public class ApplicationProperty
    {
        /// <summary>
        /// The ID of the application property. The ID and key are the same.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The key of the application property. The ID and key are the same.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The new value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The name of the application property.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the application property.
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// The data type of the application property.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The default value of the application property.
        /// </summary>
        public string DefaultValue { get; set; }

        public string Example { get; set; }

        /// <summary>
        /// The allowed values, if applicable.
        /// </summary>
        public string[] AllowedValues { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an application role.
    /// </summary>
    public class ApplicationRole
    {
        /// <summary>
        /// The key of the application role.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The groups associated with the application role.
        /// </summary>
        public string[] Groups { get; set; }

        /// <summary>
        /// The display name of the application role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The groups that are granted default access for this application role.
        /// </summary>
        public string[] DefaultGroups { get; set; }

        /// <summary>
        /// Determines whether this application role should be selected by default on user creation.
        /// </summary>
        public bool SelectedByDefault { get; set; }

        /// <summary>
        /// Deprecated.
        /// </summary>
        public bool Defined { get; set; }

        /// <summary>
        /// The maximum count of users on your license.
        /// </summary>
        public int NumberOfSeats { get; set; }

        /// <summary>
        /// The count of users remaining on your license.
        /// </summary>
        public int RemainingSeats { get; set; }

        /// <summary>
        /// The number of users counting against your license.
        /// </summary>
        public int UserCount { get; set; }

        /// <summary>
        /// The [type of users](https://confluence.atlassian.com/x/lRW3Ng) being counted against your license.
        /// </summary>
        public string UserCountDescription { get; set; }

        public bool HasUnlimitedSeats { get; set; }

        /// <summary>
        /// Indicates if the application role belongs to Jira platform (`jira-core`).
        /// </summary>
        public bool Platform { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ApplicationRoles : SimpleListWrapperApplicationRole
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ArchivedBy : User
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ArchiveProjectResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Assignee : User
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AssignFieldConfigurationSchemeToProjectResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AssignIssueResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AssignIssueTypeSchemeToProjectResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AssignIssueTypeScreenSchemeToProjectResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AssignProjectsToCustomFieldContextResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AssignSchemeToProjectResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an item associated with the changed record.
    /// </summary>
    public class AssociatedItemBean
    {
        /// <summary>
        /// The ID of the associated record.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the associated record.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of the associated record.
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// The ID of the associated parent record.
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// The name of the associated parent record.
        /// </summary>
        public string ParentName { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a field configuration to issue type mappings.
    /// </summary>
    public class AssociateFieldConfigurationsWithIssueTypesRequest
    {
        /// <summary>
        /// Field configuration to issue type mappings.
        /// </summary>
        public FieldConfigurationToIssueTypeMapping[] Mappings { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about an attachment.
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// The URL of the attachment details response.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID of the attachment.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The file name of the attachment.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Details about an attachment.
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// The datetime the attachment was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The size of the attachment.
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// The MIME type of the attachment.
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// The content of the attachment.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// The URL of a thumbnail representing the attachment.
        /// </summary>
        public string Thumbnail { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AttachmentArchive
    {
        public bool MoreAvailable { get; set; }

        public int TotalNumberOfEntriesAvailable { get; set; }

        public int TotalEntryCount { get; set; }

        public AttachmentArchiveEntry[] Entries { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AttachmentArchiveEntry
    {
        public long EntryIndex { get; set; }

        public string AbbreviatedName { get; set; }

        public string MediaType { get; set; }

        public string Name { get; set; }

        public long Size { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AttachmentArchiveImpl
    {
        /// <summary>
        /// The list of the items included in the archive.
        /// </summary>
        public AttachmentArchiveEntry[] Entries { get; set; }

        /// <summary>
        /// The number of items in the archive.
        /// </summary>
        public int TotalEntryCount { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Metadata for an item in an attachment archive.
    /// </summary>
    public class AttachmentArchiveItemReadable
    {
        /// <summary>
        /// The path of the archive item.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The position of the item within the archive.
        /// </summary>
        public long Index { get; set; }

        /// <summary>
        /// The size of the archive item.
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// The MIME type of the archive item.
        /// </summary>
        public string MediaType { get; set; }

        /// <summary>
        /// The label for the archive item.
        /// </summary>
        public string Label { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Metadata for an archive (for example a zip) and its contents.
    /// </summary>
    public class AttachmentArchiveMetadataReadable
    {
        /// <summary>
        /// The ID of the attachment.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of the archive file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The list of the items included in the archive.
        /// </summary>
        public AttachmentArchiveItemReadable[] Entries { get; set; }

        /// <summary>
        /// The number of items included in the archive.
        /// </summary>
        public long TotalEntryCount { get; set; }

        /// <summary>
        /// The MIME type of the attachment.
        /// </summary>
        public string MediaType { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Metadata for an issue attachment.
    /// </summary>
    public class AttachmentMetadata
    {
        /// <summary>
        /// The ID of the attachment.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The URL of the attachment metadata details.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The name of the attachment file.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Metadata for an issue attachment.
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// The datetime the attachment was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The size of the attachment.
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// The MIME type of the attachment.
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Metadata for an issue attachment.
        /// </summary>
        public Properties Properties { get; set; }

        /// <summary>
        /// The URL of the attachment.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// The URL of a thumbnail representing the attachment.
        /// </summary>
        public string Thumbnail { get; set; }

        /// <summary>
        /// \[EXPERIMENTAL\] - The file ID of the attachment in the media store.
        /// </summary>
        public string MediaApiFileId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the instance's attachment settings.
    /// </summary>
    public class AttachmentSettings
    {
        /// <summary>
        /// Whether the ability to add attachments is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The maximum size of attachments permitted, in bytes.
        /// </summary>
        public long UploadLimit { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// An audit record.
    /// </summary>
    public class AuditRecordBean
    {
        /// <summary>
        /// The ID of the audit record.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The summary of the audit record.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// The URL of the computer where the creation of the audit record was initiated.
        /// </summary>
        public string RemoteAddress { get; set; }

        /// <summary>
        /// Deprecated, use `authorAccountId` instead. The key of the user who created the audit record.
        /// </summary>
        public string AuthorKey { get; set; }

        /// <summary>
        /// The date and time on which the audit record was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The category of the audit record. For a list of these categories, see the help article [Auditing in Jira applications](https://confluence.atlassian.com/x/noXKM).
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// The event the audit record originated from.
        /// </summary>
        public string EventSource { get; set; }

        /// <summary>
        /// The description of the audit record.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public AssociatedItemBean ObjectItem { get; set; }

        /// <summary>
        /// The list of values changed in the record event.
        /// </summary>
        public ChangedValueBean[] ChangedValues { get; set; }

        /// <summary>
        /// The list of items associated with the changed record.
        /// </summary>
        public AssociatedItemBean[] AssociatedItems { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Container for a list of audit records.
    /// </summary>
    public class AuditRecords
    {
        /// <summary>
        /// The number of audit items skipped before the first item in this list.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// The requested or default limit on the number of audit items to be returned.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// The total number of audit items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// The list of audit items.
        /// </summary>
        public AuditRecordBean[] Records { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Author : User
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A field auto-complete suggestion.
    /// </summary>
    public class AutoCompleteSuggestion
    {
        /// <summary>
        /// The value of a suggested item.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The display name of a suggested item. If `fieldValue` or `predicateValue` are provided, the matching text is highlighted with the HTML bold tag.
        /// </summary>
        public string DisplayName { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The results from a JQL query.
    /// </summary>
    public class AutoCompleteSuggestions
    {
        /// <summary>
        /// The list of suggested item.
        /// </summary>
        public AutoCompleteSuggestion[] Results { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an avatar.
    /// </summary>
    public class Avatar
    {
        /// <summary>
        /// The ID of the avatar.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The owner of the avatar. For a system avatar the owner is null (and nothing is returned). For non-system avatars this is the appropriate identifier, such as the ID for a project or the account ID for a user.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Whether the avatar is a system avatar.
        /// </summary>
        public bool IsSystemAvatar { get; set; }

        /// <summary>
        /// Whether the avatar is used in Jira. For example, shown as a project's avatar.
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// Whether the avatar can be deleted.
        /// </summary>
        public bool IsDeletable { get; set; }

        /// <summary>
        /// The file name of the avatar icon. Returned for system avatars.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Details of an avatar.
        /// </summary>
        public Urls Urls { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about system and custom avatars.
    /// </summary>
    public class Avatars
    {
        /// <summary>
        /// System avatars list.
        /// </summary>
        public Avatar[] System { get; set; }

        /// <summary>
        /// Custom avatars list.
        /// </summary>
        public Avatar[] Custom { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AvatarUrls : AvatarUrlsBean
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class AvatarUrlsBean
    {
        /// <summary>
        /// The URL of the item's 16x16 pixel avatar.
        /// </summary>
        public string 16x16 { get; set; }

        /// <summary>
        /// The URL of the item's 24x24 pixel avatar.
        /// </summary>
        public string 24x24 { get; set; }

        /// <summary>
        /// The URL of the item's 32x32 pixel avatar.
        /// </summary>
        public string 32x32 { get; set; }

        /// <summary>
        /// The URL of the item's 48x48 pixel avatar.
        /// </summary>
        public string 48x48 { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Beans : JiraExpressionsComplexityValueBean
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Body
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the options to create for a custom field.
    /// </summary>
    public class BulkCustomFieldOptionCreateRequest
    {
        /// <summary>
        /// Details of options to create.
        /// </summary>
        public CustomFieldOptionCreate[] Options { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the options to update for a custom field.
    /// </summary>
    public class BulkCustomFieldOptionUpdateRequest
    {
        /// <summary>
        /// Details of the options to update.
        /// </summary>
        public CustomFieldOptionUpdate[] Options { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A container for the watch status of a list of issues.
    /// </summary>
    public class BulkIssueIsWatching
    {
        /// <summary>
        /// A container for the watch status of a list of issues.
        /// </summary>
        public IssuesIsWatching IssuesIsWatching { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Bulk issue property update request details.
    /// </summary>
    public class BulkIssuePropertyUpdateRequest
    {
        /// <summary>
        /// Bulk issue property update request details.
        /// </summary>
        public Value Value { get; set; }

        /// <summary>
        /// EXPERIMENTAL. The Jira expression to calculate the value of the property. The value of the expression must be an object that can be converted to JSON, such as a number, boolean, string, list, or map. The context variables available to the expression are `issue` and `user`. Issues for which the expression returns a value whose JSON representation is longer than 32768 characters are ignored.
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// Bulk issue property update request details.
        /// </summary>
        public Filter Filter { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class BulkOperationErrorResult
    {
        public int Status { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public ErrorCollection ElementErrors { get; set; }

        public int FailedElementNumber { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of global and project permissions granted to the user.
    /// </summary>
    public class BulkPermissionGrants
    {
        /// <summary>
        /// List of project permissions and the projects and issues those permissions provide access to.
        /// </summary>
        public BulkProjectPermissionGrants[] ProjectPermissions { get; set; }

        /// <summary>
        /// List of permissions granted to the user.
        /// </summary>
        public string[] GlobalPermissions { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of global permissions to look up and project permissions with associated projects and issues to look up.
    /// </summary>
    public class BulkPermissionsRequestBean
    {
        /// <summary>
        /// Project permissions with associated projects and issues to look up.
        /// </summary>
        public BulkProjectPermissions[] ProjectPermissions { get; set; }

        /// <summary>
        /// Global permissions to look up.
        /// </summary>
        public string[] GlobalPermissions { get; set; }

        /// <summary>
        /// The account ID of a user.
        /// </summary>
        public string AccountId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// List of project permissions and the projects and issues those permissions grant access to.
    /// </summary>
    public class BulkProjectPermissionGrants
    {
        /// <summary>
        /// A project permission,
        /// </summary>
        public string Permission { get; set; }

        /// <summary>
        /// IDs of the issues the user has the permission for.
        /// </summary>
        public long[] Issues { get; set; }

        /// <summary>
        /// IDs of the projects the user has the permission for.
        /// </summary>
        public long[] Projects { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of project permissions and associated issues and projects to look up.
    /// </summary>
    public class BulkProjectPermissions
    {
        /// <summary>
        /// List of issue IDs.
        /// </summary>
        public long[] Issues { get; set; }

        /// <summary>
        /// List of project IDs.
        /// </summary>
        public long[] Projects { get; set; }

        /// <summary>
        /// List of project permissions.
        /// </summary>
        public string[] Permissions { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class CancelTaskResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class CategorisedActors
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Cause : HistoryMetadataParticipant
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A change item.
    /// </summary>
    public class ChangeDetails
    {
        /// <summary>
        /// The name of the field changed.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// The type of the field changed.
        /// </summary>
        public string Fieldtype { get; set; }

        /// <summary>
        /// The ID of the field changed.
        /// </summary>
        public string FieldId { get; set; }

        /// <summary>
        /// The details of the original value.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// The details of the original value as a string.
        /// </summary>
        public string FromString { get; set; }

        /// <summary>
        /// The details of the new value.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// The details of the new value as a string.
        /// </summary>
        public string ToString { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of names changed in the record event.
    /// </summary>
    public class ChangedValueBean
    {
        /// <summary>
        /// The name of the field changed.
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// The value of the field before the change.
        /// </summary>
        public string ChangedFrom { get; set; }

        /// <summary>
        /// The value of the field after the change.
        /// </summary>
        public string ChangedTo { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a changed worklog.
    /// </summary>
    public class ChangedWorklog
    {
        /// <summary>
        /// The ID of the worklog.
        /// </summary>
        public long WorklogId { get; set; }

        /// <summary>
        /// The datetime of the change.
        /// </summary>
        public long UpdatedTime { get; set; }

        /// <summary>
        /// Details of properties associated with the change.
        /// </summary>
        public EntityProperty[] Properties { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// List of changed worklogs.
    /// </summary>
    public class ChangedWorklogs
    {
        /// <summary>
        /// Changed worklog list.
        /// </summary>
        public ChangedWorklog[] Values { get; set; }

        /// <summary>
        /// The datetime of the first worklog item in the list.
        /// </summary>
        public long Since { get; set; }

        /// <summary>
        /// The datetime of the last worklog item in the list.
        /// </summary>
        public long Until { get; set; }

        /// <summary>
        /// The URL of this changed worklogs list.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The URL of the next list of changed worklogs.
        /// </summary>
        public string NextPage { get; set; }

        public bool LastPage { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A changelog.
    /// </summary>
    public class Changelog
    {
        /// <summary>
        /// The ID of the changelog.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A changelog.
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// The date on which the change took place.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The list of items changed.
        /// </summary>
        public ChangeDetails[] Items { get; set; }

        /// <summary>
        /// A changelog.
        /// </summary>
        public HistoryMetadata HistoryMetadata { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an issue navigator column item.
    /// </summary>
    public class ColumnItem
    {
        /// <summary>
        /// The issue navigator column label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The issue navigator column value.
        /// </summary>
        public string Value { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A comment.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// The URL of the comment.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID of the comment.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A comment.
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// A comment.
        /// </summary>
        public Body Body { get; set; }

        /// <summary>
        /// The rendered version of the comment.
        /// </summary>
        public string RenderedBody { get; set; }

        /// <summary>
        /// A comment.
        /// </summary>
        public UpdateAuthor UpdateAuthor { get; set; }

        /// <summary>
        /// The date and time at which the comment was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The date and time at which the comment was updated last.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// A comment.
        /// </summary>
        public Visibility Visibility { get; set; }

        /// <summary>
        /// Whether the comment is visible in Jira Service Desk. Defaults to true when comments are created in the Jira Cloud Platform. This includes when the site doesn't use Jira Service Desk or the project isn't a Jira Service Desk project and, therefore, there is no Jira Service Desk for the issue to be visible on. To create a comment with its visibility in Jira Service Desk set to false, use the Jira Service Desk REST API [Create request comment](https://developer.atlassian.com/cloud/jira/service-desk/rest/#api-rest-servicedeskapi-request-issueIdOrKey-comment-post) operation.
        /// </summary>
        public bool JsdPublic { get; set; }

        /// <summary>
        /// Whether the comment is made by an outsider who is not part of the issue.
        /// </summary>
        public bool JsdAuthorCanSeeRequest { get; set; }

        /// <summary>
        /// A list of comment properties. Optional on create and update.
        /// </summary>
        public EntityProperty[] Properties { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Complexity : JiraExpressionsComplexityBean
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Count of issues assigned to a component.
    /// </summary>
    public class ComponentIssuesCount
    {
        /// <summary>
        /// The URL for this count of issues for a component.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The count of issues assigned to a component.
        /// </summary>
        public long IssueCount { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a component with a count of the issues it contains.
    /// </summary>
    public class ComponentWithIssueCount
    {
        /// <summary>
        /// Count of issues for the component.
        /// </summary>
        public long IssueCount { get; set; }

        /// <summary>
        /// Details about a component with a count of the issues it contains.
        /// </summary>
        public RealAssignee RealAssignee { get; set; }

        /// <summary>
        /// Whether a user is associated with `assigneeType`. For example, if the `assigneeType` is set to `COMPONENT_LEAD` but the component lead is not set, then `false` is returned.
        /// </summary>
        public bool IsAssigneeTypeValid { get; set; }

        /// <summary>
        /// The type of the assignee that is assigned to issues created with this component, when an assignee cannot be set from the `assigneeType`. For example, `assigneeType` is set to `COMPONENT_LEAD` but no component lead is set. This property is set to one of the following values: *  `PROJECT_LEAD` when `assigneeType` is `PROJECT_LEAD` and the project lead has permission to be assigned issues in the project that the component is in. *  `COMPONENT_LEAD` when `assignee`Type is `COMPONENT_LEAD` and the component lead has permission to be assigned issues in the project that the component is in. *  `UNASSIGNED` when `assigneeType` is `UNASSIGNED` and Jira is configured to allow unassigned issues. *  `PROJECT_DEFAULT` when none of the preceding cases are true.
        /// </summary>
        public string RealAssigneeType { get; set; }

        /// <summary>
        /// The key of the project to which the component is assigned.
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Not used.
        /// </summary>
        public long ProjectId { get; set; }

        /// <summary>
        /// Details about a component with a count of the issues it contains.
        /// </summary>
        public Assignee Assignee { get; set; }

        /// <summary>
        /// Details about a component with a count of the issues it contains.
        /// </summary>
        public Lead Lead { get; set; }

        /// <summary>
        /// The nominal user type used to determine the assignee for issues created with this component. See `realAssigneeType` for details on how the type of the user, and hence the user, assigned to issues is determined. Takes the following values: *  `PROJECT_LEAD` the assignee to any issues created with this component is nominally the lead for the project the component is in. *  `COMPONENT_LEAD` the assignee to any issues created with this component is nominally the lead for the component. *  `UNASSIGNED` an assignee is not set for issues created with this component. *  `PROJECT_DEFAULT` the assignee to any issues created with this component is nominally the default assignee for the project that the component is in.
        /// </summary>
        public string AssigneeType { get; set; }

        /// <summary>
        /// The description for the component.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The URL for this count of the issues contained in the component.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The name for the component.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The unique identifier for the component.
        /// </summary>
        public string Id { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A JQL query clause that consists of nested clauses. For example, `(labels in (urgent, blocker) OR lastCommentedBy = currentUser()). Note that, where nesting is not defined, the parser nests JQL clauses based on the operator precedence. For example, "A OR B AND C" is parsed as "(A OR B) AND C". See Setting the precedence of operators for more information about precedence in JQL queries.`
    /// </summary>
    public class CompoundClause
    {
        /// <summary>
        /// The list of nested clauses.
        /// </summary>
        public JqlQueryClause[] Clauses { get; set; }

        /// <summary>
        /// The operator between the clauses.
        /// </summary>
        public string Operator { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Conditions : CreateWorkflowCondition
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about the configuration of Jira.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Whether the ability for users to vote on issues is enabled. See [Configuring Jira application options](https://confluence.atlassian.com/x/uYXKM) for details.
        /// </summary>
        public bool VotingEnabled { get; set; }

        /// <summary>
        /// Whether the ability for users to watch issues is enabled. See [Configuring Jira application options](https://confluence.atlassian.com/x/uYXKM) for details.
        /// </summary>
        public bool WatchingEnabled { get; set; }

        /// <summary>
        /// Whether the ability to create unassigned issues is enabled. See [Configuring Jira application options](https://confluence.atlassian.com/x/uYXKM) for details.
        /// </summary>
        public bool UnassignedIssuesAllowed { get; set; }

        /// <summary>
        /// Whether the ability to create subtasks for issues is enabled.
        /// </summary>
        public bool SubTasksEnabled { get; set; }

        /// <summary>
        /// Whether the ability to link issues is enabled.
        /// </summary>
        public bool IssueLinkingEnabled { get; set; }

        /// <summary>
        /// Whether the ability to track time is enabled. This property is deprecated.
        /// </summary>
        public bool TimeTrackingEnabled { get; set; }

        /// <summary>
        /// Whether the ability to add attachments to issues is enabled.
        /// </summary>
        public bool AttachmentsEnabled { get; set; }

        /// <summary>
        /// Details about the configuration of Jira.
        /// </summary>
        public TimeTrackingConfiguration TimeTrackingConfiguration { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A list of custom field details.
    /// </summary>
    public class ConnectCustomFieldValue
    {
        /// <summary>
        /// The type of custom field.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The issue ID.
        /// </summary>
        public int IssueID { get; set; }

        /// <summary>
        /// The custom field ID.
        /// </summary>
        public int FieldID { get; set; }

        /// <summary>
        /// The value of string type custom field when `_type` is `StringIssueField`.
        /// </summary>
        public string String { get; set; }

        /// <summary>
        /// The value of number type custom field when `_type` is `NumberIssueField`.
        /// </summary>
        public double Number { get; set; }

        /// <summary>
        /// The value of richText type custom field when `_type` is `RichTextIssueField`.
        /// </summary>
        public string RichText { get; set; }

        /// <summary>
        /// The value of single select and multiselect custom field type when `_type` is `SingleSelectIssueField` or `MultiSelectIssueField`.
        /// </summary>
        public string OptionID { get; set; }

        /// <summary>
        /// The value of of text custom field type when `_type` is `TextIssueField`.
        /// </summary>
        public string Text { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of updates for a custom field.
    /// </summary>
    public class ConnectCustomFieldValues
    {
        /// <summary>
        /// The list of custom field update details.
        /// </summary>
        public ConnectCustomFieldValue[] UpdateValueList { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A [Connect module](https://developer.atlassian.com/cloud/jira/platform/about-jira-modules/) in the same format as in the[app descriptor](https://developer.atlassian.com/cloud/jira/platform/app-descriptor/).
    /// </summary>
    public class ConnectModule
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ConnectModules
    {
        /// <summary>
        /// A list of app modules in the same format as the `modules` property in the[app descriptor](https://developer.atlassian.com/cloud/jira/platform/app-descriptor/).
        /// </summary>
        public ConnectModule[] Modules { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A workflow transition rule.
    /// </summary>
    public class ConnectWorkflowTransitionRule
    {
        /// <summary>
        /// The ID of the transition rule.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The key of the rule, as defined in the Connect app descriptor.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public RuleConfiguration Configuration { get; set; }

        /// <summary>
        /// A workflow transition rule.
        /// </summary>
        public Transition Transition { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The list of features on a project.
    /// </summary>
    public class ContainerForProjectFeatures
    {
        /// <summary>
        /// The project features.
        /// </summary>
        public ProjectFeature[] Features { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Container for a list of registered webhooks. Webhook details are returned in the same order as the request.
    /// </summary>
    public class ContainerForRegisteredWebhooks
    {
        /// <summary>
        /// A list of registered webhooks.
        /// </summary>
        public RegisteredWebhook[] WebhookRegistrationResult { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Container for a list of webhook IDs.
    /// </summary>
    public class ContainerForWebhookIDs
    {
        /// <summary>
        /// A list of webhook IDs.
        /// </summary>
        public long[] WebhookIds { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A container for a list of workflow schemes together with the projects they are associated with.
    /// </summary>
    public class ContainerOfWorkflowSchemeAssociations
    {
        /// <summary>
        /// A list of workflow schemes together with projects they are associated with.
        /// </summary>
        public WorkflowSchemeAssociations[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A context.
    /// </summary>
    public class Context
    {
        /// <summary>
        /// The ID of the context.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of the context.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A context.
        /// </summary>
        public Scope Scope { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The project and issue type mapping with a matching custom field context.
    /// </summary>
    public class ContextForProjectAndIssueType
    {
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string ProjectId { get; set; }

        /// <summary>
        /// The ID of the issue type.
        /// </summary>
        public string IssueTypeId { get; set; }

        /// <summary>
        /// The ID of the custom field context.
        /// </summary>
        public string ContextId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the contextual configuration for a custom field.
    /// </summary>
    public class ContextualConfiguration
    {
        /// <summary>
        /// The ID of the configuration.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Deprecated, do not use.
        /// </summary>
        public long ContextId { get; set; }

        /// <summary>
        /// The ID of the field context the configuration is associated with.
        /// </summary>
        public string FieldContextId { get; set; }

        /// <summary>
        /// Details of the contextual configuration for a custom field.
        /// </summary>
        public Configuration Configuration { get; set; }

        /// <summary>
        /// Details of the contextual configuration for a custom field.
        /// </summary>
        public Schema Schema { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ContextVariables
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The converted JQL queries.
    /// </summary>
    public class ConvertedJQLQueries
    {
        /// <summary>
        /// The list of converted query strings with account IDs in place of user identifiers.
        /// </summary>
        public string[] QueryStrings { get; set; }

        /// <summary>
        /// List of queries containing user information that could not be mapped to an existing user
        /// </summary>
        public JQLQueryWithUnknownUsers[] QueriesWithUnknownUsers { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The details of a created custom field context.
    /// </summary>
    public class CreateCustomFieldContext
    {
        /// <summary>
        /// The ID of the context.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the context.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the context.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The list of project IDs associated with the context. If the list is empty, the context is global.
        /// </summary>
        public string[] ProjectIds { get; set; }

        /// <summary>
        /// The list of issue types IDs for the context. If the list is empty, the context refers to all issue types.
        /// </summary>
        public string[] IssueTypeIds { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a created issue or subtask.
    /// </summary>
    public class CreatedIssue
    {
        /// <summary>
        /// The ID of the created issue or subtask.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The key of the created issue or subtask.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The URL of the created issue or subtask.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// Details about a created issue or subtask.
        /// </summary>
        public Transition Transition { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about the issues created and the errors for requests that failed.
    /// </summary>
    public class CreatedIssues
    {
        /// <summary>
        /// Details of the issues created.
        /// </summary>
        public CreatedIssue[] Issues { get; set; }

        /// <summary>
        /// Error details for failed issue creation requests.
        /// </summary>
        public BulkOperationErrorResult[] Errors { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about the project.
    /// </summary>
    public class CreateProjectDetails
    {
        /// <summary>
        /// Project keys must be unique and start with an uppercase letter followed by one or more uppercase alphanumeric characters. The maximum length is 10 characters.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The name of the project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A brief description of the project.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// This parameter is deprecated because of privacy changes. Use `leadAccountId` instead. See the [migration guide](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details. The user name of the project lead. Either `lead` or `leadAccountId` must be set when creating a project. Cannot be provided with `leadAccountId`.
        /// </summary>
        public string Lead { get; set; }

        /// <summary>
        /// The account ID of the project lead. Either `lead` or `leadAccountId` must be set when creating a project. Cannot be provided with `lead`.
        /// </summary>
        public string LeadAccountId { get; set; }

        /// <summary>
        /// A link to information about this project, such as project documentation
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The default assignee when creating issues for this project.
        /// </summary>
        public string AssigneeType { get; set; }

        /// <summary>
        /// An integer value for the project's avatar.
        /// </summary>
        public long AvatarId { get; set; }

        /// <summary>
        /// The ID of the issue security scheme for the project, which enables you to control who can and cannot view issues. Use the [Get issue security schemes](#api-rest-api-3-issuesecurityschemes-get) resource to get all issue security scheme IDs.
        /// </summary>
        public long IssueSecurityScheme { get; set; }

        /// <summary>
        /// The ID of the permission scheme for the project. Use the [Get all permission schemes](#api-rest-api-3-permissionscheme-get) resource to see a list of all permission scheme IDs.
        /// </summary>
        public long PermissionScheme { get; set; }

        /// <summary>
        /// The ID of the notification scheme for the project. Use the [Get notification schemes](#api-rest-api-3-notificationscheme-get) resource to get a list of notification scheme IDs.
        /// </summary>
        public long NotificationScheme { get; set; }

        /// <summary>
        /// The ID of the project's category. A complete list of category IDs is found using the [Get all project categories](#api-rest-api-3-projectCategory-get) operation.
        /// </summary>
        public long CategoryId { get; set; }

        /// <summary>
        /// The [project type](https://confluence.atlassian.com/x/GwiiLQ#Jiraapplicationsoverview-Productfeaturesandprojecttypes), which defines the application-specific feature set. If you don't specify the project template you have to specify the project type.
        /// </summary>
        public string ProjectTypeKey { get; set; }

        /// <summary>
        /// A predefined configuration for a project. The type of the `projectTemplateKey` must match with the type of the `projectTypeKey`.
        /// </summary>
        public string ProjectTemplateKey { get; set; }

        /// <summary>
        /// The ID of the workflow scheme for the project. Use the [Get all workflow schemes](#api-rest-api-3-workflowscheme-get) operation to get a list of workflow scheme IDs. If you specify the workflow scheme you cannot specify the project template key.
        /// </summary>
        public long WorkflowScheme { get; set; }

        /// <summary>
        /// The ID of the issue type screen scheme for the project. Use the [Get all issue type screen schemes](#api-rest-api-3-issuetypescreenscheme-get) operation to get a list of issue type screen scheme IDs. If you specify the issue type screen scheme you cannot specify the project template key.
        /// </summary>
        public long IssueTypeScreenScheme { get; set; }

        /// <summary>
        /// The ID of the issue type scheme for the project. Use the [Get all issue type schemes](#api-rest-api-3-issuetypescheme-get) operation to get a list of issue type scheme IDs. If you specify the issue type scheme you cannot specify the project template key.
        /// </summary>
        public long IssueTypeScheme { get; set; }

        /// <summary>
        /// The ID of the field configuration scheme for the project. Use the [Get all field configuration schemes](#api-rest-api-3-fieldconfigurationscheme-get) operation to get a list of field configuration scheme IDs. If you specify the field configuration scheme you cannot specify the project template key.
        /// </summary>
        public long FieldConfigurationScheme { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class CreateUpdateRoleRequestBean
    {
        /// <summary>
        /// The name of the project role. Must be unique. Cannot begin or end with whitespace. The maximum length is 255 characters. Required when creating a project role. Optional when partially updating a project role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A description of the project role. Required when fully updating a project role. Optional when creating or partially updating a project role.
        /// </summary>
        public string Description { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A workflow transition condition.
    /// </summary>
    public class CreateWorkflowCondition
    {
        /// <summary>
        /// The compound condition operator.
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// The list of workflow conditions.
        /// </summary>
        public CreateWorkflowCondition[] Conditions { get; set; }

        /// <summary>
        /// The type of the transition rule.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A workflow transition condition.
        /// </summary>
        public Configuration Configuration { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The details of a workflow.
    /// </summary>
    public class CreateWorkflowDetails
    {
        /// <summary>
        /// The name of the workflow. The name must be unique. The maximum length is 255 characters. Characters can be separated by a whitespace but the name cannot start or end with a whitespace.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the workflow. The maximum length is 1000 characters.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The transitions of the workflow. For the request to be valid, these transitions must: *  include one *initial* transition. *  not use the same name for a *global* and *directed* transition. *  have a unique name for each *global* transition. *  have a unique 'to' status for each *global* transition. *  have unique names for each transition from a status. *  not have a 'from' status on *initial* and *global* transitions. *  have a 'from' status on *directed* transitions.All the transition statuses must be included in `statuses`.
        /// </summary>
        public CreateWorkflowTransitionDetails[] Transitions { get; set; }

        /// <summary>
        /// The statuses of the workflow. Any status that does not include a transition is added to the workflow without a transition.
        /// </summary>
        public CreateWorkflowStatusDetails[] Statuses { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The details of a transition status.
    /// </summary>
    public class CreateWorkflowStatusDetails
    {
        /// <summary>
        /// The ID of the status.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The details of a transition status.
        /// </summary>
        public Properties Properties { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The details of a workflow transition.
    /// </summary>
    public class CreateWorkflowTransitionDetails
    {
        /// <summary>
        /// The name of the transition. The maximum length is 60 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the transition. The maximum length is 1000 characters.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The statuses the transition can start from.
        /// </summary>
        public string[] From { get; set; }

        /// <summary>
        /// The status the transition goes to.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// The type of the transition.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The details of a workflow transition.
        /// </summary>
        public Rules Rules { get; set; }

        /// <summary>
        /// The details of a workflow transition.
        /// </summary>
        public Screen Screen { get; set; }

        /// <summary>
        /// The details of a workflow transition.
        /// </summary>
        public Properties Properties { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A workflow transition rule.
    /// </summary>
    public class CreateWorkflowTransitionRule
    {
        /// <summary>
        /// The type of the transition rule.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A workflow transition rule.
        /// </summary>
        public Configuration Configuration { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The details of a workflow transition rules.
    /// </summary>
    public class CreateWorkflowTransitionRulesDetails
    {
        /// <summary>
        /// The details of a workflow transition rules.
        /// </summary>
        public Conditions Conditions { get; set; }

        /// <summary>
        /// The workflow validators.
        /// </summary>
        public CreateWorkflowTransitionRule[] Validators { get; set; }

        /// <summary>
        /// The workflow post functions.
        /// </summary>
        public CreateWorkflowTransitionRule[] PostFunctions { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The details of a transition screen.
    /// </summary>
    public class CreateWorkflowTransitionScreenDetails
    {
        /// <summary>
        /// The ID of the screen.
        /// </summary>
        public string Id { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class CurrentValue
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class CustomContextVariable
    {
        /// <summary>
        /// Type of custom context variable.
        /// </summary>
        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of configurations for a custom field.
    /// </summary>
    public class CustomFieldConfigurations
    {
        /// <summary>
        /// The list of custom field configuration details.
        /// </summary>
        public ContextualConfiguration[] Configurations { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The details of a custom field context.
    /// </summary>
    public class CustomFieldContext
    {
        /// <summary>
        /// The ID of the context.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the context.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the context.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Whether the context is global.
        /// </summary>
        public bool IsGlobalContext { get; set; }

        /// <summary>
        /// Whether the context apply to all issue types.
        /// </summary>
        public bool IsAnyIssueType { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class CustomFieldContextDefaultValue
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default value for a cascading select custom field.
    /// </summary>
    public class CustomFieldContextDefaultValueCascadingOption
    {
        /// <summary>
        /// The ID of the context.
        /// </summary>
        public string ContextId { get; set; }

        /// <summary>
        /// The ID of the default option.
        /// </summary>
        public string OptionId { get; set; }

        /// <summary>
        /// The ID of the default cascading option.
        /// </summary>
        public string CascadingOptionId { get; set; }

        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default value for a Date custom field.
    /// </summary>
    public class CustomFieldContextDefaultValueDate
    {
        /// <summary>
        /// The default date in ISO format. Ignored if `useCurrent` is true.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Whether to use the current date.
        /// </summary>
        public bool UseCurrent { get; set; }

        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default value for a date time custom field.
    /// </summary>
    public class CustomFieldContextDefaultValueDateTime
    {
        /// <summary>
        /// The default date-time in ISO format. Ignored if `useCurrent` is true.
        /// </summary>
        public string DateTime { get; set; }

        /// <summary>
        /// Whether to use the current date.
        /// </summary>
        public bool UseCurrent { get; set; }

        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Default value for a float (number) custom field.
    /// </summary>
    public class CustomFieldContextDefaultValueFloat
    {
        /// <summary>
        /// The default floating-point number.
        /// </summary>
        public double Number { get; set; }

        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Default value for a labels custom field.
    /// </summary>
    public class CustomFieldContextDefaultValueLabels
    {
        /// <summary>
        /// The default labels value.
        /// </summary>
        public string[] Labels { get; set; }

        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default value for a multiple group picker custom field.
    /// </summary>
    public class CustomFieldContextDefaultValueMultipleGroupPicker
    {
        /// <summary>
        /// The ID of the context.
        /// </summary>
        public string ContextId { get; set; }

        /// <summary>
        /// The IDs of the default groups.
        /// </summary>
        public string[] GroupIds { get; set; }

        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default value for a multi-select custom field.
    /// </summary>
    public class CustomFieldContextDefaultValueMultipleOption
    {
        /// <summary>
        /// The ID of the context.
        /// </summary>
        public string ContextId { get; set; }

        /// <summary>
        /// The list of IDs of the default options.
        /// </summary>
        public string[] OptionIds { get; set; }

        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default value for a multiple version picker custom field.
    /// </summary>
    public class CustomFieldContextDefaultValueMultipleVersionPicker
    {
        /// <summary>
        /// The IDs of the default versions.
        /// </summary>
        public string[] VersionIds { get; set; }

        /// <summary>
        /// The order the pickable versions are displayed in. If not provided, the released-first order is used. Available version orders are `"releasedFirst"` and `"unreleasedFirst"`.
        /// </summary>
        public string VersionOrder { get; set; }

        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default value for a User Picker (multiple) custom field.
    /// </summary>
    public class CustomFieldContextDefaultValueMultiUserPicker
    {
        /// <summary>
        /// The ID of the context.
        /// </summary>
        public string ContextId { get; set; }

        /// <summary>
        /// The IDs of the default users.
        /// </summary>
        public string[] AccountIds { get; set; }

        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default value for a project custom field.
    /// </summary>
    public class CustomFieldContextDefaultValueProject
    {
        /// <summary>
        /// The ID of the context.
        /// </summary>
        public string ContextId { get; set; }

        /// <summary>
        /// The ID of the default project.
        /// </summary>
        public string ProjectId { get; set; }

        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default text for a read only custom field.
    /// </summary>
    public class CustomFieldContextDefaultValueReadOnly
    {
        /// <summary>
        /// The default text. The maximum length is 255 characters.
        /// </summary>
        public string Text { get; set; }

        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default value for a group picker custom field.
    /// </summary>
    public class CustomFieldContextDefaultValueSingleGroupPicker
    {
        /// <summary>
        /// The ID of the context.
        /// </summary>
        public string ContextId { get; set; }

        /// <summary>
        /// The ID of the the default group.
        /// </summary>
        public string GroupId { get; set; }

        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default value for a single select custom field.
    /// </summary>
    public class CustomFieldContextDefaultValueSingleOption
    {
        /// <summary>
        /// The ID of the context.
        /// </summary>
        public string ContextId { get; set; }

        /// <summary>
        /// The ID of the default option.
        /// </summary>
        public string OptionId { get; set; }

        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default value for a version picker custom field.
    /// </summary>
    public class CustomFieldContextDefaultValueSingleVersionPicker
    {
        /// <summary>
        /// The ID of the default version.
        /// </summary>
        public string VersionId { get; set; }

        /// <summary>
        /// The order the pickable versions are displayed in. If not provided, the released-first order is used. Available version orders are `"releasedFirst"` and `"unreleasedFirst"`.
        /// </summary>
        public string VersionOrder { get; set; }

        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default text for a text area custom field.
    /// </summary>
    public class CustomFieldContextDefaultValueTextArea
    {
        /// <summary>
        /// The default text. The maximum length is 32767 characters.
        /// </summary>
        public string Text { get; set; }

        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default text for a text custom field.
    /// </summary>
    public class CustomFieldContextDefaultValueTextField
    {
        /// <summary>
        /// The default text. The maximum length is 254 characters.
        /// </summary>
        public string Text { get; set; }

        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Default values to update.
    /// </summary>
    public class CustomFieldContextDefaultValueUpdate
    {
        public CustomFieldContextDefaultValue[] DefaultValues { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default value for a URL custom field.
    /// </summary>
    public class CustomFieldContextDefaultValueURL
    {
        /// <summary>
        /// The ID of the context.
        /// </summary>
        public string ContextId { get; set; }

        /// <summary>
        /// The default URL.
        /// </summary>
        public string Url { get; set; }

        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the custom field options for a context.
    /// </summary>
    public class CustomFieldContextOption
    {
        /// <summary>
        /// The ID of the custom field option.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The value of the custom field option.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// For cascading options, the ID of the custom field option containing the cascading option.
        /// </summary>
        public string OptionId { get; set; }

        /// <summary>
        /// Whether the option is disabled.
        /// </summary>
        public bool Disabled { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a context to project association.
    /// </summary>
    public class CustomFieldContextProjectMapping
    {
        /// <summary>
        /// The ID of the context.
        /// </summary>
        public string ContextId { get; set; }

        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string ProjectId { get; set; }

        /// <summary>
        /// Whether context is global.
        /// </summary>
        public bool IsGlobalContext { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Defaults for a User Picker (single) custom field.
    /// </summary>
    public class CustomFieldContextSingleUserPickerDefaults
    {
        /// <summary>
        /// The ID of the context.
        /// </summary>
        public string ContextId { get; set; }

        /// <summary>
        /// The ID of the default user.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public UserFilter UserFilter { get; set; }

        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a custom field context.
    /// </summary>
    public class CustomFieldContextUpdateDetails
    {
        /// <summary>
        /// The name of the custom field context. The name must be unique. The maximum length is 255 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the custom field context. The maximum length is 255 characters.
        /// </summary>
        public string Description { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A list of custom field options for a context.
    /// </summary>
    public class CustomFieldCreatedContextOptionsList
    {
        /// <summary>
        /// The created custom field options.
        /// </summary>
        public CustomFieldContextOption[] Options { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class CustomFieldDefinitionJsonBean
    {
        /// <summary>
        /// The name of the custom field, which is displayed in Jira. This is not the unique identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the custom field, which is displayed in Jira.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The type of the custom field. These built-in custom field types are available: *  `cascadingselect`: Enables values to be selected from two levels of select lists (value: `com.atlassian.jira.plugin.system.customfieldtypes:cascadingselect`) *  `datepicker`: Stores a date using a picker control (value: `com.atlassian.jira.plugin.system.customfieldtypes:datepicker`) *  `datetime`: Stores a date with a time component (value: `com.atlassian.jira.plugin.system.customfieldtypes:datetime`) *  `float`: Stores and validates a numeric (floating point) input (value: `com.atlassian.jira.plugin.system.customfieldtypes:float`) *  `grouppicker`: Stores a user group using a picker control (value: `com.atlassian.jira.plugin.system.customfieldtypes:grouppicker`) *  `importid`: A read-only field that stores the ID the issue had in the system it was imported from (value: `com.atlassian.jira.plugin.system.customfieldtypes:importid`) *  `labels`: Stores labels (value: `com.atlassian.jira.plugin.system.customfieldtypes:labels`) *  `multicheckboxes`: Stores multiple values using checkboxes (value: ``) *  `multigrouppicker`: Stores multiple user groups using a picker control (value: ``) *  `multiselect`: Stores multiple values using a select list (value: `com.atlassian.jira.plugin.system.customfieldtypes:multicheckboxes`) *  `multiuserpicker`: Stores multiple users using a picker control (value: `com.atlassian.jira.plugin.system.customfieldtypes:multigrouppicker`) *  `multiversion`: Stores multiple versions from the versions available in a project using a picker control (value: `com.atlassian.jira.plugin.system.customfieldtypes:multiversion`) *  `project`: Stores a project from a list of projects that the user is permitted to view (value: `com.atlassian.jira.plugin.system.customfieldtypes:project`) *  `radiobuttons`: Stores a value using radio buttons (value: `com.atlassian.jira.plugin.system.customfieldtypes:radiobuttons`) *  `readonlyfield`: Stores a read-only text value, which can only be populated via the API (value: `com.atlassian.jira.plugin.system.customfieldtypes:readonlyfield`) *  `select`: Stores a value from a configurable list of options (value: `com.atlassian.jira.plugin.system.customfieldtypes:select`) *  `textarea`: Stores a long text string using a multiline text area (value: `com.atlassian.jira.plugin.system.customfieldtypes:textarea`) *  `textfield`: Stores a text string using a single-line text box (value: `com.atlassian.jira.plugin.system.customfieldtypes:textfield`) *  `url`: Stores a URL (value: `com.atlassian.jira.plugin.system.customfieldtypes:url`) *  `userpicker`: Stores a user using a picker control (value: `com.atlassian.jira.plugin.system.customfieldtypes:userpicker`) *  `version`: Stores a version using a picker control (value: `com.atlassian.jira.plugin.system.customfieldtypes:version`)To create a field based on a [Forge custom field type](https://developer.atlassian.com/platform/forge/manifest-reference/modules/#jira-custom-field-type--beta-), use the ID of the Forge custom field type as the value. For example, `ari:cloud:ecosystem::extension/e62f20a2-4b61-4dbe-bfb9-9a88b5e3ac84/548c5df1-24aa-4f7c-bbbb-3038d947cb05/static/my-cf-type-key`.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The searcher defines the way the field is searched in Jira. For example, *com.atlassian.jira.plugin.system.customfieldtypes:grouppickersearcher*.  The search UI (basic search and JQL search) will display different operations and values for the field, based on the field searcher. You must specify a searcher that is valid for the field type, as listed below (abbreviated values shown): *  `cascadingselect`: `cascadingselectsearcher` *  `datepicker`: `daterange` *  `datetime`: `datetimerange` *  `float`: `exactnumber` or `numberrange` *  `grouppicker`: `grouppickersearcher` *  `importid`: `exactnumber` or `numberrange` *  `labels`: `labelsearcher` *  `multicheckboxes`: `multiselectsearcher` *  `multigrouppicker`: `multiselectsearcher` *  `multiselect`: `multiselectsearcher` *  `multiuserpicker`: `userpickergroupsearcher` *  `multiversion`: `versionsearcher` *  `project`: `projectsearcher` *  `radiobuttons`: `multiselectsearcher` *  `readonlyfield`: `textsearcher` *  `select`: `multiselectsearcher` *  `textarea`: `textsearcher` *  `textfield`: `textsearcher` *  `url`: `exacttextsearcher` *  `userpicker`: `userpickergroupsearcher` *  `version`: `versionsearcher`If no searcher is provided, the field isn't searchable. However, [Forge custom fields](https://developer.atlassian.com/platform/forge/manifest-reference/modules/#jira-custom-field-type--beta-) have a searcher set automatically, so are always searchable.
        /// </summary>
        public string SearcherKey { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a custom option for a field.
    /// </summary>
    public class CustomFieldOption
    {
        /// <summary>
        /// The URL of these custom field option details.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The value of the custom field option.
        /// </summary>
        public string Value { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a custom field option to create.
    /// </summary>
    public class CustomFieldOptionCreate
    {
        /// <summary>
        /// The value of the custom field option.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// For cascading options, the ID of the custom field object containing the cascading option.
        /// </summary>
        public string OptionId { get; set; }

        /// <summary>
        /// Whether the option is disabled.
        /// </summary>
        public bool Disabled { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a custom field option for a context.
    /// </summary>
    public class CustomFieldOptionUpdate
    {
        /// <summary>
        /// The ID of the custom field option.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The value of the custom field option.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Whether the option is disabled.
        /// </summary>
        public bool Disabled { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about the replacement for a deleted version.
    /// </summary>
    public class CustomFieldReplacement
    {
        /// <summary>
        /// The ID of the custom field in which to replace the version number.
        /// </summary>
        public long CustomFieldId { get; set; }

        /// <summary>
        /// The version number to use as a replacement for the deleted version.
        /// </summary>
        public long MoveTo { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A list of custom field options for a context.
    /// </summary>
    public class CustomFieldUpdatedContextOptionsList
    {
        /// <summary>
        /// The updated custom field options.
        /// </summary>
        public CustomFieldOptionUpdate[] Options { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A list of issue IDs and the value to update a custom field to.
    /// </summary>
    public class CustomFieldValueUpdate
    {
        /// <summary>
        /// The list of issue IDs.
        /// </summary>
        public long[] IssueIds { get; set; }

        /// <summary>
        /// A list of issue IDs and the value to update a custom field to.
        /// </summary>
        public Value Value { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of updates for a custom field.
    /// </summary>
    public class CustomFieldValueUpdateDetails
    {
        /// <summary>
        /// The list of custom field update details.
        /// </summary>
        public CustomFieldValueUpdate[] Updates { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a dashboard.
    /// </summary>
    public class Dashboard
    {
        public string Description { get; set; }

        /// <summary>
        /// The ID of the dashboard.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Whether the dashboard is selected as a favorite by the user.
        /// </summary>
        public bool IsFavourite { get; set; }

        /// <summary>
        /// The name of the dashboard.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Details of a dashboard.
        /// </summary>
        public Owner Owner { get; set; }

        /// <summary>
        /// The number of users who have this dashboard as a favorite.
        /// </summary>
        public long Popularity { get; set; }

        /// <summary>
        /// The rank of this dashboard.
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// The URL of these dashboard details.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The details of any view share permissions for the dashboard.
        /// </summary>
        public SharePermission[] SharePermissions { get; set; }

        /// <summary>
        /// The details of any edit share permissions for the dashboard.
        /// </summary>
        public SharePermission[] EditPermissions { get; set; }

        /// <summary>
        /// The URL of the dashboard.
        /// </summary>
        public string View { get; set; }

        /// <summary>
        /// Whether the current user has permission to edit the dashboard.
        /// </summary>
        public bool IsWritable { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a dashboard.
    /// </summary>
    public class DashboardDetails
    {
        /// <summary>
        /// The name of the dashboard.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the dashboard.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The share permissions for the dashboard.
        /// </summary>
        public SharePermission[] SharePermissions { get; set; }

        /// <summary>
        /// The edit permissions for the dashboard.
        /// </summary>
        public SharePermission[] EditPermissions { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the scope of the default sharing for new filters and dashboards.
    /// </summary>
    public class DefaultShareScope
    {
        /// <summary>
        /// The scope of the default sharing for new filters and dashboards: *  `AUTHENTICATED` Shared with all logged-in users. *  `GLOBAL` Shared with all logged-in users. This shows as `AUTHENTICATED` in the response. *  `PRIVATE` Not shared with any users.
        /// </summary>
        public string Scope { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class DefaultValue
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about the default workflow.
    /// </summary>
    public class DefaultWorkflow
    {
        /// <summary>
        /// The name of the workflow to set as the default workflow.
        /// </summary>
        public string Workflow { get; set; }

        /// <summary>
        /// Whether a draft workflow scheme is created or updated when updating an active workflow scheme. The draft is updated with the new default workflow. Defaults to `false`.
        /// </summary>
        public bool UpdateDraftIfNeeded { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class DeleteAndReplaceVersionBean
    {
        /// <summary>
        /// The ID of the version to update `fixVersion` to when the field contains the deleted version.
        /// </summary>
        public long MoveFixIssuesTo { get; set; }

        /// <summary>
        /// The ID of the version to update `affectedVersion` to when the field contains the deleted version.
        /// </summary>
        public long MoveAffectedIssuesTo { get; set; }

        /// <summary>
        /// An array of custom field IDs (`customFieldId`) and version IDs (`moveTo`) to update when the fields contain the deleted version.
        /// </summary>
        public CustomFieldReplacement[] CustomFieldReplacementList { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class DeleteAndReplaceVersionResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class DeleteCustomFieldContextResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class DeleteCustomFieldResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class DeletedBy : User
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class DeleteFieldConfigurationResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class DeleteFieldConfigurationSchemeResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class DeleteIssueFieldOptionResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class DeleteIssueTypeSchemeResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class DeleteIssueTypeScreenSchemeResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class DeleteLocaleResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a workflow.
    /// </summary>
    public class DeprecatedWorkflow
    {
        /// <summary>
        /// The name of the workflow.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the workflow.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The datetime the workflow was last modified.
        /// </summary>
        public string LastModifiedDate { get; set; }

        /// <summary>
        /// This property is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.
        /// </summary>
        public string LastModifiedUser { get; set; }

        /// <summary>
        /// The account ID of the user that last modified the workflow.
        /// </summary>
        public string LastModifiedUserAccountId { get; set; }

        /// <summary>
        /// The number of steps included in the workflow.
        /// </summary>
        public int Steps { get; set; }

        /// <summary>
        /// Details about a workflow.
        /// </summary>
        public Scope Scope { get; set; }

        public bool Default { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class DoTransitionResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Edit
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class EditIssueResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Editmeta : IssueUpdateMetadata
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Elements
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// An entity property, for more information see [Entity properties](https://developer.atlassian.com/cloud/jira/platform/jira-entity-properties/).
    /// </summary>
    public class EntityProperty
    {
        /// <summary>
        /// The key of the property. Required on create and update.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// An entity property, for more information see [Entity properties](https://developer.atlassian.com/cloud/jira/platform/jira-entity-properties/).
        /// </summary>
        public Value Value { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class EntityPropertyDetails
    {
        /// <summary>
        /// The entity property ID.
        /// </summary>
        public double EntityId { get; set; }

        /// <summary>
        /// The entity property key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The new value of the entity property.
        /// </summary>
        public string Value { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Error messages from an operation.
    /// </summary>
    public class ErrorCollection
    {
        /// <summary>
        /// The list of error messages produced by this operation. For example, "input parameter 'key' must be provided"
        /// </summary>
        public string[] ErrorMessages { get; set; }

        /// <summary>
        /// Error messages from an operation.
        /// </summary>
        public Errors Errors { get; set; }

        public int Status { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ErrorMessage
    {
        /// <summary>
        /// The error message.
        /// </summary>
        public string Message { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Errors
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a notification associated with an event.
    /// </summary>
    public class EventNotification
    {
        /// <summary>
        /// Expand options that include additional event notification details in the response.
        /// </summary>
        public string Expand { get; set; }

        /// <summary>
        /// The ID of the notification.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Identifies the recipients of the notification.
        /// </summary>
        public string NotificationType { get; set; }

        /// <summary>
        /// The value of the `notificationType`: *  `User` The `parameter` is the user account ID. *  `Group` The `parameter` is the group name. *  `ProjectRole` The `parameter` is the project role ID. *  `UserCustomField` The `parameter` is the ID of the custom field. *  `GroupCustomField` The `parameter` is the ID of the custom field.
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        /// Details about a notification associated with an event.
        /// </summary>
        public Group Group { get; set; }

        /// <summary>
        /// Details about a notification associated with an event.
        /// </summary>
        public Field Field { get; set; }

        /// <summary>
        /// The email address.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Details about a notification associated with an event.
        /// </summary>
        public ProjectRole ProjectRole { get; set; }

        /// <summary>
        /// Details about a notification associated with an event.
        /// </summary>
        public User User { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ExpensiveOperations : JiraExpressionsComplexityValueBean
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ExtraData
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a failed webhook.
    /// </summary>
    public class FailedWebhook
    {
        /// <summary>
        /// The webhook ID, as sent in the `X-Atlassian-Webhook-Identifier` header with the webhook.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The webhook body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// The original webhook destination.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The time the webhook was added to the list of failed webhooks (that is, the time of the last failed retry).
        /// </summary>
        public long FailureTime { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of failed webhooks.
    /// </summary>
    public class FailedWebhooks
    {
        /// <summary>
        /// The list of webhooks.
        /// </summary>
        public FailedWebhook[] Values { get; set; }

        /// <summary>
        /// The maximum number of items on the page. If the list of values is shorter than this number, then there are no more pages.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The URL to the next page of results. Present only if the request returned at least one result.The next page may be empty at the time of receiving the response, but new failed webhooks may appear in time. You can save the URL to the next page and query for new results periodically (for example, every hour).
        /// </summary>
        public string Next { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a field.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// The ID of the field.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public JsonTypeBean Schema { get; set; }

        /// <summary>
        /// The description of the field.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The key of the field.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Whether the field is locked.
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// Whether the field is shown on screen or not.
        /// </summary>
        public bool IsUnscreenable { get; set; }

        /// <summary>
        /// The searcher key of the field. Returned for custom fields.
        /// </summary>
        public string SearcherKey { get; set; }

        /// <summary>
        /// Number of screens where the field is used.
        /// </summary>
        public long ScreensCount { get; set; }

        /// <summary>
        /// Number of contexts where the field is used.
        /// </summary>
        public long ContextsCount { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public FieldLastUsed LastUsed { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A clause that asserts whether a field was changed. For example, `status CHANGED AFTER startOfMonth(-1M)`.See [CHANGED](https://confluence.atlassian.com/x/dgiiLQ#Advancedsearching-operatorsreference-CHANGEDCHANGED) for more information about the CHANGED operator.
    /// </summary>
    public class FieldChangedClause
    {
        /// <summary>
        /// not-used
        /// </summary>
        public JqlQueryField Field { get; set; }

        /// <summary>
        /// The operator applied to the field.
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// The list of time predicates.
        /// </summary>
        public JqlQueryClauseTimePredicate[] Predicates { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a field configuration.
    /// </summary>
    public class FieldConfiguration
    {
        /// <summary>
        /// The ID of the field configuration.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of the field configuration.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the field configuration.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Whether the field configuration is the default.
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a field configuration.
    /// </summary>
    public class FieldConfigurationDetails
    {
        /// <summary>
        /// The name of the field configuration. Must be unique.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the field configuration.
        /// </summary>
        public string Description { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The field configuration for an issue type.
    /// </summary>
    public class FieldConfigurationIssueTypeItem
    {
        /// <summary>
        /// The ID of the field configuration scheme.
        /// </summary>
        public string FieldConfigurationSchemeId { get; set; }

        /// <summary>
        /// The ID of the issue type or *default*. When set to *default* this field configuration issue type item applies to all issue types without a field configuration.
        /// </summary>
        public string IssueTypeId { get; set; }

        /// <summary>
        /// The ID of the field configuration.
        /// </summary>
        public string FieldConfigurationId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A field within a field configuration.
    /// </summary>
    public class FieldConfigurationItem
    {
        /// <summary>
        /// The ID of the field within the field configuration.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The description of the field within the field configuration.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Whether the field is hidden in the field configuration.
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// Whether the field is required in the field configuration.
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// The renderer type for the field within the field configuration.
        /// </summary>
        public string Renderer { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of field configuration items.
    /// </summary>
    public class FieldConfigurationItemsDetails
    {
        /// <summary>
        /// Details of fields in a field configuration.
        /// </summary>
        public FieldConfigurationItem[] FieldConfigurationItems { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a field configuration scheme.
    /// </summary>
    public class FieldConfigurationScheme
    {
        /// <summary>
        /// The ID of the field configuration scheme.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the field configuration scheme.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the field configuration scheme.
        /// </summary>
        public string Description { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Associated field configuration scheme and project.
    /// </summary>
    public class FieldConfigurationSchemeProjectAssociation
    {
        /// <summary>
        /// The ID of the field configuration scheme. If the field configuration scheme ID is `null`, the operation assigns the default field configuration scheme.
        /// </summary>
        public string FieldConfigurationSchemeId { get; set; }

        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string ProjectId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Project list with assigned field configuration schema.
    /// </summary>
    public class FieldConfigurationSchemeProjects
    {
        /// <summary>
        /// not-used
        /// </summary>
        public FieldConfigurationScheme FieldConfigurationScheme { get; set; }

        /// <summary>
        /// The IDs of projects using the field configuration scheme.
        /// </summary>
        public string[] ProjectIds { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The field configuration to issue type mapping.
    /// </summary>
    public class FieldConfigurationToIssueTypeMapping
    {
        /// <summary>
        /// The ID of the issue type or *default*. When set to *default* this field configuration issue type item applies to all issue types without a field configuration. An issue type can be included only once in a request.
        /// </summary>
        public string IssueTypeId { get; set; }

        /// <summary>
        /// The ID of the field configuration.
        /// </summary>
        public string FieldConfigurationId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a field.
    /// </summary>
    public class FieldDetails
    {
        /// <summary>
        /// The ID of the field.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The key of the field.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The name of the field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether the field is a custom field.
        /// </summary>
        public bool Custom { get; set; }

        /// <summary>
        /// Whether the content of the field can be used to order lists.
        /// </summary>
        public bool Orderable { get; set; }

        /// <summary>
        /// Whether the field can be used as a column on the issue navigator.
        /// </summary>
        public bool Navigable { get; set; }

        /// <summary>
        /// Whether the content of the field can be searched.
        /// </summary>
        public bool Searchable { get; set; }

        /// <summary>
        /// The names that can be used to reference the field in an advanced search. For more information, see [Advanced searching - fields reference](https://confluence.atlassian.com/x/gwORLQ).
        /// </summary>
        public string[] ClauseNames { get; set; }

        /// <summary>
        /// Details about a field.
        /// </summary>
        public Scope Scope { get; set; }

        /// <summary>
        /// Details about a field.
        /// </summary>
        public Schema Schema { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Information about the most recent use of a field.
    /// </summary>
    public class FieldLastUsed
    {
        /// <summary>
        /// Last used value type: *  *TRACKED*: field is tracked and a last used date is available. *  *NOT\_TRACKED*: field is not tracked, last used date is not available. *  *NO\_INFORMATION*: field is tracked, but no last used date is available.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The date when the value of the field last changed.
        /// </summary>
        public DateTime Value { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The metadata describing an issue field.
    /// </summary>
    public class FieldMetadata
    {
        /// <summary>
        /// Whether the field is required.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// The metadata describing an issue field.
        /// </summary>
        public Schema Schema { get; set; }

        /// <summary>
        /// The name of the field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The key of the field.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The URL that can be used to automatically complete the field.
        /// </summary>
        public string AutoCompleteUrl { get; set; }

        /// <summary>
        /// Whether the field has a default value.
        /// </summary>
        public bool HasDefaultValue { get; set; }

        /// <summary>
        /// The list of operations that can be performed on the field.
        /// </summary>
        public string[] Operations { get; set; }

        /// <summary>
        /// The list of values allowed in the field.
        /// </summary>
        public object[] AllowedValues { get; set; }

        /// <summary>
        /// The metadata describing an issue field.
        /// </summary>
        public DefaultValue DefaultValue { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class FieldNames
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a field that can be used in advanced searches.
    /// </summary>
    public class FieldReferenceData
    {
        /// <summary>
        /// The field identifier.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The display name contains the following: *  for system fields, the field name. For example, `Summary`. *  for collapsed custom fields, the field name followed by a hyphen and then the field name and field type. For example, `Component - Component[Dropdown]`. *  for other custom fields, the field name followed by a hyphen and then the custom field ID. For example, `Component - cf[10061]`.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Whether the field can be used in a query's `ORDER BY` clause.
        /// </summary>
        public string Orderable { get; set; }

        /// <summary>
        /// Whether the content of this field can be searched.
        /// </summary>
        public string Searchable { get; set; }

        /// <summary>
        /// Whether the field provide auto-complete suggestions.
        /// </summary>
        public string Auto { get; set; }

        /// <summary>
        /// If the item is a custom field, the ID of the custom field.
        /// </summary>
        public string Cfid { get; set; }

        /// <summary>
        /// The valid search operators for the field.
        /// </summary>
        public string[] Operators { get; set; }

        /// <summary>
        /// The data types of items in the field.
        /// </summary>
        public string[] Types { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Key fields from the linked issue.
    /// </summary>
    public class Fields
    {
        /// <summary>
        /// The summary description of the linked issue.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Key fields from the linked issue.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Key fields from the linked issue.
        /// </summary>
        public Priority Priority { get; set; }

        /// <summary>
        /// Key fields from the linked issue.
        /// </summary>
        public Assignee Assignee { get; set; }

        /// <summary>
        /// Key fields from the linked issue.
        /// </summary>
        public Timetracking Timetracking { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public IssueTypeDetails Issuetype { get; set; }

        /// <summary>
        /// Key fields from the linked issue.
        /// </summary>
        public IssueType IssueType { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an operation to perform on a field.
    /// </summary>
    public class FieldUpdateOperation
    {
        /// <summary>
        /// Details of an operation to perform on a field.
        /// </summary>
        public Add Add { get; set; }

        /// <summary>
        /// Details of an operation to perform on a field.
        /// </summary>
        public Set Set { get; set; }

        /// <summary>
        /// Details of an operation to perform on a field.
        /// </summary>
        public Remove Remove { get; set; }

        /// <summary>
        /// Details of an operation to perform on a field.
        /// </summary>
        public Edit Edit { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A clause that asserts the current value of a field. For example, `summary ~ test`.
    /// </summary>
    public class FieldValueClause
    {
        /// <summary>
        /// not-used
        /// </summary>
        public JqlQueryField Field { get; set; }

        /// <summary>
        /// The operator between the field and operand.
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public JqlQueryClauseOperand Operand { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A clause that asserts a previous value of a field. For example, `status WAS "Resolved" BY currentUser() BEFORE "2019/02/02"`. See [WAS](https://confluence.atlassian.com/x/dgiiLQ#Advancedsearching-operatorsreference-WASWAS) for more information about the WAS operator.
    /// </summary>
    public class FieldWasClause
    {
        /// <summary>
        /// not-used
        /// </summary>
        public JqlQueryField Field { get; set; }

        /// <summary>
        /// The operator between the field and operand.
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public JqlQueryClauseOperand Operand { get; set; }

        /// <summary>
        /// The list of time predicates.
        /// </summary>
        public JqlQueryClauseTimePredicate[] Predicates { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a filter.
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// The URL of the filter.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The unique identifier for the filter.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the filter. Must be unique.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A description of the filter.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Details about a filter.
        /// </summary>
        public Owner Owner { get; set; }

        /// <summary>
        /// The JQL query for the filter. For example, *project = SSP AND issuetype = Bug*.
        /// </summary>
        public string Jql { get; set; }

        /// <summary>
        /// A URL to view the filter results in Jira, using the ID of the filter. For example, *https://your-domain.atlassian.net/issues/?filter=10100*.
        /// </summary>
        public string ViewUrl { get; set; }

        /// <summary>
        /// A URL to view the filter results in Jira, using the [Search for issues using JQL](#api-rest-api-3-filter-search-get) operation with the filter's JQL string to return the filter results. For example, *https://your-domain.atlassian.net/rest/api/3/search?jql=project+%3D+SSP+AND+issuetype+%3D+Bug*.
        /// </summary>
        public string SearchUrl { get; set; }

        /// <summary>
        /// Whether the filter is selected as a favorite.
        /// </summary>
        public bool Favourite { get; set; }

        /// <summary>
        /// The count of how many users have selected this filter as a favorite, including the filter owner.
        /// </summary>
        public long FavouritedCount { get; set; }

        /// <summary>
        /// The groups and projects that the filter is shared with.
        /// </summary>
        public SharePermission[] SharePermissions { get; set; }

        /// <summary>
        /// The groups and projects that can edit the filter.
        /// </summary>
        public SharePermission[] EditPermissions { get; set; }

        /// <summary>
        /// Details about a filter.
        /// </summary>
        public SharedUsers SharedUsers { get; set; }

        /// <summary>
        /// Details about a filter.
        /// </summary>
        public Subscriptions Subscriptions { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a filter.
    /// </summary>
    public class FilterDetails
    {
        /// <summary>
        /// Expand options that include additional filter details in the response.
        /// </summary>
        public string Expand { get; set; }

        /// <summary>
        /// The URL of the filter.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The unique identifier for the filter.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the filter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the filter.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Details of a filter.
        /// </summary>
        public Owner Owner { get; set; }

        /// <summary>
        /// The JQL query for the filter. For example, *project = SSP AND issuetype = Bug*.
        /// </summary>
        public string Jql { get; set; }

        /// <summary>
        /// A URL to view the filter results in Jira, using the ID of the filter. For example, *https://your-domain.atlassian.net/issues/?filter=10100*.
        /// </summary>
        public string ViewUrl { get; set; }

        /// <summary>
        /// A URL to view the filter results in Jira, using the [Search for issues using JQL](#api-rest-api-3-filter-search-get) operation with the filter's JQL string to return the filter results. For example, *https://your-domain.atlassian.net/rest/api/3/search?jql=project+%3D+SSP+AND+issuetype+%3D+Bug*.
        /// </summary>
        public string SearchUrl { get; set; }

        /// <summary>
        /// Whether the filter is selected as a favorite by any users, not including the filter owner.
        /// </summary>
        public bool Favourite { get; set; }

        /// <summary>
        /// The count of how many users have selected this filter as a favorite, including the filter owner.
        /// </summary>
        public long FavouritedCount { get; set; }

        /// <summary>
        /// The groups and projects that the filter is shared with. This can be specified when updating a filter, but not when creating a filter.
        /// </summary>
        public SharePermission[] SharePermissions { get; set; }

        /// <summary>
        /// The groups and projects that can edit the filter. This can be specified when updating a filter, but not when creating a filter.
        /// </summary>
        public SharePermission[] EditPermissions { get; set; }

        /// <summary>
        /// The users that are subscribed to the filter.
        /// </summary>
        public FilterSubscription[] Subscriptions { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a user or group subscribing to a filter.
    /// </summary>
    public class FilterSubscription
    {
        /// <summary>
        /// The ID of the filter subscription.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Details of a user or group subscribing to a filter.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Details of a user or group subscribing to a filter.
        /// </summary>
        public Group Group { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A paginated list of subscriptions to a filter.
    /// </summary>
    public class FilterSubscriptionsList
    {
        /// <summary>
        /// The number of items on the page.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public FilterSubscription[] Items { get; set; }

        /// <summary>
        /// The maximum number of results that could be on the page.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned on the page.
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// The index of the last item returned on the page.
        /// </summary>
        public int EndIndex { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A group found in a search.
    /// </summary>
    public class FoundGroup
    {
        /// <summary>
        /// The name of the group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The group name with the matched query string highlighted with the HTML bold tag.
        /// </summary>
        public string Html { get; set; }

        public GroupLabel[] Labels { get; set; }

        /// <summary>
        /// The ID of the group, if available, which uniquely identifies the group across all Atlassian products. For example, *952d12c3-5b5b-4d04-bb32-44d383afc4b2*.
        /// </summary>
        public string GroupId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The list of groups found in a search, including header text (Showing X of Y matching groups) and total of matched groups.
    /// </summary>
    public class FoundGroups
    {
        /// <summary>
        /// Header text indicating the number of groups in the response and the total number of groups found in the search.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// The total number of groups found in the search.
        /// </summary>
        public int Total { get; set; }

        public FoundGroup[] Groups { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The list of users found in a search, including header text (Showing X of Y matching users) and total of matched users.
    /// </summary>
    public class FoundUsers
    {
        public UserPickerUser[] Users { get; set; }

        /// <summary>
        /// The total number of users found in the search.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Header text indicating the number of users in the response and the total number of users found in the search.
        /// </summary>
        public string Header { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// List of users and groups found in a search.
    /// </summary>
    public class FoundUsersAndGroups
    {
        /// <summary>
        /// not-used
        /// </summary>
        public FoundUsers Users { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public FoundGroups Groups { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// An operand that is a function. See [Advanced searching - functions reference](https://confluence.atlassian.com/x/dwiiLQ) for more information about JQL functions.
    /// </summary>
    public class FunctionOperand
    {
        /// <summary>
        /// The name of the function.
        /// </summary>
        public string Function { get; set; }

        /// <summary>
        /// The list of function arguments.
        /// </summary>
        public string[] Arguments { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of functions that can be used in advanced searches.
    /// </summary>
    public class FunctionReferenceData
    {
        /// <summary>
        /// The function identifier.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The display name of the function.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Whether the function can take a list of arguments.
        /// </summary>
        public string IsList { get; set; }

        /// <summary>
        /// The data types returned by the function.
        /// </summary>
        public string[] Types { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Generator : HistoryMetadataParticipant
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class GetAttachmentContentResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class GetAttachmentThumbnailResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class GetAvatarImageByIDResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class GetAvatarImageByOwnerResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class GetAvatarImageByTypeResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class GetSelectedTimeTrackingImplementationResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Global : GlobalScopeBean
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class GlobalScopeBean
    {
        /// <summary>
        /// Defines the behavior of the option in the global context.If notSelectable is set, the option cannot be set as the field's value. This is useful for archiving an option that has previously been selected but shouldn't be used anymore.If defaultValue is set, the option is selected by default.
        /// </summary>
        public string[] Attributes { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Group
    {
        /// <summary>
        /// The name of group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The URL for these group details.
        /// </summary>
        public string Self { get; set; }

        public Users Users { get; set; }

        /// <summary>
        /// Expand options that include additional group details in the response.
        /// </summary>
        public string Expand { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a group.
    /// </summary>
    public class GroupDetails
    {
        /// <summary>
        /// The name of the group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The ID of the group, if available, which uniquely identifies the group across all Atlassian products. For example, *952d12c3-5b5b-4d04-bb32-44d383afc4b2*.
        /// </summary>
        public string GroupId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A group label.
    /// </summary>
    public class GroupLabel
    {
        /// <summary>
        /// The group label name.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The title of the group label.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The type of the group label.
        /// </summary>
        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a group name.
    /// </summary>
    public class GroupName
    {
        /// <summary>
        /// The name of group.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The URL for these group details.
        /// </summary>
        public string Self { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Groups : SimpleListWrapperGroupName
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Jira instance health check results. Deprecated and no longer returned.
    /// </summary>
    public class HealthCheckResult
    {
        /// <summary>
        /// The name of the Jira health check item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the Jira health check item.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Whether the Jira health check item passed or failed.
        /// </summary>
        public bool Passed { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The project issue type hierarchy.
    /// </summary>
    public class Hierarchy
    {
        /// <summary>
        /// The ID of the base level. This property is deprecated, see [Change notice: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/).
        /// </summary>
        public long BaseLevelId { get; set; }

        /// <summary>
        /// Details about the hierarchy level.
        /// </summary>
        public HierarchyLevel[] Levels { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class HierarchyLevel
    {
        /// <summary>
        /// The ID of the hierarchy level. This property is deprecated, see [Change notice: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/).
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of this hierarchy level.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The ID of the level above this one in the hierarchy. This property is deprecated, see [Change notice: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/).
        /// </summary>
        public long AboveLevelId { get; set; }

        /// <summary>
        /// The ID of the level below this one in the hierarchy. This property is deprecated, see [Change notice: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/).
        /// </summary>
        public long BelowLevelId { get; set; }

        /// <summary>
        /// The ID of the project configuration. This property is deprecated, see [Change oticen: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/).
        /// </summary>
        public long ProjectConfigurationId { get; set; }

        /// <summary>
        /// The level of this item in the hierarchy.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// The issue types available in this hierarchy level.
        /// </summary>
        public long[] IssueTypeIds { get; set; }

        /// <summary>
        /// The external UUID of the hierarchy level. This property is deprecated, see [Change notice: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/).
        /// </summary>
        public string ExternalUuid { get; set; }

        public string GlobalHierarchyLevel { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of issue history metadata.
    /// </summary>
    public class HistoryMetadata
    {
        /// <summary>
        /// The type of the history record.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The description of the history record.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The description key of the history record.
        /// </summary>
        public string DescriptionKey { get; set; }

        /// <summary>
        /// The activity described in the history record.
        /// </summary>
        public string ActivityDescription { get; set; }

        /// <summary>
        /// The key of the activity described in the history record.
        /// </summary>
        public string ActivityDescriptionKey { get; set; }

        /// <summary>
        /// The description of the email address associated the history record.
        /// </summary>
        public string EmailDescription { get; set; }

        /// <summary>
        /// The description key of the email address associated the history record.
        /// </summary>
        public string EmailDescriptionKey { get; set; }

        /// <summary>
        /// Details of issue history metadata.
        /// </summary>
        public Actor Actor { get; set; }

        /// <summary>
        /// Details of issue history metadata.
        /// </summary>
        public Generator Generator { get; set; }

        /// <summary>
        /// Details of issue history metadata.
        /// </summary>
        public Cause Cause { get; set; }

        /// <summary>
        /// Details of issue history metadata.
        /// </summary>
        public ExtraData ExtraData { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of user or system associated with a issue history metadata item.
    /// </summary>
    public class HistoryMetadataParticipant
    {
        /// <summary>
        /// The ID of the user or system associated with a history record.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The display name of the user or system associated with a history record.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The key of the display name of the user or system associated with a history record.
        /// </summary>
        public string DisplayNameKey { get; set; }

        /// <summary>
        /// The type of the user or system associated with a history record.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The URL to an avatar for the user or system associated with a history record.
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// The URL of the user or system associated with a history record.
        /// </summary>
        public string Url { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Holder : PermissionHolder
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// An icon. If no icon is defined: *  for a status icon, no status icon displays in Jira. *  for the remote object icon, the default link icon displays in Jira.
    /// </summary>
    public class Icon
    {
        /// <summary>
        /// The URL of an icon that displays at 16x16 pixel in Jira.
        /// </summary>
        public string Url16x16 { get; set; }

        /// <summary>
        /// The title of the icon. This is used as follows: *  For a status icon it is used as a tooltip on the icon. If not set, the status icon doesn't display a tooltip in Jira. *  For the remote object icon it is used in conjunction with the application name to display a tooltip for the link's icon. The tooltip takes the format "\[application name\] icon title". Blank itemsare excluded from the tooltip title. If both items are blank, the icon tooltop displays as "Web Link".
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The URL of the tooltip, used only for a status icon. If not set, the status icon in Jira is not clickable.
        /// </summary>
        public string Link { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// An icon.
    /// </summary>
    public class IconBean
    {
        /// <summary>
        /// The URL of a 16x16 pixel icon.
        /// </summary>
        public string Url16x16 { get; set; }

        /// <summary>
        /// The title of the icon, for use as a tooltip on the icon.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The URL of the tooltip, used only for a status icon.
        /// </summary>
        public string Link { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class IdBean
    {
        /// <summary>
        /// The ID of the permission scheme to associate with the project. Use the [Get all permission schemes](#api-rest-api-3-permissionscheme-get) resource to get a list of permission scheme IDs.
        /// </summary>
        public long Id { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class IdOrKeyBean
    {
        /// <summary>
        /// The ID of the referenced item.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The key of the referenced item.
        /// </summary>
        public string Key { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class IncludedFields
    {
        public string[] Excluded { get; set; }

        public string[] Included { get; set; }

        public string[] ActuallyIncluded { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Insight : ProjectInsight
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class InwardIssue : LinkedIssue
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Issue : IdOrKeyBean
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about an issue.
    /// </summary>
    public class IssueBean
    {
        /// <summary>
        /// Expand options that include additional issue details in the response.
        /// </summary>
        public string Expand { get; set; }

        /// <summary>
        /// The ID of the issue.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The URL of the issue details.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The key of the issue.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Details about an issue.
        /// </summary>
        public RenderedFields RenderedFields { get; set; }

        /// <summary>
        /// Details about an issue.
        /// </summary>
        public Properties Properties { get; set; }

        /// <summary>
        /// Details about an issue.
        /// </summary>
        public Names Names { get; set; }

        /// <summary>
        /// Details about an issue.
        /// </summary>
        public Schema Schema { get; set; }

        /// <summary>
        /// The transitions that can be performed on the issue.
        /// </summary>
        public IssueTransition[] Transitions { get; set; }

        /// <summary>
        /// Details about an issue.
        /// </summary>
        public Operations Operations { get; set; }

        /// <summary>
        /// Details about an issue.
        /// </summary>
        public Editmeta Editmeta { get; set; }

        /// <summary>
        /// Details about an issue.
        /// </summary>
        public Changelog Changelog { get; set; }

        /// <summary>
        /// Details about an issue.
        /// </summary>
        public VersionedRepresentations VersionedRepresentations { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public IncludedFields FieldsToInclude { get; set; }

        /// <summary>
        /// Details about an issue.
        /// </summary>
        public Fields Fields { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A list of changelog IDs.
    /// </summary>
    public class IssueChangelogIds
    {
        /// <summary>
        /// The list of changelog IDs.
        /// </summary>
        public long[] ChangelogIds { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class IssueCommentListRequestBean
    {
        /// <summary>
        /// The list of comment IDs. A maximum of 1000 IDs can be specified.
        /// </summary>
        public long[] Ids { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// An [issue](https://developer.atlassian.com/cloud/jira/platform/jira-expressions-type-reference#issue) specified by ID or key. All the fields of the issue object are available in the Jira expression.
    /// </summary>
    public class IssueContextVariable
    {
        /// <summary>
        /// Type of custom context variable.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The issue ID.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The issue key.
        /// </summary>
        public string Key { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The wrapper for the issue creation metadata for a list of projects.
    /// </summary>
    public class IssueCreateMetadata
    {
        /// <summary>
        /// Expand options that include additional project details in the response.
        /// </summary>
        public string Expand { get; set; }

        /// <summary>
        /// List of projects and their issue creation metadata.
        /// </summary>
        public ProjectIssueCreateMetadata[] Projects { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Lists of issues and entity properties. See [Entity properties](https://developer.atlassian.com/cloud/jira/platform/jira-entity-properties/) for more information.
    /// </summary>
    public class IssueEntityProperties
    {
        /// <summary>
        /// A list of entity property IDs.
        /// </summary>
        public long[] EntitiesIds { get; set; }

        /// <summary>
        /// Lists of issues and entity properties. See [Entity properties](https://developer.atlassian.com/cloud/jira/platform/jira-entity-properties/) for more information.
        /// </summary>
        public Properties Properties { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// An issue ID with entity property values. See [Entity properties](https://developer.atlassian.com/cloud/jira/platform/jira-entity-properties/) for more information.
    /// </summary>
    public class IssueEntityPropertiesForMultiUpdate
    {
        /// <summary>
        /// The ID of the issue.
        /// </summary>
        public long IssueID { get; set; }

        /// <summary>
        /// An issue ID with entity property values. See [Entity properties](https://developer.atlassian.com/cloud/jira/platform/jira-entity-properties/) for more information.
        /// </summary>
        public Properties Properties { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about an issue event.
    /// </summary>
    public class IssueEvent
    {
        /// <summary>
        /// The ID of the event.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of the event.
        /// </summary>
        public string Name { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the options for a select list issue field.
    /// </summary>
    public class IssueFieldOption
    {
        /// <summary>
        /// The unique identifier for the option. This is only unique within the select field's set of options.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The option's name, which is displayed in Jira.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Details of the options for a select list issue field.
        /// </summary>
        public Properties Properties { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public IssueFieldOptionConfiguration Config { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the projects the option is available in.
    /// </summary>
    public class IssueFieldOptionConfiguration
    {
        /// <summary>
        /// Details of the projects the option is available in.
        /// </summary>
        public Scope Scope { get; set; }

        /// <summary>
        /// DEPRECATED
        /// </summary>
        public string[] Attributes { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class IssueFieldOptionCreateBean
    {
        /// <summary>
        /// The option's name, which is displayed in Jira.
        /// </summary>
        public string Value { get; set; }

        public Properties Properties { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public IssueFieldOptionConfiguration Config { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class IssueFieldOptionScopeBean
    {
        /// <summary>
        /// DEPRECATED
        /// </summary>
        public long[] Projects { get; set; }

        /// <summary>
        /// Defines the projects in which the option is available and the behavior of the option within each project. Specify one object per project. The behavior of the option in a project context overrides the behavior in the global context.
        /// </summary>
        public ProjectScopeBean[] Projects2 { get; set; }

        public Global Global { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Bulk operation filter details.
    /// </summary>
    public class IssueFilterForBulkPropertyDelete
    {
        /// <summary>
        /// List of issues to perform the bulk delete operation on.
        /// </summary>
        public long[] EntityIds { get; set; }

        /// <summary>
        /// Bulk operation filter details.
        /// </summary>
        public CurrentValue CurrentValue { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Bulk operation filter details.
    /// </summary>
    public class IssueFilterForBulkPropertySet
    {
        /// <summary>
        /// List of issues to perform the bulk operation on.
        /// </summary>
        public long[] EntityIds { get; set; }

        /// <summary>
        /// Bulk operation filter details.
        /// </summary>
        public CurrentValue CurrentValue { get; set; }

        /// <summary>
        /// Whether the bulk operation occurs only when the property is present on or absent from an issue.
        /// </summary>
        public bool HasProperty { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a link between issues.
    /// </summary>
    public class IssueLink
    {
        /// <summary>
        /// The ID of the issue link.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The URL of the issue link.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// Details of a link between issues.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// Details of a link between issues.
        /// </summary>
        public InwardIssue InwardIssue { get; set; }

        /// <summary>
        /// Details of a link between issues.
        /// </summary>
        public OutwardIssue OutwardIssue { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// This object is used as follows: *  In the [ issueLink](#api-rest-api-3-issueLink-post) resource it defines and reports on the type of link between the issues. Find a list of issue link types with [Get issue link types](#api-rest-api-3-issueLinkType-get). *  In the [ issueLinkType](#api-rest-api-3-issueLinkType-post) resource it defines and reports on issue link types.
    /// </summary>
    public class IssueLinkType
    {
        /// <summary>
        /// The ID of the issue link type and is used as follows: *  In the [ issueLink](#api-rest-api-3-issueLink-post) resource it is the type of issue link. Required on create when `name` isn't provided. Otherwise, read only. *  In the [ issueLinkType](#api-rest-api-3-issueLinkType-post) resource it is read only.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the issue link type and is used as follows: *  In the [ issueLink](#api-rest-api-3-issueLink-post) resource it is the type of issue link. Required on create when `id` isn't provided. Otherwise, read only. *  In the [ issueLinkType](#api-rest-api-3-issueLinkType-post) resource it is required on create and optional on update. Otherwise, read only.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the issue link type inward link and is used as follows: *  In the [ issueLink](#api-rest-api-3-issueLink-post) resource it is read only. *  In the [ issueLinkType](#api-rest-api-3-issueLinkType-post) resource it is required on create and optional on update. Otherwise, read only.
        /// </summary>
        public string Inward { get; set; }

        /// <summary>
        /// The description of the issue link type outward link and is used as follows: *  In the [ issueLink](#api-rest-api-3-issueLink-post) resource it is read only. *  In the [ issueLinkType](#api-rest-api-3-issueLinkType-post) resource it is required on create and optional on update. Otherwise, read only.
        /// </summary>
        public string Outward { get; set; }

        /// <summary>
        /// The URL of the issue link type. Read only.
        /// </summary>
        public string Self { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A list of issue link type beans.
    /// </summary>
    public class IssueLinkTypes
    {
        /// <summary>
        /// The issue link type bean.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("IssueLinkTypes")]
        public IssueLinkType[] IssueLinkTypes_ { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A list of issue IDs.
    /// </summary>
    public class IssueList
    {
        /// <summary>
        /// The list of issue IDs.
        /// </summary>
        public string[] IssueIds { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A list of matched issues or errors for each JQL query, in the order the JQL queries were passed.
    /// </summary>
    public class IssueMatches
    {
        public IssueMatchesForJQL[] Matches { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A list of the issues matched to a JQL query or details of errors encountered during matching.
    /// </summary>
    public class IssueMatchesForJQL
    {
        /// <summary>
        /// A list of issue IDs.
        /// </summary>
        public long[] MatchedIssues { get; set; }

        /// <summary>
        /// A list of errors.
        /// </summary>
        public string[] Errors { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A list of issues suggested for use in auto-completion.
    /// </summary>
    public class IssuePickerSuggestions
    {
        /// <summary>
        /// A list of issues for an issue type suggested for use in auto-completion.
        /// </summary>
        public IssuePickerSuggestionsIssueType[] Sections { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A type of issue suggested for use in auto-completion.
    /// </summary>
    public class IssuePickerSuggestionsIssueType
    {
        /// <summary>
        /// The label of the type of issues suggested for use in auto-completion.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// If issue suggestions are found, returns a message indicating the number of issues suggestions found and returned.
        /// </summary>
        public string Sub { get; set; }

        /// <summary>
        /// The ID of the type of issues suggested for use in auto-completion.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// If no issue suggestions are found, returns a message indicating no suggestions were found,
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// A list of issues suggested for use in auto-completion.
        /// </summary>
        public SuggestedIssue[] Issues { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Issues : JexpIssues
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// List of issues and JQL queries.
    /// </summary>
    public class IssuesAndJQLQueries
    {
        /// <summary>
        /// A list of JQL queries.
        /// </summary>
        public string[] Jqls { get; set; }

        /// <summary>
        /// A list of issue IDs.
        /// </summary>
        public long[] IssueIds { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Issue security level member.
    /// </summary>
    public class IssueSecurityLevelMember
    {
        /// <summary>
        /// The ID of the issue security level member.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The ID of the issue security level.
        /// </summary>
        public long IssueSecurityLevelId { get; set; }

        /// <summary>
        /// Issue security level member.
        /// </summary>
        public Holder Holder { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class IssuesIsWatching
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The description of the page of issues loaded by the provided JQL query.
    /// </summary>
    public class IssuesJqlMetaDataBean
    {
        /// <summary>
        /// The index of the first issue.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The maximum number of issues that could be loaded in this evaluation.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The number of issues that were loaded in this evaluation.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The total number of issues the JQL returned.
        /// </summary>
        public long TotalCount { get; set; }

        /// <summary>
        /// Any warnings related to the JQL query. Present only if the validation mode was set to `warn`.
        /// </summary>
        public string[] ValidationWarnings { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Meta data describing the `issues` context variable.
    /// </summary>
    public class IssuesMetaBean
    {
        /// <summary>
        /// not-used
        /// </summary>
        public IssuesJqlMetaDataBean Jql { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class IssuesStatusForFixVersion : VersionIssuesStatus
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class IssuesUpdateBean
    {
        public IssueUpdateDetails[] IssueUpdates { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an issue transition.
    /// </summary>
    public class IssueTransition
    {
        /// <summary>
        /// The ID of the issue transition. Required when specifying a transition to undertake.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the issue transition.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Details of an issue transition.
        /// </summary>
        public To To { get; set; }

        /// <summary>
        /// Whether there is a screen associated with the issue transition.
        /// </summary>
        public bool HasScreen { get; set; }

        /// <summary>
        /// Whether the issue transition is global, that is, the transition is applied to issues regardless of their status.
        /// </summary>
        public bool IsGlobal { get; set; }

        /// <summary>
        /// Whether this is the initial issue transition for the workflow.
        /// </summary>
        public bool IsInitial { get; set; }

        /// <summary>
        /// Whether the transition is available to be performed.
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Whether the issue has to meet criteria before the issue transition is applied.
        /// </summary>
        public bool IsConditional { get; set; }

        /// <summary>
        /// Details of an issue transition.
        /// </summary>
        public Fields Fields { get; set; }

        /// <summary>
        /// Expand options that include additional transition details in the response.
        /// </summary>
        public string Expand { get; set; }

        public bool Looped { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class IssueType : IssueTypeDetails
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class IssueTypeCreateBean
    {
        /// <summary>
        /// The unique name for the issue type. The maximum length is 60 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the issue type.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Deprecated. Use `hierarchyLevel` instead.Whether the issue type is `subtype` or `standard`. Defaults to `standard`.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The hierarchy level of the issue type. Use: *  `-1` for Subtask. *  `0` for Base.Defaults to `0`.
        /// </summary>
        public int HierarchyLevel { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about an issue type.
    /// </summary>
    public class IssueTypeDetails
    {
        /// <summary>
        /// The URL of these issue type details.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID of the issue type.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The description of the issue type.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The URL of the issue type's avatar.
        /// </summary>
        public string IconUrl { get; set; }

        /// <summary>
        /// The name of the issue type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether this issue type is used to create subtasks.
        /// </summary>
        public bool Subtask { get; set; }

        /// <summary>
        /// The ID of the issue type's avatar.
        /// </summary>
        public long AvatarId { get; set; }

        /// <summary>
        /// Unique ID for next-gen projects.
        /// </summary>
        public string EntityId { get; set; }

        /// <summary>
        /// Hierarchy level of the issue type.
        /// </summary>
        public int HierarchyLevel { get; set; }

        /// <summary>
        /// Details about an issue type.
        /// </summary>
        public Scope Scope { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class IssueTypeHierarchy : Hierarchy
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The list of issue type IDs.
    /// </summary>
    public class IssueTypeIds
    {
        /// <summary>
        /// The list of issue type IDs.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("IssueTypeIds")]
        public string[] IssueTypeIds_ { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The list of issue type IDs to be removed from the field configuration scheme.
    /// </summary>
    public class IssueTypeIdsToRemove
    {
        /// <summary>
        /// The list of issue type IDs. Must contain unique values not longer than 255 characters and not be empty. Maximum of 100 IDs.
        /// </summary>
        public string[] IssueTypeIds { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an issue type.
    /// </summary>
    public class IssueTypeInfo
    {
        /// <summary>
        /// The ID of the issue type.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of the issue type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The avatar of the issue type.
        /// </summary>
        public long AvatarId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the issue creation metadata for an issue type.
    /// </summary>
    public class IssueTypeIssueCreateMetadata
    {
        /// <summary>
        /// The URL of these issue type details.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID of the issue type.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The description of the issue type.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The URL of the issue type's avatar.
        /// </summary>
        public string IconUrl { get; set; }

        /// <summary>
        /// The name of the issue type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether this issue type is used to create subtasks.
        /// </summary>
        public bool Subtask { get; set; }

        /// <summary>
        /// The ID of the issue type's avatar.
        /// </summary>
        public long AvatarId { get; set; }

        /// <summary>
        /// Unique ID for next-gen projects.
        /// </summary>
        public string EntityId { get; set; }

        /// <summary>
        /// Hierarchy level of the issue type.
        /// </summary>
        public int HierarchyLevel { get; set; }

        /// <summary>
        /// Details of the issue creation metadata for an issue type.
        /// </summary>
        public Scope Scope { get; set; }

        /// <summary>
        /// Expand options that include additional issue type metadata details in the response.
        /// </summary>
        public string Expand { get; set; }

        /// <summary>
        /// Details of the issue creation metadata for an issue type.
        /// </summary>
        public Fields Fields { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class IssueTypeMappings
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class IssueTypes
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an issue type scheme.
    /// </summary>
    public class IssueTypeScheme
    {
        /// <summary>
        /// The ID of the issue type scheme.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the issue type scheme.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the issue type scheme.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The ID of the default issue type of the issue type scheme.
        /// </summary>
        public string DefaultIssueTypeId { get; set; }

        /// <summary>
        /// Whether the issue type scheme is the default.
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an issue type scheme and its associated issue types.
    /// </summary>
    public class IssueTypeSchemeDetails
    {
        /// <summary>
        /// The name of the issue type scheme. The name must be unique. The maximum length is 255 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the issue type scheme. The maximum length is 4000 characters.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The ID of the default issue type of the issue type scheme. This ID must be included in `issueTypeIds`.
        /// </summary>
        public string DefaultIssueTypeId { get; set; }

        /// <summary>
        /// The list of issue types IDs of the issue type scheme. At least one standard issue type ID is required.
        /// </summary>
        public string[] IssueTypeIds { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The ID of an issue type scheme.
    /// </summary>
    public class IssueTypeSchemeID
    {
        /// <summary>
        /// The ID of the issue type scheme.
        /// </summary>
        public string IssueTypeSchemeId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Issue type scheme item.
    /// </summary>
    public class IssueTypeSchemeMapping
    {
        /// <summary>
        /// The ID of the issue type scheme.
        /// </summary>
        public string IssueTypeSchemeId { get; set; }

        /// <summary>
        /// The ID of the issue type.
        /// </summary>
        public string IssueTypeId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the association between an issue type scheme and project.
    /// </summary>
    public class IssueTypeSchemeProjectAssociation
    {
        /// <summary>
        /// The ID of the issue type scheme.
        /// </summary>
        public string IssueTypeSchemeId { get; set; }

        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string ProjectId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Issue type scheme with a list of the projects that use it.
    /// </summary>
    public class IssueTypeSchemeProjects
    {
        /// <summary>
        /// Issue type scheme with a list of the projects that use it.
        /// </summary>
        public IssueTypeScheme IssueTypeScheme { get; set; }

        /// <summary>
        /// The IDs of the projects using the issue type scheme.
        /// </summary>
        public string[] ProjectIds { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the name, description, and default issue type for an issue type scheme.
    /// </summary>
    public class IssueTypeSchemeUpdateDetails
    {
        /// <summary>
        /// The name of the issue type scheme. The name must be unique. The maximum length is 255 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the issue type scheme. The maximum length is 4000 characters.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The ID of the default issue type of the issue type scheme.
        /// </summary>
        public string DefaultIssueTypeId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an issue type screen scheme.
    /// </summary>
    public class IssueTypeScreenScheme
    {
        /// <summary>
        /// The ID of the issue type screen scheme.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the issue type screen scheme.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the issue type screen scheme.
        /// </summary>
        public string Description { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The details of an issue type screen scheme.
    /// </summary>
    public class IssueTypeScreenSchemeDetails
    {
        /// <summary>
        /// The name of the issue type screen scheme. The name must be unique. The maximum length is 255 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the issue type screen scheme. The maximum length is 255 characters.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The IDs of the screen schemes for the issue type IDs and *default*. A *default* entry is required to create an issue type screen scheme, it defines the mapping for all issue types without a screen scheme.
        /// </summary>
        public IssueTypeScreenSchemeMapping[] IssueTypeMappings { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The ID of an issue type screen scheme.
    /// </summary>
    public class IssueTypeScreenSchemeId
    {
        /// <summary>
        /// The ID of the issue type screen scheme.
        /// </summary>
        public string Id { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The screen scheme for an issue type.
    /// </summary>
    public class IssueTypeScreenSchemeItem
    {
        /// <summary>
        /// The ID of the issue type screen scheme.
        /// </summary>
        public string IssueTypeScreenSchemeId { get; set; }

        /// <summary>
        /// The ID of the issue type or *default*. Only issue types used in classic projects are accepted. When creating an issue screen scheme, an entry for *default* must be provided and defines the mapping for all issue types without a screen scheme. Otherwise, a *default* entry can't be provided.
        /// </summary>
        public string IssueTypeId { get; set; }

        /// <summary>
        /// The ID of the screen scheme.
        /// </summary>
        public string ScreenSchemeId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The IDs of the screen schemes for the issue type IDs.
    /// </summary>
    public class IssueTypeScreenSchemeMapping
    {
        /// <summary>
        /// The ID of the issue type or *default*. Only issue types used in classic projects are accepted. An entry for *default* must be provided and defines the mapping for all issue types without a screen scheme.
        /// </summary>
        public string IssueTypeId { get; set; }

        /// <summary>
        /// The ID of the screen scheme. Only screen schemes used in classic projects are accepted.
        /// </summary>
        public string ScreenSchemeId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A list of issue type screen scheme mappings.
    /// </summary>
    public class IssueTypeScreenSchemeMappingDetails
    {
        /// <summary>
        /// The list of issue type to screen scheme mappings. A *default* entry cannot be specified because a default entry is added when an issue type screen scheme is created.
        /// </summary>
        public IssueTypeScreenSchemeMapping[] IssueTypeMappings { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Associated issue type screen scheme and project.
    /// </summary>
    public class IssueTypeScreenSchemeProjectAssociation
    {
        /// <summary>
        /// The ID of the issue type screen scheme.
        /// </summary>
        public string IssueTypeScreenSchemeId { get; set; }

        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string ProjectId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class IssueTypeScreenSchemes : PageBeanIssueTypeScreenScheme
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Issue type screen scheme with a list of the projects that use it.
    /// </summary>
    public class IssueTypeScreenSchemesProjects
    {
        /// <summary>
        /// Issue type screen scheme with a list of the projects that use it.
        /// </summary>
        public IssueTypeScreenScheme IssueTypeScreenScheme { get; set; }

        /// <summary>
        /// The IDs of the projects using the issue type screen scheme.
        /// </summary>
        public string[] ProjectIds { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an issue type screen scheme.
    /// </summary>
    public class IssueTypeScreenSchemeUpdateDetails
    {
        /// <summary>
        /// The name of the issue type screen scheme. The name must be unique. The maximum length is 255 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the issue type screen scheme. The maximum length is 255 characters.
        /// </summary>
        public string Description { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about the mapping between issue types and a workflow.
    /// </summary>
    public class IssueTypesWorkflowMapping
    {
        /// <summary>
        /// The name of the workflow. Optional if updating the workflow-issue types mapping.
        /// </summary>
        public string Workflow { get; set; }

        /// <summary>
        /// The list of issue type IDs.
        /// </summary>
        public string[] IssueTypes { get; set; }

        /// <summary>
        /// Whether the workflow is the default workflow for the workflow scheme.
        /// </summary>
        public bool DefaultMapping { get; set; }

        /// <summary>
        /// Whether a draft workflow scheme is created or updated when updating an active workflow scheme. The draft is updated with the new workflow-issue types mapping. Defaults to `false`.
        /// </summary>
        public bool UpdateDraftIfNeeded { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Mapping of an issue type to a context.
    /// </summary>
    public class IssueTypeToContextMapping
    {
        /// <summary>
        /// The ID of the context.
        /// </summary>
        public string ContextId { get; set; }

        /// <summary>
        /// The ID of the issue type.
        /// </summary>
        public string IssueTypeId { get; set; }

        /// <summary>
        /// Whether the context is mapped to any issue type.
        /// </summary>
        public bool IsAnyIssueType { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class IssueTypeUpdateBean
    {
        /// <summary>
        /// The unique name for the issue type. The maximum length is 60 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the issue type.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The ID of an issue type avatar.
        /// </summary>
        public long AvatarId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Status details for an issue type.
    /// </summary>
    public class IssueTypeWithStatus
    {
        /// <summary>
        /// The URL of the issue type's status details.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID of the issue type.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the issue type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether this issue type represents subtasks.
        /// </summary>
        public bool Subtask { get; set; }

        /// <summary>
        /// List of status details for the issue type.
        /// </summary>
        public StatusDetails[] Statuses { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about the mapping between an issue type and a workflow.
    /// </summary>
    public class IssueTypeWorkflowMapping
    {
        /// <summary>
        /// The ID of the issue type. Not required if updating the issue type-workflow mapping.
        /// </summary>
        public string IssueType { get; set; }

        /// <summary>
        /// The name of the workflow.
        /// </summary>
        public string Workflow { get; set; }

        /// <summary>
        /// Set to true to create or update the draft of a workflow scheme and update the mapping in the draft, when the workflow scheme cannot be edited. Defaults to `false`. Only applicable when updating the workflow-issue types mapping.
        /// </summary>
        public bool UpdateDraftIfNeeded { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an issue update request.
    /// </summary>
    public class IssueUpdateDetails
    {
        /// <summary>
        /// Details of an issue update request.
        /// </summary>
        public Transition Transition { get; set; }

        /// <summary>
        /// Details of an issue update request.
        /// </summary>
        public Fields Fields { get; set; }

        /// <summary>
        /// Details of an issue update request.
        /// </summary>
        public Update Update { get; set; }

        /// <summary>
        /// Details of an issue update request.
        /// </summary>
        public HistoryMetadata HistoryMetadata { get; set; }

        /// <summary>
        /// Details of issue properties to be add or update.
        /// </summary>
        public EntityProperty[] Properties { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A list of editable field details.
    /// </summary>
    public class IssueUpdateMetadata
    {
        /// <summary>
        /// A list of editable field details.
        /// </summary>
        public Fields Fields { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The JQL specifying the issues available in the evaluated Jira expression under the `issues` context variable.
    /// </summary>
    public class JexpIssues
    {
        /// <summary>
        /// The JQL specifying the issues available in the evaluated Jira expression under the `issues` context variable.
        /// </summary>
        public Jql Jql { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The JQL specifying the issues available in the evaluated Jira expression under the `issues` context variable. Not all issues returned by the JQL query are loaded, only those described by the `startAt` and `maxResults` properties. To determine whether it is necessary to iterate to ensure all the issues returned by the JQL query are evaluated, inspect `meta.issues.jql.count` in the response.
    /// </summary>
    public class JexpJqlIssues
    {
        /// <summary>
        /// The JQL query.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// The index of the first issue to return from the JQL query.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The maximum number of issues to return from the JQL query. Inspect `meta.issues.jql.maxResults` in the response to ensure the maximum value has not been exceeded.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// Determines how to validate the JQL query and treat the validation results.
        /// </summary>
        public string Validation { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about the analysed Jira expression.
    /// </summary>
    public class JiraExpressionAnalysis
    {
        /// <summary>
        /// The analysed expression.
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// A list of validation errors. Not included if the expression is valid.
        /// </summary>
        public JiraExpressionValidationError[] Errors { get; set; }

        /// <summary>
        /// Whether the expression is valid and the interpreter will evaluate it. Note that the expression may fail at runtime (for example, if it executes too many expensive operations).
        /// </summary>
        public bool Valid { get; set; }

        /// <summary>
        /// EXPERIMENTAL. The inferred type of the expression.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public JiraExpressionComplexity Complexity { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about the complexity of the analysed Jira expression.
    /// </summary>
    public class JiraExpressionComplexity
    {
        /// <summary>
        /// Information that can be used to determine how many [expensive operations](https://developer.atlassian.com/cloud/jira/platform/jira-expressions/#expensive-operations) the evaluation of the expression will perform. This information may be a formula or number. For example: *  `issues.map(i => i.comments)` performs as many expensive operations as there are issues on the issues list. So this parameter returns `N`, where `N` is the size of issue list. *  `new Issue(10010).comments` gets comments for one issue, so its complexity is `2` (`1` to retrieve issue 10010 from the database plus `1` to get its comments).
        /// </summary>
        public string ExpensiveOperations { get; set; }

        /// <summary>
        /// Details about the complexity of the analysed Jira expression.
        /// </summary>
        public Variables Variables { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class JiraExpressionEvalContextBean
    {
        public Issue Issue { get; set; }

        public Issues Issues { get; set; }

        public Project Project { get; set; }

        /// <summary>
        /// The ID of the sprint that is available under the `sprint` variable when evaluating the expression.
        /// </summary>
        public long Sprint { get; set; }

        /// <summary>
        /// The ID of the board that is available under the `board` variable when evaluating the expression.
        /// </summary>
        public long Board { get; set; }

        /// <summary>
        /// The ID of the service desk that is available under the `serviceDesk` variable when evaluating the expression.
        /// </summary>
        public long ServiceDesk { get; set; }

        /// <summary>
        /// The ID of the customer request that is available under the `customerRequest` variable when evaluating the expression. This is the same as the ID of the underlying Jira issue, but the customer request context variable will have a different type.
        /// </summary>
        public long CustomerRequest { get; set; }

        /// <summary>
        /// Custom context variables and their types. These variable types are available for use in a custom context: *  `user`: A [user](https://developer.atlassian.com/cloud/jira/platform/jira-expressions-type-reference#user) specified as an Atlassian account ID. *  `issue`: An [issue](https://developer.atlassian.com/cloud/jira/platform/jira-expressions-type-reference#issue) specified by ID or key. All the fields of the issue object are available in the Jira expression. *  `json`: A JSON object containing custom content. *  `list`: A JSON list of `user`, `issue`, or `json` variable types.
        /// </summary>
        public CustomContextVariable[] Custom { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class JiraExpressionEvalRequestBean
    {
        /// <summary>
        /// The Jira expression to evaluate.
        /// </summary>
        public string Expression { get; set; }

        public Context Context { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class JiraExpressionEvaluationMetaDataBean
    {
        public Complexity Complexity { get; set; }

        public Issues Issues { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of Jira expressions for analysis.
    /// </summary>
    public class JiraExpressionForAnalysis
    {
        /// <summary>
        /// The list of Jira expressions to analyse.
        /// </summary>
        public string[] Expressions { get; set; }

        /// <summary>
        /// Details of Jira expressions for analysis.
        /// </summary>
        public ContextVariables ContextVariables { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The result of evaluating a Jira expression.
    /// </summary>
    public class JiraExpressionResult
    {
        /// <summary>
        /// The result of evaluating a Jira expression.
        /// </summary>
        public Value Value { get; set; }

        /// <summary>
        /// The result of evaluating a Jira expression.
        /// </summary>
        public Meta Meta { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about the analysed Jira expression.
    /// </summary>
    public class JiraExpressionsAnalysis
    {
        /// <summary>
        /// The results of Jira expressions analysis.
        /// </summary>
        public JiraExpressionAnalysis[] Results { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class JiraExpressionsComplexityBean
    {
        public Steps Steps { get; set; }

        public ExpensiveOperations ExpensiveOperations { get; set; }

        public Beans Beans { get; set; }

        public PrimitiveValues PrimitiveValues { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class JiraExpressionsComplexityValueBean
    {
        /// <summary>
        /// The complexity value of the current expression.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// The maximum allowed complexity. The evaluation will fail if this value is exceeded.
        /// </summary>
        public int Limit { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about syntax and type errors. The error details apply to the entire expression, unless the object includes: *  `line` and `column` *  `expression`
    /// </summary>
    public class JiraExpressionValidationError
    {
        /// <summary>
        /// The text line in which the error occurred.
        /// </summary>
        public int Line { get; set; }

        /// <summary>
        /// The text column in which the error occurred.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// The part of the expression in which the error occurred.
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// Details about the error.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The error type.
        /// </summary>
        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Jql : JexpJqlIssues
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The JQL queries to be converted.
    /// </summary>
    public class JQLPersonalDataMigrationRequest
    {
        /// <summary>
        /// A list of queries with user identifiers. Maximum of 100 queries.
        /// </summary>
        public string[] QueryStrings { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A list of JQL queries to parse.
    /// </summary>
    public class JqlQueriesToParse
    {
        /// <summary>
        /// A list of queries to parse.
        /// </summary>
        public string[] Queries { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A parsed JQL query.
    /// </summary>
    public class JqlQuery
    {
        /// <summary>
        /// not-used
        /// </summary>
        public JqlQueryClause Where { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public JqlQueryOrderByClause OrderBy { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A JQL query clause.
    /// </summary>
    public class JqlQueryClause : CompoundClause, FieldValueClause, FieldWasClause, FieldChangedClause
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an operand in a JQL clause.
    /// </summary>
    public class JqlQueryClauseOperand : ListOperand, ValueOperand, FunctionOperand, KeywordOperand
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A time predicate for a temporal JQL clause.
    /// </summary>
    public class JqlQueryClauseTimePredicate
    {
        /// <summary>
        /// The operator between the field and the operand.
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public JqlQueryClauseOperand Operand { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A field used in a JQL query. See [Advanced searching - fields reference](https://confluence.atlassian.com/x/dAiiLQ) for more information about fields in JQL queries.
    /// </summary>
    public class JqlQueryField
    {
        /// <summary>
        /// The name of the field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// When the field refers to a value in an entity property, details of the entity property value.
        /// </summary>
        public JqlQueryFieldEntityProperty[] Property { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an entity property.
    /// </summary>
    public class JqlQueryFieldEntityProperty
    {
        /// <summary>
        /// The object on which the property is set.
        /// </summary>
        public string Entity { get; set; }

        /// <summary>
        /// The key of the property.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The path in the property value to query.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The type of the property value extraction. Not available if the extraction for the property is not registered on the instance with the [Entity property](https://developer.atlassian.com/cloud/jira/platform/modules/entity-property/) module.
        /// </summary>
        public string Type { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the order-by JQL clause.
    /// </summary>
    public class JqlQueryOrderByClause
    {
        /// <summary>
        /// The list of order-by clause fields and their ordering directives.
        /// </summary>
        public JqlQueryOrderByClauseElement[] Fields { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// An element of the order-by JQL clause.
    /// </summary>
    public class JqlQueryOrderByClauseElement
    {
        /// <summary>
        /// not-used
        /// </summary>
        public JqlQueryField Field { get; set; }

        /// <summary>
        /// The direction in which to order the results.
        /// </summary>
        public string Direction { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// An operand that can be part of a list operand.
    /// </summary>
    public class JqlQueryUnitaryOperand : ValueOperand, FunctionOperand, KeywordOperand
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// JQL queries that contained users that could not be found
    /// </summary>
    public class JQLQueryWithUnknownUsers
    {
        /// <summary>
        /// The original query, for reference
        /// </summary>
        public string OriginalQuery { get; set; }

        /// <summary>
        /// The converted query, with accountIDs instead of user identifiers, or 'unknown' for users that could not be found
        /// </summary>
        public string ConvertedQuery { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Lists of JQL reference data.
    /// </summary>
    public class JQLReferenceData
    {
        /// <summary>
        /// List of fields usable in JQL queries.
        /// </summary>
        public FieldReferenceData[] VisibleFieldNames { get; set; }

        /// <summary>
        /// List of functions usable in JQL queries.
        /// </summary>
        public FunctionReferenceData[] VisibleFunctionNames { get; set; }

        /// <summary>
        /// List of JQL query reserved words.
        /// </summary>
        public string[] JqlReservedWords { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A JSON object with custom content.
    /// </summary>
    public class JsonContextVariable
    {
        /// <summary>
        /// Type of custom context variable.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A JSON object with custom content.
        /// </summary>
        public Value Value { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class JsonNode
    {
        public bool FloatingPointNumber { get; set; }

        public Elements Elements { get; set; }

        public bool Pojo { get; set; }

        public bool Number { get; set; }

        public bool IntegralNumber { get; set; }

        public bool Int { get; set; }

        public bool Long { get; set; }

        public bool Double { get; set; }

        public bool BigDecimal { get; set; }

        public bool BigInteger { get; set; }

        public bool Textual { get; set; }

        public bool Boolean { get; set; }

        public bool Binary { get; set; }

        public bool ContainerNode { get; set; }

        public bool MissingNode { get; set; }

        public bool Object { get; set; }

        public bool ValueNode { get; set; }

        public double NumberValue { get; set; }

        public string NumberType { get; set; }

        public int IntValue { get; set; }

        public long LongValue { get; set; }

        public int BigIntegerValue { get; set; }

        public double DoubleValue { get; set; }

        public double DecimalValue { get; set; }

        public bool BooleanValue { get; set; }

        public byte[][] BinaryValue { get; set; }

        public int ValueAsInt { get; set; }

        public long ValueAsLong { get; set; }

        public double ValueAsDouble { get; set; }

        public bool ValueAsBoolean { get; set; }

        public FieldNames FieldNames { get; set; }

        public string TextValue { get; set; }

        public string ValueAsText { get; set; }

        public bool Array { get; set; }

        public Fields Fields { get; set; }

        public bool Null { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The schema of a field.
    /// </summary>
    public class JsonTypeBean
    {
        /// <summary>
        /// The data type of the field.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// When the data type is an array, the name of the field items within the array.
        /// </summary>
        public string Items { get; set; }

        /// <summary>
        /// If the field is a system field, the name of the field.
        /// </summary>
        public string System { get; set; }

        /// <summary>
        /// If the field is a custom field, the URI of the field.
        /// </summary>
        public string Custom { get; set; }

        /// <summary>
        /// If the field is a custom field, the custom ID of the field.
        /// </summary>
        public long CustomId { get; set; }

        /// <summary>
        /// The schema of a field.
        /// </summary>
        public Configuration Configuration { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// An operand that is a JQL keyword. See [Advanced searching - keywords reference](https://confluence.atlassian.com/jiracorecloud/advanced-searching-keywords-reference-765593717.html#Advancedsearching-keywordsreference-EMPTYEMPTY) for more information about operand keywords.
    /// </summary>
    public class KeywordOperand
    {
        /// <summary>
        /// The keyword that is the operand value.
        /// </summary>
        public string Keyword { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class LandingPageInfo : ProjectLandingPageInfo
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class LastModifiedUser : User
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Lead : User
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a license for the Jira instance.
    /// </summary>
    public class License
    {
        /// <summary>
        /// The applications under this license.
        /// </summary>
        public LicensedApplication[] Applications { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a licensed Jira application.
    /// </summary>
    public class LicensedApplication
    {
        /// <summary>
        /// The ID of the application.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The licensing plan.
        /// </summary>
        public string Plan { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The ID or key of a linked issue.
    /// </summary>
    public class LinkedIssue
    {
        /// <summary>
        /// The ID of an issue. Required if `key` isn't provided.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The key of an issue. Required if `id` isn't provided.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The URL of the issue.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID or key of a linked issue.
        /// </summary>
        public Fields Fields { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details a link group, which defines issue operations.
    /// </summary>
    public class LinkGroup
    {
        public string Id { get; set; }

        public string StyleClass { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public SimpleLink Header { get; set; }

        public int Weight { get; set; }

        public SimpleLink[] Links { get; set; }

        public LinkGroup[] Groups { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class LinkIssueRequestJsonBean
    {
        /// <summary>
        /// not-used
        /// </summary>
        public IssueLinkType Type { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public LinkedIssue InwardIssue { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public LinkedIssue OutwardIssue { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public Comment Comment { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class LinkIssuesResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// An operand that is a list of values.
    /// </summary>
    public class ListOperand
    {
        /// <summary>
        /// The list of operand values.
        /// </summary>
        public JqlQueryUnitaryOperand[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ListWrapperCallbackApplicationRole
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ListWrapperCallbackGroupName
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a locale.
    /// </summary>
    public class Locale
    {
        /// <summary>
        /// The locale code. The Java the locale format is used: a two character language code (ISO 639), an underscore, and two letter country code (ISO 3166). For example, en\_US represents a locale of English (United States). Required on create.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Locale")]
        public string Locale_ { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class MergeVersionsResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Meta : JiraExpressionEvaluationMetaDataBean
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class MoveFieldBean
    {
        /// <summary>
        /// The ID of the screen tab field after which to place the moved screen tab field. Required if `position` isn't provided.
        /// </summary>
        public string After { get; set; }

        /// <summary>
        /// The named position to which the screen tab field should be moved. Required if `after` isn't provided.
        /// </summary>
        public string Position { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class MoveScreenTabFieldResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class MoveScreenTabResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A list of issues and their respective properties to set or update. See [Entity properties](https://developer.atlassian.com/cloud/jira/platform/jira-entity-properties/) for more information.
    /// </summary>
    public class MultiIssueEntityProperties
    {
        /// <summary>
        /// A list of issue IDs and their respective properties.
        /// </summary>
        public IssueEntityPropertiesForMultiUpdate[] Issues { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A custom field and its new value with a list of issue to update.
    /// </summary>
    public class MultipleCustomFieldValuesUpdate
    {
        /// <summary>
        /// The ID or key of the custom field. For example, `customfield_10010`.
        /// </summary>
        public string CustomField { get; set; }

        /// <summary>
        /// The list of issue IDs.
        /// </summary>
        public long[] IssueIds { get; set; }

        /// <summary>
        /// A custom field and its new value with a list of issue to update.
        /// </summary>
        public Value Value { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// List of updates for a custom fields.
    /// </summary>
    public class MultipleCustomFieldValuesUpdateDetails
    {
        public MultipleCustomFieldValuesUpdate[] Updates { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Names
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class NestedResponse
    {
        public int Status { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public ErrorCollection ErrorCollection { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The user details.
    /// </summary>
    public class NewUserDetails
    {
        /// <summary>
        /// The URL of the user.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// This property is no longer available. See the [migration guide](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// This property is no longer available. See the [migration guide](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This property is no longer available. If the user has an Atlassian account, their password is not changed. If the user does not have an Atlassian account, they are sent an email asking them set up an account.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The email address for the user.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// A suggested display name for the user. If the user has an Atlassian account, their display name is not changed. If the user does not have an Atlassian account, this display name is used as a suggestion for creating an account. The user is sent an email asking them to set their display name and privacy preferences.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Deprecated, do not use.
        /// </summary>
        public string[] ApplicationKeys { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a notification.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// The subject of the email notification for the issue. If this is not specified, then the subject is set to the issue key and summary.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The plain text body of the email notification for the issue.
        /// </summary>
        public string TextBody { get; set; }

        /// <summary>
        /// The HTML body of the email notification for the issue.
        /// </summary>
        public string HtmlBody { get; set; }

        /// <summary>
        /// Details about a notification.
        /// </summary>
        public To To { get; set; }

        /// <summary>
        /// Details about a notification.
        /// </summary>
        public Restrict Restrict { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a notification event.
    /// </summary>
    public class NotificationEvent
    {
        /// <summary>
        /// The ID of the event. The event can be a [Jira system event](https://confluence.atlassian.com/x/8YdKLg#Creatinganotificationscheme-eventsEvents) or a [custom event](https://confluence.atlassian.com/x/AIlKLg).
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of the event.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the event.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Details about a notification event.
        /// </summary>
        public TemplateEvent TemplateEvent { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the users and groups to receive the notification.
    /// </summary>
    public class NotificationRecipients
    {
        /// <summary>
        /// Whether the notification should be sent to the issue's reporter.
        /// </summary>
        public bool Reporter { get; set; }

        /// <summary>
        /// Whether the notification should be sent to the issue's assignees.
        /// </summary>
        public bool Assignee { get; set; }

        /// <summary>
        /// Whether the notification should be sent to the issue's watchers.
        /// </summary>
        public bool Watchers { get; set; }

        /// <summary>
        /// Whether the notification should be sent to the issue's voters.
        /// </summary>
        public bool Voters { get; set; }

        /// <summary>
        /// List of users to receive the notification.
        /// </summary>
        public UserDetails[] Users { get; set; }

        /// <summary>
        /// List of groups to receive the notification.
        /// </summary>
        public GroupName[] Groups { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the group membership or permissions needed to receive the notification.
    /// </summary>
    public class NotificationRecipientsRestrictions
    {
        /// <summary>
        /// List of group memberships required to receive the notification.
        /// </summary>
        public GroupName[] Groups { get; set; }

        /// <summary>
        /// List of permissions required to receive the notification.
        /// </summary>
        public RestrictedPermission[] Permissions { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a notification scheme.
    /// </summary>
    public class NotificationScheme
    {
        /// <summary>
        /// Expand options that include additional notification scheme details in the response.
        /// </summary>
        public string Expand { get; set; }

        /// <summary>
        /// The ID of the notification scheme.
        /// </summary>
        public long Id { get; set; }

        public string Self { get; set; }

        /// <summary>
        /// The name of the notification scheme.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the notification scheme.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The notification events and associated recipients.
        /// </summary>
        public NotificationSchemeEvent[] NotificationSchemeEvents { get; set; }

        /// <summary>
        /// Details about a notification scheme.
        /// </summary>
        public Scope Scope { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a notification scheme event.
    /// </summary>
    public class NotificationSchemeEvent
    {
        /// <summary>
        /// not-used
        /// </summary>
        public NotificationEvent Event { get; set; }

        public EventNotification[] Notifications { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class NotifyResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Object : RemoteObject
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class OperationMessage
    {
        /// <summary>
        /// The human-readable message that describes the result.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The status code of the response.
        /// </summary>
        public int StatusCode { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the operations that can be performed on the issue.
    /// </summary>
    public class Operations
    {
        /// <summary>
        /// Details of the link groups defining issue operations.
        /// </summary>
        public LinkGroup[] LinkGroups { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// An ordered list of custom field option IDs and information on where to move them.
    /// </summary>
    public class OrderOfCustomFieldOptions
    {
        /// <summary>
        /// A list of IDs of custom field options to move. The order of the custom field option IDs in the list is the order they are given after the move. The list must contain custom field options or cascading options, but not both.
        /// </summary>
        public string[] CustomFieldOptionIds { get; set; }

        /// <summary>
        /// The ID of the custom field option or cascading option to place the moved options after. Required if `position` isn't provided.
        /// </summary>
        public string After { get; set; }

        /// <summary>
        /// The position the custom field options should be moved to. Required if `after` isn't provided.
        /// </summary>
        public string Position { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// An ordered list of issue type IDs and information about where to move them.
    /// </summary>
    public class OrderOfIssueTypes
    {
        /// <summary>
        /// A list of the issue type IDs to move. The order of the issue type IDs in the list is the order they are given after the move.
        /// </summary>
        public string[] IssueTypeIds { get; set; }

        /// <summary>
        /// The ID of the issue type to place the moved issue types after. Required if `position` isn't provided.
        /// </summary>
        public string After { get; set; }

        /// <summary>
        /// The position the issue types should be moved to. Required if `after` isn't provided.
        /// </summary>
        public string Position { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class OriginalIssueTypeMappings
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class OutwardIssue : LinkedIssue
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Owner : UserBean
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanChangelog
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public Changelog[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanComment
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public Comment[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanComponentWithIssueCount
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public ComponentWithIssueCount[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanContext
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public Context[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanContextForProjectAndIssueType
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public ContextForProjectAndIssueType[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanContextualConfiguration
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public ContextualConfiguration[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanCustomFieldContext
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public CustomFieldContext[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanCustomFieldContextDefaultValue
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public CustomFieldContextDefaultValue[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanCustomFieldContextOption
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public CustomFieldContextOption[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanCustomFieldContextProjectMapping
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public CustomFieldContextProjectMapping[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanDashboard
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public Dashboard[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanField
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public Field[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanFieldConfigurationDetails
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public FieldConfigurationDetails[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanFieldConfigurationIssueTypeItem
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public FieldConfigurationIssueTypeItem[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanFieldConfigurationItem
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public FieldConfigurationItem[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanFieldConfigurationScheme
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public FieldConfigurationScheme[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanFieldConfigurationSchemeProjects
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public FieldConfigurationSchemeProjects[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanFilterDetails
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public FilterDetails[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanGroupDetails
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public GroupDetails[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanIssueFieldOption
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public IssueFieldOption[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanIssueSecurityLevelMember
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public IssueSecurityLevelMember[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanIssueTypeScheme
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public IssueTypeScheme[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanIssueTypeSchemeMapping
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public IssueTypeSchemeMapping[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanIssueTypeSchemeProjects
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public IssueTypeSchemeProjects[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanIssueTypeScreenScheme
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public IssueTypeScreenScheme[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanIssueTypeScreenSchemeItem
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public IssueTypeScreenSchemeItem[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanIssueTypeScreenSchemesProjects
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public IssueTypeScreenSchemesProjects[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanIssueTypeToContextMapping
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public IssueTypeToContextMapping[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanNotificationScheme
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public NotificationScheme[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanProject
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public Project[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanProjectDetails
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public ProjectDetails[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanScreen
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public Screen[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanScreenScheme
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public ScreenScheme[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanScreenWithTab
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public ScreenWithTab[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanString
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public string[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanUser
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public User[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanUserDetails
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public UserDetails[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanUserKey
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public UserKey[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanVersion
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public Version[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanWebhook
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public Webhook[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanWorkflow
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public Workflow[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanWorkflowScheme
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public WorkflowScheme[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of items.
    /// </summary>
    public class PageBeanWorkflowTransitionRules
    {
        /// <summary>
        /// The URL of the page.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// If there is another page of results, the URL of the next page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Whether this is the last page.
        /// </summary>
        public bool IsLast { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public WorkflowTransitionRules[] Values { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A paged list. To access additional details append `[start-index:end-index]` to the expand request. For example, `?expand=sharedUsers[10:40]` returns a list starting at item 10 and finishing at item 40.
    /// </summary>
    public class PagedListUserDetailsApplicationUser
    {
        /// <summary>
        /// The number of items on the page.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public UserDetails[] Items { get; set; }

        /// <summary>
        /// The maximum number of results that could be on the page.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned on the page.
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// The index of the last item returned on the page.
        /// </summary>
        public int EndIndex { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of changelogs.
    /// </summary>
    public class PageOfChangelogs
    {
        /// <summary>
        /// The index of the first item returned on the page.
        /// </summary>
        public int StartAt { get; set; }

        /// <summary>
        /// The maximum number of results that could be on the page.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The number of results on the page.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// The list of changelogs.
        /// </summary>
        public Changelog[] Histories { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page of comments.
    /// </summary>
    public class PageOfComments
    {
        /// <summary>
        /// The index of the first item returned.
        /// </summary>
        public long StartAt { get; set; }

        /// <summary>
        /// The maximum number of items that could be returned.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The number of items returned.
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// The list of comments.
        /// </summary>
        public Comment[] Comments { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A page containing dashboard details.
    /// </summary>
    public class PageOfDashboards
    {
        /// <summary>
        /// The index of the first item returned on the page.
        /// </summary>
        public int StartAt { get; set; }

        /// <summary>
        /// The maximum number of results that could be on the page.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The number of results on the page.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// The URL of the previous page of results, if any.
        /// </summary>
        public string Prev { get; set; }

        /// <summary>
        /// The URL of the next page of results, if any.
        /// </summary>
        public string Next { get; set; }

        /// <summary>
        /// List of dashboards.
        /// </summary>
        public Dashboard[] Dashboards { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Paginated list of worklog details
    /// </summary>
    public class PageOfWorklogs
    {
        /// <summary>
        /// The index of the first item returned on the page.
        /// </summary>
        public int StartAt { get; set; }

        /// <summary>
        /// The maximum number of results that could be on the page.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The number of results on the page.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// List of worklogs.
        /// </summary>
        public Worklog[] Worklogs { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class PaginatedResponseComment
    {
        public long Total { get; set; }

        public int MaxResults { get; set; }

        public long StartAt { get; set; }

        public Comment[] Results { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A list of parsed JQL queries.
    /// </summary>
    public class ParsedJqlQueries
    {
        /// <summary>
        /// A list of parsed JQL queries.
        /// </summary>
        public ParsedJqlQuery[] Queries { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a parsed JQL query.
    /// </summary>
    public class ParsedJqlQuery
    {
        /// <summary>
        /// The JQL query that was parsed and validated.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Details of a parsed JQL query.
        /// </summary>
        public Structure Structure { get; set; }

        /// <summary>
        /// The list of syntax or validation errors.
        /// </summary>
        public string[] Errors { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a permission granted to a user or group.
    /// </summary>
    public class PermissionGrant
    {
        /// <summary>
        /// The ID of the permission granted details.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The URL of the permission granted details.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// Details about a permission granted to a user or group.
        /// </summary>
        public Holder Holder { get; set; }

        /// <summary>
        /// The permission to grant. This permission can be one of the built-in permissions or a custom permission added by an app. See [Built-in permissions](../api-group-permission-schemes/#built-in-permissions) in *Get all permission schemes* for more information about the built-in permissions. See the [project permission](https://developer.atlassian.com/cloud/jira/platform/modules/project-permission/) and [global permission](https://developer.atlassian.com/cloud/jira/platform/modules/global-permission/) module documentation for more information about custom permissions.
        /// </summary>
        public string Permission { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// List of permission grants.
    /// </summary>
    public class PermissionGrants
    {
        /// <summary>
        /// Permission grants list.
        /// </summary>
        public PermissionGrant[] Permissions { get; set; }

        /// <summary>
        /// Expand options that include additional permission grant details in the response.
        /// </summary>
        public string Expand { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a user, group, field, or project role that holds a permission. See [Holder object](../api-group-permission-schemes/#holder-object) in *Get all permission schemes* for more information.
    /// </summary>
    public class PermissionHolder
    {
        /// <summary>
        /// The type of permission holder.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The identifier of permission holder.
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        /// Expand options that include additional permission holder details in the response.
        /// </summary>
        public string Expand { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about permissions.
    /// </summary>
    public class Permissions
    {
        /// <summary>
        /// Details about permissions.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Permissions")]
        public Permissions Permissions_ { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a permission scheme.
    /// </summary>
    public class PermissionScheme
    {
        /// <summary>
        /// The expand options available for the permission scheme.
        /// </summary>
        public string Expand { get; set; }

        /// <summary>
        /// The ID of the permission scheme.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The URL of the permission scheme.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The name of the permission scheme. Must be unique.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A description for the permission scheme.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Details of a permission scheme.
        /// </summary>
        public Scope Scope { get; set; }

        /// <summary>
        /// The permission scheme to create or update. See [About permission schemes and grants](../api-group-permission-schemes/#about-permission-schemes-and-grants) for more information.
        /// </summary>
        public PermissionGrant[] Permissions { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// List of all permission schemes.
    /// </summary>
    public class PermissionSchemes
    {
        /// <summary>
        /// Permission schemes list.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("PermissionSchemes")]
        public PermissionScheme[] PermissionSchemes_ { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class PermissionsKeysBean
    {
        /// <summary>
        /// A list of permission keys.
        /// </summary>
        public string[] Permissions { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A list of projects in which a user is granted permissions.
    /// </summary>
    public class PermittedProjects
    {
        /// <summary>
        /// A list of projects.
        /// </summary>
        public ProjectIdentifierBean[] Projects { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class PrimitiveValues : JiraExpressionsComplexityValueBean
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// An issue priority.
    /// </summary>
    public class Priority
    {
        /// <summary>
        /// The URL of the issue priority.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The color used to indicate the issue priority.
        /// </summary>
        public string StatusColor { get; set; }

        /// <summary>
        /// The description of the issue priority.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The URL of the icon for the issue priority.
        /// </summary>
        public string IconUrl { get; set; }

        /// <summary>
        /// The name of the issue priority.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The ID of the issue priority.
        /// </summary>
        public string Id { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a project.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Expand options that include additional project details in the response.
        /// </summary>
        public string Expand { get; set; }

        /// <summary>
        /// The URL of the project details.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The key of the project.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// A brief description of the project.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Details about a project.
        /// </summary>
        public Lead Lead { get; set; }

        /// <summary>
        /// List of the components contained in the project.
        /// </summary>
        public ProjectComponent[] Components { get; set; }

        /// <summary>
        /// List of the issue types available in the project.
        /// </summary>
        public IssueTypeDetails[] IssueTypes { get; set; }

        /// <summary>
        /// A link to information about this project, such as project documentation.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// An email address associated with the project.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The default assignee when creating issues for this project.
        /// </summary>
        public string AssigneeType { get; set; }

        /// <summary>
        /// The versions defined in the project. For more information, see [Create version](#api-rest-api-3-version-post).
        /// </summary>
        public Version[] Versions { get; set; }

        /// <summary>
        /// The name of the project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Details about a project.
        /// </summary>
        public Roles Roles { get; set; }

        /// <summary>
        /// Details about a project.
        /// </summary>
        public AvatarUrls AvatarUrls { get; set; }

        /// <summary>
        /// Details about a project.
        /// </summary>
        public ProjectCategory ProjectCategory { get; set; }

        /// <summary>
        /// The [project type](https://confluence.atlassian.com/x/GwiiLQ#Jiraapplicationsoverview-Productfeaturesandprojecttypes) of the project.
        /// </summary>
        public string ProjectTypeKey { get; set; }

        /// <summary>
        /// Whether the project is simplified.
        /// </summary>
        public bool Simplified { get; set; }

        /// <summary>
        /// The type of the project.
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// Whether the project is selected as a favorite.
        /// </summary>
        public bool Favourite { get; set; }

        /// <summary>
        /// Whether the project is private.
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Details about a project.
        /// </summary>
        public IssueTypeHierarchy IssueTypeHierarchy { get; set; }

        /// <summary>
        /// Details about a project.
        /// </summary>
        public Permissions Permissions { get; set; }

        /// <summary>
        /// Details about a project.
        /// </summary>
        public Properties Properties { get; set; }

        /// <summary>
        /// Unique ID for next-gen projects.
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// Details about a project.
        /// </summary>
        public Insight Insight { get; set; }

        /// <summary>
        /// Whether the project is marked as deleted.
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// The date when the project is deleted permanently.
        /// </summary>
        public DateTime RetentionTillDate { get; set; }

        /// <summary>
        /// The date when the project was marked as deleted.
        /// </summary>
        public DateTime DeletedDate { get; set; }

        /// <summary>
        /// Details about a project.
        /// </summary>
        public DeletedBy DeletedBy { get; set; }

        /// <summary>
        /// Whether the project is archived.
        /// </summary>
        public bool Archived { get; set; }

        /// <summary>
        /// The date when the project was archived.
        /// </summary>
        public DateTime ArchivedDate { get; set; }

        /// <summary>
        /// Details about a project.
        /// </summary>
        public ArchivedBy ArchivedBy { get; set; }

        /// <summary>
        /// Details about a project.
        /// </summary>
        public LandingPageInfo LandingPageInfo { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// List of project avatars.
    /// </summary>
    public class ProjectAvatars
    {
        /// <summary>
        /// List of avatars included with Jira. These avatars cannot be deleted.
        /// </summary>
        public Avatar[] System { get; set; }

        /// <summary>
        /// List of avatars added to Jira. These avatars may be deleted.
        /// </summary>
        public Avatar[] Custom { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A project category.
    /// </summary>
    public class ProjectCategory
    {
        /// <summary>
        /// The URL of the project category.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID of the project category.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the project category. Required on create, optional on update.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the project category.
        /// </summary>
        public string Description { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a project component.
    /// </summary>
    public class ProjectComponent
    {
        /// <summary>
        /// The URL of the component.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The unique identifier for the component.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The unique name for the component in the project. Required when creating a component. Optional when updating a component. The maximum length is 255 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description for the component. Optional when creating or updating a component.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Details about a project component.
        /// </summary>
        public Lead Lead { get; set; }

        /// <summary>
        /// This property is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.
        /// </summary>
        public string LeadUserName { get; set; }

        /// <summary>
        /// The accountId of the component's lead user. The accountId uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.
        /// </summary>
        public string LeadAccountId { get; set; }

        /// <summary>
        /// The nominal user type used to determine the assignee for issues created with this component. See `realAssigneeType` for details on how the type of the user, and hence the user, assigned to issues is determined. Can take the following values: *  `PROJECT_LEAD` the assignee to any issues created with this component is nominally the lead for the project the component is in. *  `COMPONENT_LEAD` the assignee to any issues created with this component is nominally the lead for the component. *  `UNASSIGNED` an assignee is not set for issues created with this component. *  `PROJECT_DEFAULT` the assignee to any issues created with this component is nominally the default assignee for the project that the component is in.Default value: `PROJECT_DEFAULT`.  Optional when creating or updating a component.
        /// </summary>
        public string AssigneeType { get; set; }

        /// <summary>
        /// Details about a project component.
        /// </summary>
        public Assignee Assignee { get; set; }

        /// <summary>
        /// The type of the assignee that is assigned to issues created with this component, when an assignee cannot be set from the `assigneeType`. For example, `assigneeType` is set to `COMPONENT_LEAD` but no component lead is set. This property is set to one of the following values: *  `PROJECT_LEAD` when `assigneeType` is `PROJECT_LEAD` and the project lead has permission to be assigned issues in the project that the component is in. *  `COMPONENT_LEAD` when `assignee`Type is `COMPONENT_LEAD` and the component lead has permission to be assigned issues in the project that the component is in. *  `UNASSIGNED` when `assigneeType` is `UNASSIGNED` and Jira is configured to allow unassigned issues. *  `PROJECT_DEFAULT` when none of the preceding cases are true.
        /// </summary>
        public string RealAssigneeType { get; set; }

        /// <summary>
        /// Details about a project component.
        /// </summary>
        public RealAssignee RealAssignee { get; set; }

        /// <summary>
        /// Whether a user is associated with `assigneeType`. For example, if the `assigneeType` is set to `COMPONENT_LEAD` but the component lead is not set, then `false` is returned.
        /// </summary>
        public bool IsAssigneeTypeValid { get; set; }

        /// <summary>
        /// The key of the project the component is assigned to. Required when creating a component. Can't be updated.
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// The ID of the project the component is assigned to.
        /// </summary>
        public long ProjectId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a project.
    /// </summary>
    public class ProjectDetails
    {
        /// <summary>
        /// The URL of the project details.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The key of the project.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The name of the project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The [project type](https://confluence.atlassian.com/x/GwiiLQ#Jiraapplicationsoverview-Productfeaturesandprojecttypes) of the project.
        /// </summary>
        public string ProjectTypeKey { get; set; }

        /// <summary>
        /// Whether or not the project is simplified.
        /// </summary>
        public bool Simplified { get; set; }

        /// <summary>
        /// Details about a project.
        /// </summary>
        public AvatarUrls AvatarUrls { get; set; }

        /// <summary>
        /// Details about a project.
        /// </summary>
        public ProjectCategory ProjectCategory { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A project's sender email address.
    /// </summary>
    public class ProjectEmailAddress
    {
        /// <summary>
        /// The email address.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// When using a custom domain, the status of the email address.
        /// </summary>
        public string[] EmailAddressStatus { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a project feature.
    /// </summary>
    public class ProjectFeature
    {
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public long ProjectId { get; set; }

        /// <summary>
        /// The state of the feature. When updating the state of a feature, only ENABLED and DISABLED are supported. Responses can contain all values
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Whether the state of the feature can be updated.
        /// </summary>
        public bool ToggleLocked { get; set; }

        /// <summary>
        /// The key of the feature.
        /// </summary>
        public string Feature { get; set; }

        /// <summary>
        /// List of keys of the features required to enable the feature.
        /// </summary>
        public string[] Prerequisites { get; set; }

        /// <summary>
        /// Localized display name for the feature.
        /// </summary>
        public string LocalisedName { get; set; }

        /// <summary>
        /// Localized display description for the feature.
        /// </summary>
        public string LocalisedDescription { get; set; }

        /// <summary>
        /// URI for the image representing the feature.
        /// </summary>
        public string ImageUri { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the feature state.
    /// </summary>
    public class ProjectFeatureState
    {
        /// <summary>
        /// The feature state.
        /// </summary>
        public string State { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The identifiers for a project.
    /// </summary>
    public class ProjectIdentifierBean
    {
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The key of the project.
        /// </summary>
        public string Key { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Identifiers for a project.
    /// </summary>
    public class ProjectIdentifiers
    {
        /// <summary>
        /// The URL of the created project.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID of the created project.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The key of the created project.
        /// </summary>
        public string Key { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A list of project IDs.
    /// </summary>
    public class ProjectIds
    {
        /// <summary>
        /// The IDs of projects.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("ProjectIds")]
        public string[] ProjectIds_ { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Additional details about a project.
    /// </summary>
    public class ProjectInsight
    {
        /// <summary>
        /// Total issue count.
        /// </summary>
        public long TotalIssueCount { get; set; }

        /// <summary>
        /// The last issue update time.
        /// </summary>
        public DateTime LastIssueUpdateTime { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the issue creation metadata for a project.
    /// </summary>
    public class ProjectIssueCreateMetadata
    {
        /// <summary>
        /// Expand options that include additional project issue create metadata details in the response.
        /// </summary>
        public string Expand { get; set; }

        /// <summary>
        /// The URL of the project.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The key of the project.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The name of the project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Details of the issue creation metadata for a project.
        /// </summary>
        public AvatarUrls AvatarUrls { get; set; }

        /// <summary>
        /// List of the issue types supported by the project.
        /// </summary>
        public IssueTypeIssueCreateMetadata[] Issuetypes { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// List of issue level security items in a project.
    /// </summary>
    public class ProjectIssueSecurityLevels
    {
        /// <summary>
        /// Issue level security items list.
        /// </summary>
        public SecurityLevel[] Levels { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The hierarchy of issue types within a project.
    /// </summary>
    public class ProjectIssueTypeHierarchy
    {
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public long ProjectId { get; set; }

        /// <summary>
        /// Details of an issue type hierarchy level.
        /// </summary>
        public ProjectIssueTypesHierarchyLevel[] Hierarchy { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The project and issue type mapping.
    /// </summary>
    public class ProjectIssueTypeMapping
    {
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string ProjectId { get; set; }

        /// <summary>
        /// The ID of the issue type.
        /// </summary>
        public string IssueTypeId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The project and issue type mappings.
    /// </summary>
    public class ProjectIssueTypeMappings
    {
        /// <summary>
        /// The project and issue type mappings.
        /// </summary>
        public ProjectIssueTypeMapping[] Mappings { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an issue type hierarchy level.
    /// </summary>
    public class ProjectIssueTypesHierarchyLevel
    {
        /// <summary>
        /// The ID of the issue type hierarchy level. This property is deprecated, see [Change notice: Removing hierarchy level IDs from next-gen APIs](https://developer.atlassian.com/cloud/jira/platform/change-notice-removing-hierarchy-level-ids-from-next-gen-apis/).
        /// </summary>
        public string EntityId { get; set; }

        /// <summary>
        /// The level of the issue type hierarchy level.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// The name of the issue type hierarchy level.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The list of issue types in the hierarchy level.
        /// </summary>
        public IssueTypeInfo[] IssueTypes { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ProjectLandingPageInfo
    {
        public string Url { get; set; }

        public string ProjectKey { get; set; }

        public string ProjectType { get; set; }

        public long BoardId { get; set; }

        public bool Simplified { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Permissions which a user has on a project.
    /// </summary>
    public class ProjectPermissions
    {
        /// <summary>
        /// Whether the logged user can edit the project.
        /// </summary>
        public bool CanEdit { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about the roles in a project.
    /// </summary>
    public class ProjectRole
    {
        /// <summary>
        /// The URL the project role details.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The name of the project role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The ID of the project role.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The description of the project role.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The list of users who act in this role.
        /// </summary>
        public RoleActor[] Actors { get; set; }

        /// <summary>
        /// Details about the roles in a project.
        /// </summary>
        public Scope Scope { get; set; }

        /// <summary>
        /// The translated name of the project role.
        /// </summary>
        public string TranslatedName { get; set; }

        /// <summary>
        /// Whether the calling user is part of this role.
        /// </summary>
        public bool CurrentUserRole { get; set; }

        /// <summary>
        /// Whether this role is the admin role for the project.
        /// </summary>
        public bool Admin { get; set; }

        /// <summary>
        /// Whether the roles are configurable for this project.
        /// </summary>
        public bool RoleConfigurable { get; set; }

        /// <summary>
        /// Whether this role is the default role for the project
        /// </summary>
        public bool Default { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ProjectRoleActorsUpdateBean
    {
        /// <summary>
        /// The ID of the project role. Use [Get all project roles](#api-rest-api-3-role-get) to get a list of project role IDs.
        /// </summary>
        public long Id { get; set; }

        public CategorisedActors CategorisedActors { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a project role.
    /// </summary>
    public class ProjectRoleDetails
    {
        /// <summary>
        /// The URL the project role details.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The name of the project role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The ID of the project role.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The description of the project role.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Whether this role is the admin role for the project.
        /// </summary>
        public bool Admin { get; set; }

        /// <summary>
        /// Details about a project role.
        /// </summary>
        public Scope Scope { get; set; }

        /// <summary>
        /// Whether the roles are configurable for this project.
        /// </summary>
        public bool RoleConfigurable { get; set; }

        /// <summary>
        /// The translated name of the project role.
        /// </summary>
        public string TranslatedName { get; set; }

        /// <summary>
        /// Whether this role is the default role for the project.
        /// </summary>
        public bool Default { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the group associated with the role.
    /// </summary>
    public class ProjectRoleGroup
    {
        /// <summary>
        /// The display name of the group.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The name of the group
        /// </summary>
        public string Name { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the user associated with the role.
    /// </summary>
    public class ProjectRoleUser
    {
        /// <summary>
        /// The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*. Returns *unknown* if the record is deleted and corrupted, for example, as the result of a server import.
        /// </summary>
        public string AccountId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ProjectScopeBean
    {
        /// <summary>
        /// The ID of the project that the option's behavior applies to.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Defines the behavior of the option in the project.If notSelectable is set, the option cannot be set as the field's value. This is useful for archiving an option that has previously been selected but shouldn't be used anymore.If defaultValue is set, the option is selected by default.
        /// </summary>
        public string[] Attributes { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a project type.
    /// </summary>
    public class ProjectType
    {
        /// <summary>
        /// The key of the project type.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The formatted key of the project type.
        /// </summary>
        public string FormattedKey { get; set; }

        /// <summary>
        /// The key of the project type's description.
        /// </summary>
        public string DescriptionI18nKey { get; set; }

        /// <summary>
        /// The icon of the project type.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// The color of the project type.
        /// </summary>
        public string Color { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Properties
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Property key details.
    /// </summary>
    public class PropertyKey
    {
        /// <summary>
        /// The URL of the property.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The key of the property.
        /// </summary>
        public string Key { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// List of property keys.
    /// </summary>
    public class PropertyKeys
    {
        /// <summary>
        /// Property key details.
        /// </summary>
        public PropertyKey[] Keys { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about the status mappings for publishing a draft workflow scheme.
    /// </summary>
    public class PublishDraftWorkflowScheme
    {
        /// <summary>
        /// Mappings of statuses to new statuses for issue types.
        /// </summary>
        public StatusMapping[] StatusMappings { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Properties that identify a published workflow.
    /// </summary>
    public class PublishedWorkflowId
    {
        /// <summary>
        /// The name of the workflow.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The entity ID of the workflow.
        /// </summary>
        public string EntityId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class RealAssignee : User
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// ID of a registered webhook or error messages explaining why a webhook wasn't registered.
    /// </summary>
    public class RegisteredWebhook
    {
        /// <summary>
        /// The ID of the webhook. Returned if the webhook is created.
        /// </summary>
        public long CreatedWebhookId { get; set; }

        /// <summary>
        /// Error messages specifying why the webhook creation failed.
        /// </summary>
        public string[] Errors { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an issue remote link.
    /// </summary>
    public class RemoteIssueLink
    {
        /// <summary>
        /// The ID of the link.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The URL of the link.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The global ID of the link, such as the ID of the item on the remote system.
        /// </summary>
        public string GlobalId { get; set; }

        /// <summary>
        /// Details of an issue remote link.
        /// </summary>
        public Application Application { get; set; }

        /// <summary>
        /// Description of the relationship between the issue and the linked item.
        /// </summary>
        public string Relationship { get; set; }

        /// <summary>
        /// Details of an issue remote link.
        /// </summary>
        public Object Object { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the identifiers for a created or updated remote issue link.
    /// </summary>
    public class RemoteIssueLinkIdentifies
    {
        /// <summary>
        /// The ID of the remote issue link, such as the ID of the item on the remote system.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The URL of the remote issue link.
        /// </summary>
        public string Self { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a remote issue link.
    /// </summary>
    public class RemoteIssueLinkRequest
    {
        /// <summary>
        /// An identifier for the remote item in the remote system. For example, the global ID for a remote item in Confluence would consist of the app ID and page ID, like this: `appId=456&pageId=123`.Setting this field enables the remote issue link details to be updated or deleted using remote system and item details as the record identifier, rather than using the record's Jira ID.The maximum length is 255 characters.
        /// </summary>
        public string GlobalId { get; set; }

        /// <summary>
        /// Details of a remote issue link.
        /// </summary>
        public Application Application { get; set; }

        /// <summary>
        /// Description of the relationship between the issue and the linked item. If not set, the relationship description "links to" is used in Jira.
        /// </summary>
        public string Relationship { get; set; }

        /// <summary>
        /// Details of a remote issue link.
        /// </summary>
        public Object Object { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The linked item.
    /// </summary>
    public class RemoteObject
    {
        /// <summary>
        /// The URL of the item.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The title of the item.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The summary details of the item.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// The linked item.
        /// </summary>
        public Icon Icon { get; set; }

        /// <summary>
        /// The linked item.
        /// </summary>
        public Status Status { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Remove
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class RemoveCustomFieldContextFromProjectsResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class RemoveIssueTypeFromIssueTypeSchemeResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class RemoveIssueTypesFromContextResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class RemoveIssueTypesFromGlobalFieldConfigurationSchemeResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class RemoveMappingsFromIssueTypeScreenSchemeResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class RemoveOptionFromIssuesResult
    {
        /// <summary>
        /// The IDs of the modified issues.
        /// </summary>
        public long[] ModifiedIssues { get; set; }

        /// <summary>
        /// The IDs of the unchanged issues, those issues where errors prevent modification.
        /// </summary>
        public long[] UnmodifiedIssues { get; set; }

        public Errors Errors { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class RenderedFields
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ReorderCustomFieldOptionsResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class ReorderIssueTypesInIssueTypeSchemeResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an issue resolution.
    /// </summary>
    public class Resolution
    {
        /// <summary>
        /// The URL of the issue resolution.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID of the issue resolution.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The description of the issue resolution.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The name of the issue resolution.
        /// </summary>
        public string Name { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class RestoreCustomFieldResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Restrict : NotificationRecipientsRestrictions
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the permission.
    /// </summary>
    public class RestrictedPermission
    {
        /// <summary>
        /// The ID of the permission. Either `id` or `key` must be specified. Use [Get all permissions](#api-rest-api-3-permissions-get) to get the list of permissions.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The key of the permission. Either `id` or `key` must be specified. Use [Get all permissions](#api-rest-api-3-permissions-get) to get the list of permissions.
        /// </summary>
        public string Key { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Result : RemoveOptionFromIssuesResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class RichText
    {
        public bool ValueSet { get; set; }

        public bool Finalised { get; set; }

        public bool EmptyAdf { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Role : ProjectRole
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a user assigned to a project role.
    /// </summary>
    public class RoleActor
    {
        /// <summary>
        /// The ID of the role actor.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The display name of the role actor. For users, depending on the user’s privacy setting, this may return an alternative value for the user's name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The type of role actor.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// This property is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The avatar of the role actor.
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Details about a user assigned to a project role.
        /// </summary>
        public ActorUser ActorUser { get; set; }

        /// <summary>
        /// Details about a user assigned to a project role.
        /// </summary>
        public ActorGroup ActorGroup { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Roles
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A rule configuration.
    /// </summary>
    public class RuleConfiguration
    {
        /// <summary>
        /// Configuration of the rule, as it is stored by the Connect app on the rule configuration page.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// EXPERIMENTAL: Whether the rule is disabled.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// EXPERIMENTAL: A tag used to filter rules in [Get workflow transition rule configurations](https://developer.atlassian.com/cloud/jira/platform/rest/v3/api-group-workflow-transition-rules/#api-rest-api-3-workflow-rule-config-get).
        /// </summary>
        public string Tag { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Rules : CreateWorkflowTransitionRulesDetails
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class RuleUpdateErrors
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Schema : JsonTypeBean
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The projects the item is associated with. Indicated for items associated with [next-gen projects](https://confluence.atlassian.com/x/loMyO).
    /// </summary>
    public class Scope
    {
        /// <summary>
        /// The type of scope.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The projects the item is associated with. Indicated for items associated with [next-gen projects](https://confluence.atlassian.com/x/loMyO).
        /// </summary>
        public Project Project { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A screen.
    /// </summary>
    public class Screen
    {
        /// <summary>
        /// The ID of the screen.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of the screen.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the screen.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A screen.
        /// </summary>
        public Scope Scope { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A screen tab field.
    /// </summary>
    public class ScreenableField
    {
        /// <summary>
        /// The ID of the screen tab field.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the screen tab field. Required on create and update. The maximum length is 255 characters.
        /// </summary>
        public string Name { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A screen tab.
    /// </summary>
    public class ScreenableTab
    {
        /// <summary>
        /// The ID of the screen tab.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of the screen tab. The maximum length is 255 characters.
        /// </summary>
        public string Name { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a screen.
    /// </summary>
    public class ScreenDetails
    {
        /// <summary>
        /// The name of the screen. The name must be unique. The maximum length is 255 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the screen. The maximum length is 255 characters.
        /// </summary>
        public string Description { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Screens : ScreenTypes
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A screen scheme.
    /// </summary>
    public class ScreenScheme
    {
        /// <summary>
        /// The ID of the screen scheme.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of the screen scheme.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the screen scheme.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A screen scheme.
        /// </summary>
        public Screens Screens { get; set; }

        /// <summary>
        /// A screen scheme.
        /// </summary>
        public IssueTypeScreenSchemes IssueTypeScreenSchemes { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a screen scheme.
    /// </summary>
    public class ScreenSchemeDetails
    {
        /// <summary>
        /// The name of the screen scheme. The name must be unique. The maximum length is 255 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the screen scheme. The maximum length is 255 characters.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Details of a screen scheme.
        /// </summary>
        public Screens Screens { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The ID of a screen scheme.
    /// </summary>
    public class ScreenSchemeId
    {
        /// <summary>
        /// The ID of the screen scheme.
        /// </summary>
        public long Id { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The IDs of the screens for the screen types of the screen scheme.
    /// </summary>
    public class ScreenTypes
    {
        /// <summary>
        /// The ID of the edit screen.
        /// </summary>
        public long Edit { get; set; }

        /// <summary>
        /// The ID of the create screen.
        /// </summary>
        public long Create { get; set; }

        /// <summary>
        /// The ID of the view screen.
        /// </summary>
        public long View { get; set; }

        /// <summary>
        /// The ID of the default screen. Required when creating a screen scheme.
        /// </summary>
        public long Default { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A screen with tab details.
    /// </summary>
    public class ScreenWithTab
    {
        /// <summary>
        /// The ID of the screen.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of the screen.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the screen.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A screen with tab details.
        /// </summary>
        public Scope Scope { get; set; }

        /// <summary>
        /// A screen with tab details.
        /// </summary>
        public Tab Tab { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of how to filter and list search auto complete information.
    /// </summary>
    public class SearchAutoCompleteFilter
    {
        /// <summary>
        /// List of project IDs used to filter the visible field details returned.
        /// </summary>
        public long[] ProjectIds { get; set; }

        /// <summary>
        /// Include collapsed fields for fields that have non-unique names.
        /// </summary>
        public bool IncludeCollapsedFields { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SearchRequestBean
    {
        /// <summary>
        /// A [JQL](https://confluence.atlassian.com/x/egORLQ) expression.
        /// </summary>
        public string Jql { get; set; }

        /// <summary>
        /// The index of the first item to return in the page of results (page offset). The base index is `0`.
        /// </summary>
        public int StartAt { get; set; }

        /// <summary>
        /// The maximum number of items to return per page.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// A list of fields to return for each issue, use it to retrieve a subset of fields. This parameter accepts a comma-separated list. Expand options include: *  `*all` Returns all fields. *  `*navigable` Returns navigable fields. *  Any issue field, prefixed with a minus to exclude.The default is `*navigable`.Examples: *  `summary,comment` Returns the summary and comments fields only. *  `-description` Returns all navigable (default) fields except description. *  `*all,-comment` Returns all fields except comments.Multiple `fields` parameters can be included in a request.Note: All navigable fields are returned by default. This differs from [GET issue](#api-rest-api-3-issue-issueIdOrKey-get) where the default is all fields.
        /// </summary>
        public string[] Fields { get; set; }

        /// <summary>
        /// Determines how to validate the JQL query and treat the validation results. Supported values: *  `strict` Returns a 400 response code if any errors are found, along with a list of all errors (and warnings). *  `warn` Returns all errors as warnings. *  `none` No validation is performed. *  `true` *Deprecated* A legacy synonym for `strict`. *  `false` *Deprecated* A legacy synonym for `warn`.The default is `strict`.Note: If the JQL is not correctly formed a 400 response code is returned, regardless of the `validateQuery` value.
        /// </summary>
        public string ValidateQuery { get; set; }

        /// <summary>
        /// Use [expand](em>#expansion) to include additional information about issues in the response. Note that, unlike the majority of instances where `expand` is specified, `expand` is defined as a list of values. The expand options are: *  `renderedFields` Returns field values rendered in HTML format. *  `names` Returns the display name of each field. *  `schema` Returns the schema describing a field type. *  `transitions` Returns all possible transitions for the issue. *  `operations` Returns all possible operations for the issue. *  `editmeta` Returns information about how each field can be edited. *  `changelog` Returns a list of recent updates to an issue, sorted by date, starting from the most recent. *  `versionedRepresentations` Instead of `fields`, returns `versionedRepresentations` a JSON array containing each version of a field's value, with the highest numbered item representing the most recent version.
        /// </summary>
        public string[] Expand { get; set; }

        /// <summary>
        /// A list of up to 5 issue properties to include in the results. This parameter accepts a comma-separated list.
        /// </summary>
        public string[] Properties { get; set; }

        /// <summary>
        /// Reference fields by their key (rather than ID). The default is `false`.
        /// </summary>
        public bool FieldsByKeys { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The result of a JQL search.
    /// </summary>
    public class SearchResults
    {
        /// <summary>
        /// Expand options that include additional search result details in the response.
        /// </summary>
        public string Expand { get; set; }

        /// <summary>
        /// The index of the first item returned on the page.
        /// </summary>
        public int StartAt { get; set; }

        /// <summary>
        /// The maximum number of results that could be on the page.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The number of results on the page.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// The list of issues found by the search.
        /// </summary>
        public IssueBean[] Issues { get; set; }

        /// <summary>
        /// Any warnings related to the JQL query.
        /// </summary>
        public string[] WarningMessages { get; set; }

        /// <summary>
        /// The result of a JQL search.
        /// </summary>
        public Names Names { get; set; }

        /// <summary>
        /// The result of a JQL search.
        /// </summary>
        public Schema Schema { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of an issue level security item.
    /// </summary>
    public class SecurityLevel
    {
        /// <summary>
        /// The URL of the issue level security item.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID of the issue level security item.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The description of the issue level security item.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The name of the issue level security item.
        /// </summary>
        public string Name { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a security scheme.
    /// </summary>
    public class SecurityScheme
    {
        /// <summary>
        /// The URL of the issue security scheme.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID of the issue security scheme.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of the issue security scheme.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the issue security scheme.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The ID of the default security level.
        /// </summary>
        public long DefaultSecurityLevelId { get; set; }

        public SecurityLevel[] Levels { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// List of security schemes.
    /// </summary>
    public class SecuritySchemes
    {
        /// <summary>
        /// List of security schemes.
        /// </summary>
        public SecurityScheme[] IssueSecuritySchemes { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SelectTimeTrackingImplementationResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about the Jira instance.
    /// </summary>
    public class ServerInformation
    {
        /// <summary>
        /// The base URL of the Jira instance.
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// The version of Jira.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The major, minor, and revision version numbers of the Jira version.
        /// </summary>
        public int[] VersionNumbers { get; set; }

        /// <summary>
        /// The type of server deployment. This is always returned as *Cloud*.
        /// </summary>
        public string DeploymentType { get; set; }

        /// <summary>
        /// The build number of the Jira version.
        /// </summary>
        public int BuildNumber { get; set; }

        /// <summary>
        /// The timestamp when the Jira version was built.
        /// </summary>
        public DateTime BuildDate { get; set; }

        /// <summary>
        /// The time in Jira when this request was responded to.
        /// </summary>
        public DateTime ServerTime { get; set; }

        /// <summary>
        /// The unique identifier of the Jira version.
        /// </summary>
        public string ScmInfo { get; set; }

        /// <summary>
        /// The name of the Jira instance.
        /// </summary>
        public string ServerTitle { get; set; }

        /// <summary>
        /// Jira instance health check results. Deprecated and no longer returned.
        /// </summary>
        public HealthCheckResult[] HealthChecks { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Set
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SetColumnsResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SetCommentPropertyResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SetDashboardItemPropertyResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SetDefaultValuesResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SetFieldConfigurationSchemeMappingResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SetIssueNavigatorDefaultColumnsResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SetIssuePropertyResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SetIssueTypePropertyResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SetLocaleResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SetPreferenceResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SetProjectPropertyResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SetUserColumnsResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SetUserPropertyResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SetWorklogPropertyResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SharedUsers : UserList
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a share permission for the filter.
    /// </summary>
    public class SharePermission
    {
        /// <summary>
        /// The unique identifier of the share permission.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The type of share permission: *  `user` Shared with a user. *  `group` Shared with a group. If set in a request, then specify `sharePermission.group` as well. *  `project` Shared with a project. If set in a request, then specify `sharePermission.project` as well. *  `projectRole` Share with a project role in a project. This value is not returned in responses. It is used in requests, where it needs to be specify with `projectId` and `projectRoleId`. *  `global` Shared globally. If set in a request, no other `sharePermission` properties need to be specified. *  `loggedin` Shared with all logged-in users. Note: This value is set in a request by specifying `authenticated` as the `type`. *  `project-unknown` Shared with a project that the user does not have access to. Cannot be set in a request.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Details of a share permission for the filter.
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// Details of a share permission for the filter.
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Details of a share permission for the filter.
        /// </summary>
        public Group Group { get; set; }

        /// <summary>
        /// Details of a share permission for the filter.
        /// </summary>
        public User User { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SharePermissionInputBean
    {
        /// <summary>
        /// The type of the share permission.Specify the type as follows: *  `user` Share with a user. *  `group` Share with a group. Specify `groupname` as well. *  `project` Share with a project. Specify `projectId` as well. *  `projectRole` Share with a project role in a project. Specify `projectId` and `projectRoleId` as well. *  `global` Share globally, including anonymous users. If set, this type overrides all existing share permissions and must be deleted before any non-global share permissions is set. *  `authenticated` Share with all logged-in users. This shows as `loggedin` in the response. If set, this type overrides all existing share permissions and must be deleted before any non-global share permissions is set.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The ID of the project to share the filter with. Set `type` to `project`.
        /// </summary>
        public string ProjectId { get; set; }

        /// <summary>
        /// The name of the group to share the filter with. Set `type` to `group`.
        /// </summary>
        public string Groupname { get; set; }

        /// <summary>
        /// The ID of the project role to share the filter with. Set `type` to `projectRole` and the `projectId` for the project that the role is in.
        /// </summary>
        public string ProjectRoleId { get; set; }

        /// <summary>
        /// The user account ID that the filter is shared with. For a request, specify the `accountId` property for the user.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// The rights for the share permission.
        /// </summary>
        public int Rights { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SimpleApplicationPropertyBean
    {
        /// <summary>
        /// The ID of the application property.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The new value.
        /// </summary>
        public string Value { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SimpleErrorCollection
    {
        public Errors Errors { get; set; }

        /// <summary>
        /// The list of error messages produced by this operation. For example, "input parameter 'key' must be provided"
        /// </summary>
        public string[] ErrorMessages { get; set; }

        public int HttpStatusCode { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about the operations available in this version.
    /// </summary>
    public class SimpleLink
    {
        public string Id { get; set; }

        public string StyleClass { get; set; }

        public string IconClass { get; set; }

        public string Label { get; set; }

        public string Title { get; set; }

        public string Href { get; set; }

        public int Weight { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SimpleListWrapperApplicationRole
    {
        public int Size { get; set; }

        public ApplicationRole[] Items { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public ListWrapperCallbackApplicationRole PagingCallback { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public ListWrapperCallbackApplicationRole Callback { get; set; }

        public int MaxResults { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class SimpleListWrapperGroupName
    {
        public int Size { get; set; }

        public GroupName[] Items { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public ListWrapperCallbackGroupName PagingCallback { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public ListWrapperCallbackGroupName Callback { get; set; }

        public int MaxResults { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The status of the item.
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Whether the item is resolved. If set to "true", the link to the issue is displayed in a strikethrough font, otherwise the link displays in normal font.
        /// </summary>
        public bool Resolved { get; set; }

        /// <summary>
        /// The status of the item.
        /// </summary>
        public Icon Icon { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A status category.
    /// </summary>
    public class StatusCategory
    {
        /// <summary>
        /// The URL of the status category.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID of the status category.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The key of the status category.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The name of the color used to represent the status category.
        /// </summary>
        public string ColorName { get; set; }

        /// <summary>
        /// The name of the status category.
        /// </summary>
        public string Name { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A status.
    /// </summary>
    public class StatusDetails
    {
        /// <summary>
        /// The URL of the status.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The description of the status.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The URL of the icon used to represent the status.
        /// </summary>
        public string IconUrl { get; set; }

        /// <summary>
        /// The name of the status.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The ID of the status.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A status.
        /// </summary>
        public StatusCategory StatusCategory { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about the mapping from a status to a new status for an issue type.
    /// </summary>
    public class StatusMapping
    {
        /// <summary>
        /// The ID of the issue type.
        /// </summary>
        public string IssueTypeId { get; set; }

        /// <summary>
        /// The ID of the status.
        /// </summary>
        public string StatusId { get; set; }

        /// <summary>
        /// The ID of the new status.
        /// </summary>
        public string NewStatusId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Steps : JiraExpressionsComplexityValueBean
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class StringList
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Structure : JqlQuery
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Subscriptions : FilterSubscriptionsList
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// An issue suggested for use in the issue picker auto-completion.
    /// </summary>
    public class SuggestedIssue
    {
        /// <summary>
        /// The ID of the issue.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The key of the issue.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The key of the issue in HTML format.
        /// </summary>
        public string KeyHtml { get; set; }

        /// <summary>
        /// The URL of the issue type's avatar.
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        /// The phrase containing the query string in HTML format, with the string highlighted with HTML bold tags.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// The phrase containing the query string, as plain text.
        /// </summary>
        public string SummaryText { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// List of system avatars.
    /// </summary>
    public class SystemAvatars
    {
        /// <summary>
        /// A list of avatar details.
        /// </summary>
        public Avatar[] System { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Tab : ScreenableTab
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a task.
    /// </summary>
    public class TaskProgressBeanObject
    {
        /// <summary>
        /// The URL of the task.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID of the task.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The description of the task.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The status of the task.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Information about the progress of the task.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Details about a task.
        /// </summary>
        public Result Result { get; set; }

        /// <summary>
        /// The ID of the user who submitted the task.
        /// </summary>
        public long SubmittedBy { get; set; }

        /// <summary>
        /// The progress of the task, as a percentage complete.
        /// </summary>
        public long Progress { get; set; }

        /// <summary>
        /// The execution time of the task, in milliseconds.
        /// </summary>
        public long ElapsedRuntime { get; set; }

        /// <summary>
        /// A timestamp recording when the task was submitted.
        /// </summary>
        public long Submitted { get; set; }

        /// <summary>
        /// A timestamp recording when the task was started.
        /// </summary>
        public long Started { get; set; }

        /// <summary>
        /// A timestamp recording when the task was finished.
        /// </summary>
        public long Finished { get; set; }

        /// <summary>
        /// A timestamp recording when the task progress was last updated.
        /// </summary>
        public long LastUpdate { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a task.
    /// </summary>
    public class TaskProgressBeanRemoveOptionFromIssuesResult
    {
        /// <summary>
        /// The URL of the task.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID of the task.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The description of the task.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The status of the task.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Information about the progress of the task.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Details about a task.
        /// </summary>
        public Result Result { get; set; }

        /// <summary>
        /// The ID of the user who submitted the task.
        /// </summary>
        public long SubmittedBy { get; set; }

        /// <summary>
        /// The progress of the task, as a percentage complete.
        /// </summary>
        public long Progress { get; set; }

        /// <summary>
        /// The execution time of the task, in milliseconds.
        /// </summary>
        public long ElapsedRuntime { get; set; }

        /// <summary>
        /// A timestamp recording when the task was submitted.
        /// </summary>
        public long Submitted { get; set; }

        /// <summary>
        /// A timestamp recording when the task was started.
        /// </summary>
        public long Started { get; set; }

        /// <summary>
        /// A timestamp recording when the task was finished.
        /// </summary>
        public long Finished { get; set; }

        /// <summary>
        /// A timestamp recording when the task progress was last updated.
        /// </summary>
        public long LastUpdate { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class TemplateEvent : NotificationEvent
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Timetracking : TimeTrackingDetails
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the time tracking configuration.
    /// </summary>
    public class TimeTrackingConfiguration
    {
        /// <summary>
        /// The number of hours in a working day.
        /// </summary>
        public double WorkingHoursPerDay { get; set; }

        /// <summary>
        /// The number of days in a working week.
        /// </summary>
        public double WorkingDaysPerWeek { get; set; }

        /// <summary>
        /// The format that will appear on an issue's *Time Spent* field.
        /// </summary>
        public string TimeFormat { get; set; }

        /// <summary>
        /// The default unit of time applied to logged time.
        /// </summary>
        public string DefaultUnit { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Time tracking details.
    /// </summary>
    public class TimeTrackingDetails
    {
        /// <summary>
        /// The original estimate of time needed for this issue in readable format.
        /// </summary>
        public string OriginalEstimate { get; set; }

        /// <summary>
        /// The remaining estimate of time needed for this issue in readable format.
        /// </summary>
        public string RemainingEstimate { get; set; }

        /// <summary>
        /// Time worked on this issue in readable format.
        /// </summary>
        public string TimeSpent { get; set; }

        /// <summary>
        /// The original estimate of time needed for this issue in seconds.
        /// </summary>
        public long OriginalEstimateSeconds { get; set; }

        /// <summary>
        /// The remaining estimate of time needed for this issue in seconds.
        /// </summary>
        public long RemainingEstimateSeconds { get; set; }

        /// <summary>
        /// Time worked on this issue in seconds.
        /// </summary>
        public long TimeSpentSeconds { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about the time tracking provider.
    /// </summary>
    public class TimeTrackingProvider
    {
        /// <summary>
        /// The key for the time tracking provider. For example, *JIRA*.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The name of the time tracking provider. For example, *JIRA provided time tracking*.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The URL of the configuration page for the time tracking provider app. For example, */example/config/url*. This property is only returned if the `adminPageKey` property is set in the module descriptor of the time tracking provider app.
        /// </summary>
        public string Url { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class To : StatusDetails
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a workflow transition.
    /// </summary>
    public class Transition
    {
        /// <summary>
        /// The ID of the transition.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the transition.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the transition.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The statuses the transition can start from.
        /// </summary>
        public string[] From { get; set; }

        /// <summary>
        /// The status the transition goes to.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// The type of the transition.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public TransitionScreenDetails Screen { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public WorkflowRules Rules { get; set; }

        /// <summary>
        /// Details of a workflow transition.
        /// </summary>
        public Properties Properties { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// List of issue transitions.
    /// </summary>
    public class Transitions
    {
        /// <summary>
        /// Expand options that include additional transitions details in the response.
        /// </summary>
        public string Expand { get; set; }

        /// <summary>
        /// List of issue transitions.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Transitions")]
        public IssueTransition[] Transitions_ { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The details of a transition screen.
    /// </summary>
    public class TransitionScreenDetails
    {
        /// <summary>
        /// The ID of the screen.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the screen.
        /// </summary>
        public string Name { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class TrashCustomFieldResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Type : IssueLinkType
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UnrestrictedUserEmail
    {
        /// <summary>
        /// The accountId of the user
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Update
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UpdateAuthor : UserDetails
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UpdateCustomFieldConfigurationResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UpdateCustomFieldContextResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a custom field.
    /// </summary>
    public class UpdateCustomFieldDetails
    {
        /// <summary>
        /// The name of the custom field. It doesn't have to be unique. The maximum length is 255 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the custom field. The maximum length is 40000 characters.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The searcher that defines the way the field is searched in Jira. It can be set to `null`, otherwise you must specify the valid searcher for the field type, as listed below (abbreviated values shown): *  `cascadingselect`: `cascadingselectsearcher` *  `datepicker`: `daterange` *  `datetime`: `datetimerange` *  `float`: `exactnumber` or `numberrange` *  `grouppicker`: `grouppickersearcher` *  `importid`: `exactnumber` or `numberrange` *  `labels`: `labelsearcher` *  `multicheckboxes`: `multiselectsearcher` *  `multigrouppicker`: `multiselectsearcher` *  `multiselect`: `multiselectsearcher` *  `multiuserpicker`: `userpickergroupsearcher` *  `multiversion`: `versionsearcher` *  `project`: `projectsearcher` *  `radiobuttons`: `multiselectsearcher` *  `readonlyfield`: `textsearcher` *  `select`: `multiselectsearcher` *  `textarea`: `textsearcher` *  `textfield`: `textsearcher` *  `url`: `exacttextsearcher` *  `userpicker`: `userpickergroupsearcher` *  `version`: `versionsearcher`
        /// </summary>
        public string SearcherKey { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UpdateCustomFieldResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UpdateCustomFieldValueResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The ID of a screen scheme.
    /// </summary>
    public class UpdateDefaultScreenScheme
    {
        /// <summary>
        /// The ID of the screen scheme.
        /// </summary>
        public string ScreenSchemeId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UpdateDefaultScreenSchemeResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A project category.
    /// </summary>
    public class UpdatedProjectCategory
    {
        /// <summary>
        /// The URL of the project category.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID of the project category.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the project category.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The description of the project category.
        /// </summary>
        public string Name { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UpdateFieldConfigurationItemsResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UpdateFieldConfigurationResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The details of the field configuration scheme.
    /// </summary>
    public class UpdateFieldConfigurationSchemeDetails
    {
        /// <summary>
        /// The name of the field configuration scheme. The name must be unique.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the field configuration scheme.
        /// </summary>
        public string Description { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UpdateFieldConfigurationSchemeResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UpdateIssueTypeSchemeResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UpdateIssueTypeScreenSchemeResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UpdateMultipleCustomFieldValuesResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UpdateProjectAvatarResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about the project.
    /// </summary>
    public class UpdateProjectDetails
    {
        /// <summary>
        /// Project keys must be unique and start with an uppercase letter followed by one or more uppercase alphanumeric characters. The maximum length is 10 characters.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The name of the project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A brief description of the project.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// This parameter is deprecated because of privacy changes. Use `leadAccountId` instead. See the [migration guide](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details. The user name of the project lead. Cannot be provided with `leadAccountId`.
        /// </summary>
        public string Lead { get; set; }

        /// <summary>
        /// The account ID of the project lead. Cannot be provided with `lead`.
        /// </summary>
        public string LeadAccountId { get; set; }

        /// <summary>
        /// A link to information about this project, such as project documentation
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The default assignee when creating issues for this project.
        /// </summary>
        public string AssigneeType { get; set; }

        /// <summary>
        /// An integer value for the project's avatar.
        /// </summary>
        public long AvatarId { get; set; }

        /// <summary>
        /// The ID of the issue security scheme for the project, which enables you to control who can and cannot view issues. Use the [Get issue security schemes](#api-rest-api-3-issuesecurityschemes-get) resource to get all issue security scheme IDs.
        /// </summary>
        public long IssueSecurityScheme { get; set; }

        /// <summary>
        /// The ID of the permission scheme for the project. Use the [Get all permission schemes](#api-rest-api-3-permissionscheme-get) resource to see a list of all permission scheme IDs.
        /// </summary>
        public long PermissionScheme { get; set; }

        /// <summary>
        /// The ID of the notification scheme for the project. Use the [Get notification schemes](#api-rest-api-3-notificationscheme-get) resource to get a list of notification scheme IDs.
        /// </summary>
        public long NotificationScheme { get; set; }

        /// <summary>
        /// The ID of the project's category. A complete list of category IDs is found using the [Get all project categories](#api-rest-api-3-projectCategory-get) operation. To remove the project category from the project, set the value to `-1.`
        /// </summary>
        public long CategoryId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UpdateProjectEmailResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UpdateRemoteIssueLinkResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a screen.
    /// </summary>
    public class UpdateScreenDetails
    {
        /// <summary>
        /// The name of the screen. The name must be unique. The maximum length is 255 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the screen. The maximum length is 255 characters.
        /// </summary>
        public string Description { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a screen scheme.
    /// </summary>
    public class UpdateScreenSchemeDetails
    {
        /// <summary>
        /// The name of the screen scheme. The name must be unique. The maximum length is 255 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the screen scheme. The maximum length is 255 characters.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Details of a screen scheme.
        /// </summary>
        public Screens Screens { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UpdateScreenSchemeResult
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The IDs of the screens for the screen types of the screen scheme.
    /// </summary>
    public class UpdateScreenTypes
    {
        /// <summary>
        /// The ID of the edit screen. To remove the screen association, pass a null.
        /// </summary>
        public string Edit { get; set; }

        /// <summary>
        /// The ID of the create screen. To remove the screen association, pass a null.
        /// </summary>
        public string Create { get; set; }

        /// <summary>
        /// The ID of the view screen. To remove the screen association, pass a null.
        /// </summary>
        public string View { get; set; }

        /// <summary>
        /// The ID of the default screen. When specified, must include a screen ID as a default screen is required.
        /// </summary>
        public string Default { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UpdateUserToGroupBean
    {
        /// <summary>
        /// This property is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.
        /// </summary>
        public string AccountId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Urls
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A user with details as permitted by the user's Atlassian Account privacy settings. However, be aware of these exceptions: *  User record deleted from Atlassian: This occurs as the result of a right to be forgotten request. In this case, `displayName` provides an indication and other parameters have default values or are blank (for example, email is blank). *  User record corrupted: This occurs as a results of events such as a server import and can only happen to deleted users. In this case, `accountId` returns *unknown* and all other parameters have fallback values. *  User record unavailable: This usually occurs due to an internal service outage. In this case, all parameters have fallback values.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The URL of the user.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// This property is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*. Required in requests.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// The user account type. Can take the following values: *  `atlassian` regular Atlassian user account *  `app` system account used for Connect applications and OAuth to represent external systems *  `customer` Jira Service Desk account representing an external service desk
        /// </summary>
        public string AccountType { get; set; }

        /// <summary>
        /// This property is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The email address of the user. Depending on the user’s privacy setting, this may be returned as null.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// A user with details as permitted by the user's Atlassian Account privacy settings. However, be aware of these exceptions: *  User record deleted from Atlassian: This occurs as the result of a right to be forgotten request. In this case, `displayName` provides an indication and other parameters have default values or are blank (for example, email is blank). *  User record corrupted: This occurs as a results of events such as a server import and can only happen to deleted users. In this case, `accountId` returns *unknown* and all other parameters have fallback values. *  User record unavailable: This usually occurs due to an internal service outage. In this case, all parameters have fallback values.
        /// </summary>
        public AvatarUrls AvatarUrls { get; set; }

        /// <summary>
        /// The display name of the user. Depending on the user’s privacy setting, this may return an alternative value.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Whether the user is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// The time zone specified in the user's profile. Depending on the user’s privacy setting, this may be returned as null.
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// The locale of the user. Depending on the user’s privacy setting, this may be returned as null.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// A user with details as permitted by the user's Atlassian Account privacy settings. However, be aware of these exceptions: *  User record deleted from Atlassian: This occurs as the result of a right to be forgotten request. In this case, `displayName` provides an indication and other parameters have default values or are blank (for example, email is blank). *  User record corrupted: This occurs as a results of events such as a server import and can only happen to deleted users. In this case, `accountId` returns *unknown* and all other parameters have fallback values. *  User record unavailable: This usually occurs due to an internal service outage. In this case, all parameters have fallback values.
        /// </summary>
        public Groups Groups { get; set; }

        /// <summary>
        /// A user with details as permitted by the user's Atlassian Account privacy settings. However, be aware of these exceptions: *  User record deleted from Atlassian: This occurs as the result of a right to be forgotten request. In this case, `displayName` provides an indication and other parameters have default values or are blank (for example, email is blank). *  User record corrupted: This occurs as a results of events such as a server import and can only happen to deleted users. In this case, `accountId` returns *unknown* and all other parameters have fallback values. *  User record unavailable: This usually occurs due to an internal service outage. In this case, all parameters have fallback values.
        /// </summary>
        public ApplicationRoles ApplicationRoles { get; set; }

        /// <summary>
        /// Expand options that include additional user details in the response.
        /// </summary>
        public string Expand { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UserBean
    {
        /// <summary>
        /// This property is deprecated in favor of `accountId` because of privacy changes. See the [migration guide](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.  The key of the user.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The URL of the user.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// This property is deprecated in favor of `accountId` because of privacy changes. See the [migration guide](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.  The username of the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The display name of the user. Depending on the user’s privacy setting, this may return an alternative value.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Whether the user is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.
        /// </summary>
        public string AccountId { get; set; }

        public AvatarUrls AvatarUrls { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UserBeanAvatarUrls
    {
        /// <summary>
        /// The URL of the user's 16x16 pixel avatar.
        /// </summary>
        public string 16x16 { get; set; }

        /// <summary>
        /// The URL of the user's 32x32 pixel avatar.
        /// </summary>
        public string 32x32 { get; set; }

        /// <summary>
        /// The URL of the user's 48x48 pixel avatar.
        /// </summary>
        public string 48x48 { get; set; }

        /// <summary>
        /// The URL of the user's 24x24 pixel avatar.
        /// </summary>
        public string 24x24 { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A [user](https://developer.atlassian.com/cloud/jira/platform/jira-expressions-type-reference#user) specified as an Atlassian account ID.
    /// </summary>
    public class UserContextVariable
    {
        /// <summary>
        /// Type of custom context variable.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The account ID of the user.
        /// </summary>
        public string AccountId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// User details permitted by the user's Atlassian Account privacy settings. However, be aware of these exceptions: *  User record deleted from Atlassian: This occurs as the result of a right to be forgotten request. In this case, `displayName` provides an indication and other parameters have default values or are blank (for example, email is blank). *  User record corrupted: This occurs as a results of events such as a server import and can only happen to deleted users. In this case, `accountId` returns *unknown* and all other parameters have fallback values. *  User record unavailable: This usually occurs due to an internal service outage. In this case, all parameters have fallback values.
    /// </summary>
    public class UserDetails
    {
        /// <summary>
        /// The URL of the user.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// This property is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This property is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// The email address of the user. Depending on the user’s privacy settings, this may be returned as null.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// User details permitted by the user's Atlassian Account privacy settings. However, be aware of these exceptions: *  User record deleted from Atlassian: This occurs as the result of a right to be forgotten request. In this case, `displayName` provides an indication and other parameters have default values or are blank (for example, email is blank). *  User record corrupted: This occurs as a results of events such as a server import and can only happen to deleted users. In this case, `accountId` returns *unknown* and all other parameters have fallback values. *  User record unavailable: This usually occurs due to an internal service outage. In this case, all parameters have fallback values.
        /// </summary>
        public AvatarUrls AvatarUrls { get; set; }

        /// <summary>
        /// The display name of the user. Depending on the user’s privacy settings, this may return an alternative value.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Whether the user is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// The time zone specified in the user's profile. Depending on the user’s privacy settings, this may be returned as null.
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// The type of account represented by this user. This will be one of 'atlassian' (normal users), 'app' (application user) or 'customer' (Jira Service Desk customer user)
        /// </summary>
        public string AccountType { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Filter for a User Picker (single) custom field.
    /// </summary>
    public class UserFilter
    {
        /// <summary>
        /// Whether the filter is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// User groups autocomplete suggestion users must belong to. If not provided, the default values are used. A maximum of 10 groups can be provided.
        /// </summary>
        public string[] Groups { get; set; }

        /// <summary>
        /// Roles that autocomplete suggestion users must belong to. If not provided, the default values are used. A maximum of 10 roles can be provided.
        /// </summary>
        public long[] RoleIds { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// List of user account IDs.
    /// </summary>
    public class UserKey
    {
        /// <summary>
        /// This property is no longer available and will be removed from the documentation soon. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*. Returns *unknown* if the record is deleted and corrupted, for example, as the result of a server import.
        /// </summary>
        public string AccountId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A paginated list of users sharing the filter. This includes users that are members of the groups or can browse the projects that the filter is shared with.
    /// </summary>
    public class UserList
    {
        /// <summary>
        /// The number of items on the page.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// The list of items.
        /// </summary>
        public User[] Items { get; set; }

        /// <summary>
        /// The maximum number of results that could be on the page.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// The index of the first item returned on the page.
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// The index of the last item returned on the page.
        /// </summary>
        public int EndIndex { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class UserMigrationBean
    {
        public string Key { get; set; }

        public string Username { get; set; }

        public string AccountId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a permission and its availability to a user.
    /// </summary>
    public class UserPermission
    {
        /// <summary>
        /// The ID of the permission. Either `id` or `key` must be specified. Use [Get all permissions](#api-rest-api-3-permissions-get) to get the list of permissions.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The key of the permission. Either `id` or `key` must be specified. Use [Get all permissions](#api-rest-api-3-permissions-get) to get the list of permissions.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The name of the permission.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of the permission.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The description of the permission.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Whether the permission is available to the user in the queried context.
        /// </summary>
        public bool HavePermission { get; set; }

        /// <summary>
        /// Indicate whether the permission key is deprecated. Note that deprecated keys cannot be used in the `permissions parameter of Get my permissions. Deprecated keys are not returned by Get all permissions.`
        /// </summary>
        public bool DeprecatedKey { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A user found in a search.
    /// </summary>
    public class UserPickerUser
    {
        /// <summary>
        /// The account ID of the user, which uniquely identifies the user across all Atlassian products. For example, *5b10ac8d82e05b22cc7d4ef5*.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// This property is no longer available . See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This property is no longer available. See the [deprecation notice](https://developer.atlassian.com/cloud/jira/platform/deprecation-notice-user-privacy-api-migration-guide/) for details.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The display name, email address, and key of the user with the matched query string highlighted with the HTML bold tag.
        /// </summary>
        public string Html { get; set; }

        /// <summary>
        /// The display name of the user. Depending on the user’s privacy setting, this may be returned as null.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The avatar URL of the user.
        /// </summary>
        public string AvatarUrl { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Users : PagedListUserDetailsApplicationUser
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Value
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// An operand that is a user-provided value.
    /// </summary>
    public class ValueOperand
    {
        /// <summary>
        /// The operand value.
        /// </summary>
        public string Value { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class Variables
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a project version.
    /// </summary>
    public class Version
    {
        /// <summary>
        /// Use [expand](em>#expansion) to include additional information about version in the response. This parameter accepts a comma-separated list. Expand options include: *  `operations` Returns the list of operations available for this version. *  `issuesstatus` Returns the count of issues in this version for each of the status categories *to do*, *in progress*, *done*, and *unmapped*. The *unmapped* property contains a count of issues with a status other than *to do*, *in progress*, and *done*.Optional for create and update.
        /// </summary>
        public string Expand { get; set; }

        /// <summary>
        /// The URL of the version.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The ID of the version.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The description of the version. Optional when creating or updating a version.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The unique name of the version. Required when creating a version. Optional when updating a version. The maximum length is 255 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates that the version is archived. Optional when creating or updating a version.
        /// </summary>
        public bool Archived { get; set; }

        /// <summary>
        /// Indicates that the version is released. If the version is released a request to release again is ignored. Not applicable when creating a version. Optional when updating a version.
        /// </summary>
        public bool Released { get; set; }

        /// <summary>
        /// The start date of the version. Expressed in ISO 8601 format (yyyy-mm-dd). Optional when creating or updating a version.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The release date of the version. Expressed in ISO 8601 format (yyyy-mm-dd). Optional when creating or updating a version.
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Indicates that the version is overdue.
        /// </summary>
        public bool Overdue { get; set; }

        /// <summary>
        /// The date on which work on this version is expected to start, expressed in the instance's *Day/Month/Year Format* date format.
        /// </summary>
        public string UserStartDate { get; set; }

        /// <summary>
        /// The date on which work on this version is expected to finish, expressed in the instance's *Day/Month/Year Format* date format.
        /// </summary>
        public string UserReleaseDate { get; set; }

        /// <summary>
        /// Deprecated. Use `projectId`.
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// The ID of the project to which this version is attached. Required when creating a version. Not applicable when updating a version.
        /// </summary>
        public long ProjectId { get; set; }

        /// <summary>
        /// The URL of the self link to the version to which all unfixed issues are moved when a version is released. Not applicable when creating a version. Optional when updating a version.
        /// </summary>
        public string MoveUnfixedIssuesTo { get; set; }

        /// <summary>
        /// If the expand option `operations` is used, returns the list of operations available for this version.
        /// </summary>
        public SimpleLink[] Operations { get; set; }

        /// <summary>
        /// Details about a project version.
        /// </summary>
        public IssuesStatusForFixVersion IssuesStatusForFixVersion { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class VersionedRepresentations
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Various counts of issues within a version.
    /// </summary>
    public class VersionIssueCounts
    {
        /// <summary>
        /// The URL of these count details.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// Count of issues where the `fixVersion` is set to the version.
        /// </summary>
        public long IssuesFixedCount { get; set; }

        /// <summary>
        /// Count of issues where the `affectedVersion` is set to the version.
        /// </summary>
        public long IssuesAffectedCount { get; set; }

        /// <summary>
        /// Count of issues where a version custom field is set to the version.
        /// </summary>
        public long IssueCountWithCustomFieldsShowingVersion { get; set; }

        /// <summary>
        /// List of custom fields using the version.
        /// </summary>
        public VersionUsageInCustomField[] CustomFieldUsage { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Counts of the number of issues in various statuses.
    /// </summary>
    public class VersionIssuesStatus
    {
        /// <summary>
        /// Count of issues with a status other than *to do*, *in progress*, and *done*.
        /// </summary>
        public long Unmapped { get; set; }

        /// <summary>
        /// Count of issues with status *to do*.
        /// </summary>
        public long ToDo { get; set; }

        /// <summary>
        /// Count of issues with status *in progress*.
        /// </summary>
        public long InProgress { get; set; }

        /// <summary>
        /// Count of issues with status *done*.
        /// </summary>
        public long Done { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class VersionMoveBean
    {
        /// <summary>
        /// The URL (self link) of the version after which to place the moved version. Cannot be used with `position`.
        /// </summary>
        public string After { get; set; }

        /// <summary>
        /// An absolute position in which to place the moved version. Cannot be used with `after`.
        /// </summary>
        public string Position { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Count of a version's unresolved issues.
    /// </summary>
    public class VersionUnresolvedIssuesCount
    {
        /// <summary>
        /// The URL of these count details.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// Count of unresolved issues.
        /// </summary>
        public long IssuesUnresolvedCount { get; set; }

        /// <summary>
        /// Count of issues.
        /// </summary>
        public long IssuesCount { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// List of custom fields using the version.
    /// </summary>
    public class VersionUsageInCustomField
    {
        /// <summary>
        /// The name of the custom field.
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// The ID of the custom field.
        /// </summary>
        public long CustomFieldId { get; set; }

        /// <summary>
        /// Count of the issues where the custom field contains the version.
        /// </summary>
        public long IssueCountWithVersionInCustomField { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The group or role to which this item is visible.
    /// </summary>
    public class Visibility
    {
        /// <summary>
        /// Whether visibility of this item is restricted to a group or role.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The name of the group or role to which visibility of this item is restricted.
        /// </summary>
        public string Value { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The details of votes on an issue.
    /// </summary>
    public class Votes
    {
        /// <summary>
        /// The URL of these issue vote details.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The number of votes on the issue.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Votes")]
        public long Votes_ { get; set; }

        /// <summary>
        /// Whether the user making this request has voted on the issue.
        /// </summary>
        public bool HasVoted { get; set; }

        /// <summary>
        /// List of the users who have voted on this issue. An empty list is returned when the calling user doesn't have the *View voters and watchers* project permission.
        /// </summary>
        public User[] Voters { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The details of watchers on an issue.
    /// </summary>
    public class Watchers
    {
        /// <summary>
        /// The URL of these issue watcher details.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// Whether the calling user is watching this issue.
        /// </summary>
        public bool IsWatching { get; set; }

        /// <summary>
        /// The number of users watching this issue.
        /// </summary>
        public int WatchCount { get; set; }

        /// <summary>
        /// Details of the users watching this issue.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("Watchers")]
        public UserDetails[] Watchers_ { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A webhook.
    /// </summary>
    public class Webhook
    {
        /// <summary>
        /// The ID of the webhook.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The JQL filter that specifies which issues the webhook is sent for.
        /// </summary>
        public string JqlFilter { get; set; }

        /// <summary>
        /// A list of field IDs. When the issue changelog contains any of the fields, the webhook `jira:issue_updated` is sent. If this parameter is not present, the app is notified about all field updates.
        /// </summary>
        public string[] FieldIdsFilter { get; set; }

        /// <summary>
        /// A list of issue property keys. A change of those issue properties triggers the `issue_property_set` or `issue_property_deleted` webhooks. If this parameter is not present, the app is notified about all issue property updates.
        /// </summary>
        public string[] IssuePropertyKeysFilter { get; set; }

        /// <summary>
        /// The Jira events that trigger the webhook.
        /// </summary>
        public string[] Events { get; set; }

        /// <summary>
        /// The date after which the webhook will stop being sent. Use the "Extend webhook life" resource to extend it.
        /// </summary>
        public long ExpirationDate { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A list of webhooks.
    /// </summary>
    public class WebhookDetails
    {
        /// <summary>
        /// The JQL filter that specifies which issues the webhook is sent for. Only a subset of JQL can be used. The supported elements are: *  Fields: `issueKey`, `project`, `issuetype`, `status`, `assignee`, `reporter`, `issue.property`, and `cf[id]`. For custom fields (`cf[id]`), only the epic label custom field is supported.". *  Operators: `=`, `!=`, `IN`, and `NOT IN`.
        /// </summary>
        public string JqlFilter { get; set; }

        /// <summary>
        /// A list of field IDs. When the issue changelog contains any of the fields, the webhook `jira:issue_updated` is sent. If this parameter is not present, the app is notified about all field updates.
        /// </summary>
        public string[] FieldIdsFilter { get; set; }

        /// <summary>
        /// A list of issue property keys. A change of those issue properties triggers the `issue_property_set` or `issue_property_deleted` webhooks. If this parameter is not present, the app is notified about all issue property updates.
        /// </summary>
        public string[] IssuePropertyKeysFilter { get; set; }

        /// <summary>
        /// The Jira events that trigger the webhook.
        /// </summary>
        public string[] Events { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of webhooks to register.
    /// </summary>
    public class WebhookRegistrationDetails
    {
        /// <summary>
        /// A list of webhooks.
        /// </summary>
        public WebhookDetails[] Webhooks { get; set; }

        /// <summary>
        /// The URL that specifies where to send the webhooks. This URL must use the same base URL as the Connect app.
        /// </summary>
        public string Url { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The date the newly refreshed webhooks expire.
    /// </summary>
    public class WebhooksExpirationDate
    {
        /// <summary>
        /// The new expiration date of all refreshed webhooks: 30 days from now.
        /// </summary>
        public long ExpirationDate { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a workflow.
    /// </summary>
    public class Workflow
    {
        /// <summary>
        /// not-used
        /// </summary>
        public PublishedWorkflowId Id { get; set; }

        /// <summary>
        /// The description of the workflow.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The transitions of the workflow.
        /// </summary>
        public Transition[] Transitions { get; set; }

        /// <summary>
        /// The statuses of the workflow.
        /// </summary>
        public WorkflowStatus[] Statuses { get; set; }

        /// <summary>
        /// Whether this is the default workflow.
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// The workflow schemes the workflow is assigned to.
        /// </summary>
        public WorkflowSchemeIdName[] Schemes { get; set; }

        /// <summary>
        /// The projects the workflow is assigned to, through workflow schemes.
        /// </summary>
        public ProjectDetails[] Projects { get; set; }

        /// <summary>
        /// Whether the workflow has a draft version.
        /// </summary>
        public bool HasDraftWorkflow { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public WorkflowOperations Operations { get; set; }

        /// <summary>
        /// The creation date of the workflow.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The last edited date of the workflow.
        /// </summary>
        public DateTime Updated { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A compound workflow transition rule condition. This object returns `nodeType` as `compound`.
    /// </summary>
    public class WorkflowCompoundCondition
    {
        /// <summary>
        /// The compound condition operator.
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// The list of workflow conditions.
        /// </summary>
        public WorkflowCondition[] Conditions { get; set; }

        public string NodeType { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The workflow transition rule conditions tree.
    /// </summary>
    public class WorkflowCondition
    {
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Properties that identify a workflow.
    /// </summary>
    public class WorkflowId
    {
        /// <summary>
        /// The name of the workflow.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether the workflow is in the draft state.
        /// </summary>
        public bool Draft { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The classic workflow identifiers.
    /// </summary>
    public class WorkflowIDs
    {
        /// <summary>
        /// The name of the workflow.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The entity ID of the workflow.
        /// </summary>
        public string EntityId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Operations allowed on a workflow
    /// </summary>
    public class WorkflowOperations
    {
        /// <summary>
        /// Whether the workflow can be updated.
        /// </summary>
        public bool CanEdit { get; set; }

        /// <summary>
        /// Whether the workflow can be deleted.
        /// </summary>
        public bool CanDelete { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A collection of transition rules.
    /// </summary>
    public class WorkflowRules
    {
        /// <summary>
        /// The workflow conditions. ([Deprecated](https://community.developer.atlassian.com/t/deprecation-of-conditions-body-param/48884))
        /// </summary>
        public WorkflowTransitionRule[] Conditions { get; set; }

        /// <summary>
        /// not-used
        /// </summary>
        public WorkflowCondition ConditionsTree { get; set; }

        /// <summary>
        /// The workflow validators.
        /// </summary>
        public WorkflowTransitionRule[] Validators { get; set; }

        /// <summary>
        /// The workflow post functions.
        /// </summary>
        public WorkflowTransitionRule[] PostFunctions { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of the workflow and its transition rules.
    /// </summary>
    public class WorkflowRulesSearch
    {
        /// <summary>
        /// The workflow ID.
        /// </summary>
        public string WorkflowEntityId { get; set; }

        /// <summary>
        /// The list of workflow rule IDs.
        /// </summary>
        public string[] RuleIds { get; set; }

        /// <summary>
        /// Use expand to include additional information in the response. This parameter accepts `transition` which, for each rule, returns information about the transition the rule is assigned to.
        /// </summary>
        public string Expand { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of workflow transition rules.
    /// </summary>
    public class WorkflowRulesSearchDetails
    {
        /// <summary>
        /// The workflow ID.
        /// </summary>
        public string WorkflowEntityId { get; set; }

        /// <summary>
        /// List of workflow rule IDs that do not belong to the workflow or can not be found.
        /// </summary>
        public string[] InvalidRules { get; set; }

        /// <summary>
        /// List of valid workflow transition rules.
        /// </summary>
        public WorkflowTransitionRules[] ValidRules { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a workflow scheme.
    /// </summary>
    public class WorkflowScheme
    {
        /// <summary>
        /// The ID of the workflow scheme.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of the workflow scheme. The name must be unique. The maximum length is 255 characters. Required when creating a workflow scheme.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the workflow scheme.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The name of the default workflow for the workflow scheme. The default workflow has *All Unassigned Issue Types* assigned to it in Jira. If `defaultWorkflow` is not specified when creating a workflow scheme, it is set to *Jira Workflow (jira)*.
        /// </summary>
        public string DefaultWorkflow { get; set; }

        /// <summary>
        /// Details about a workflow scheme.
        /// </summary>
        public IssueTypeMappings IssueTypeMappings { get; set; }

        /// <summary>
        /// For draft workflow schemes, this property is the name of the default workflow for the original workflow scheme. The default workflow has *All Unassigned Issue Types* assigned to it in Jira.
        /// </summary>
        public string OriginalDefaultWorkflow { get; set; }

        /// <summary>
        /// Details about a workflow scheme.
        /// </summary>
        public OriginalIssueTypeMappings OriginalIssueTypeMappings { get; set; }

        /// <summary>
        /// Whether the workflow scheme is a draft or not.
        /// </summary>
        public bool Draft { get; set; }

        /// <summary>
        /// Details about a workflow scheme.
        /// </summary>
        public LastModifiedUser LastModifiedUser { get; set; }

        /// <summary>
        /// The date-time that the draft workflow scheme was last modified. A modification is a change to the issue type-project mappings only. This property does not apply to non-draft workflows.
        /// </summary>
        public string LastModified { get; set; }

        public string Self { get; set; }

        /// <summary>
        /// Whether to create or update a draft workflow scheme when updating an active workflow scheme. An active workflow scheme is a workflow scheme that is used by at least one project. The following examples show how this property works: *  Update an active workflow scheme with `updateDraftIfNeeded` set to `true`: If a draft workflow scheme exists, it is updated. Otherwise, a draft workflow scheme is created. *  Update an active workflow scheme with `updateDraftIfNeeded` set to `false`: An error is returned, as active workflow schemes cannot be updated. *  Update an inactive workflow scheme with `updateDraftIfNeeded` set to `true`: The workflow scheme is updated, as inactive workflow schemes do not require drafts to update.Defaults to `false`.
        /// </summary>
        public bool UpdateDraftIfNeeded { get; set; }

        /// <summary>
        /// Details about a workflow scheme.
        /// </summary>
        public IssueTypes IssueTypes { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A workflow scheme along with a list of projects that use it.
    /// </summary>
    public class WorkflowSchemeAssociations
    {
        /// <summary>
        /// The list of projects that use the workflow scheme.
        /// </summary>
        public string[] ProjectIds { get; set; }

        /// <summary>
        /// A workflow scheme along with a list of projects that use it.
        /// </summary>
        public WorkflowScheme WorkflowScheme { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The ID and the name of the workflow scheme.
    /// </summary>
    public class WorkflowSchemeIdName
    {
        /// <summary>
        /// The ID of the workflow scheme.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the workflow scheme.
        /// </summary>
        public string Name { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// An associated workflow scheme and project.
    /// </summary>
    public class WorkflowSchemeProjectAssociation
    {
        /// <summary>
        /// The ID of the workflow scheme. If the workflow scheme ID is `null`, the operation assigns the default workflow scheme.
        /// </summary>
        public string WorkflowSchemeId { get; set; }

        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string ProjectId { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A workflow transition rule condition. This object returns `nodeType` as `simple`.
    /// </summary>
    public class WorkflowSimpleCondition
    {
        /// <summary>
        /// The type of the transition rule.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A workflow transition rule condition. This object returns `nodeType` as `simple`.
        /// </summary>
        public Configuration Configuration { get; set; }

        public string NodeType { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a workflow status.
    /// </summary>
    public class WorkflowStatus
    {
        /// <summary>
        /// The ID of the issue status.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the status in the workflow.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Details of a workflow status.
        /// </summary>
        public Properties Properties { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of workflows and their transition rules to delete.
    /// </summary>
    public class WorkflowsWithTransitionRulesDetails
    {
        /// <summary>
        /// The list of workflows with transition rules to delete.
        /// </summary>
        public WorkflowTransitionRulesDetails[] Workflows { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A workflow transition.
    /// </summary>
    public class WorkflowTransition
    {
        /// <summary>
        /// The transition ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The transition name.
        /// </summary>
        public string Name { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about the server Jira is running on.
    /// </summary>
    public class WorkflowTransitionProperty
    {
        /// <summary>
        /// The key of the transition property. Also known as the name of the transition property.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The value of the transition property.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The ID of the transition property.
        /// </summary>
        public string Id { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A workflow transition rule.
    /// </summary>
    public class WorkflowTransitionRule
    {
        /// <summary>
        /// The type of the transition rule.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A workflow transition rule.
        /// </summary>
        public Configuration Configuration { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A workflow with transition rules.
    /// </summary>
    public class WorkflowTransitionRules
    {
        /// <summary>
        /// not-used
        /// </summary>
        public WorkflowId WorkflowId { get; set; }

        /// <summary>
        /// The list of post functions within the workflow.
        /// </summary>
        public ConnectWorkflowTransitionRule[] PostFunctions { get; set; }

        /// <summary>
        /// The list of conditions within the workflow.
        /// </summary>
        public ConnectWorkflowTransitionRule[] Conditions { get; set; }

        /// <summary>
        /// The list of validators within the workflow.
        /// </summary>
        public ConnectWorkflowTransitionRule[] Validators { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a workflow configuration update request.
    /// </summary>
    public class WorkflowTransitionRulesDetails
    {
        /// <summary>
        /// not-used
        /// </summary>
        public WorkflowId WorkflowId { get; set; }

        /// <summary>
        /// The list of connect workflow rule IDs.
        /// </summary>
        public string[] WorkflowRuleIds { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details about a workflow configuration update request.
    /// </summary>
    public class WorkflowTransitionRulesUpdate
    {
        /// <summary>
        /// The list of workflows with transition rules to update.
        /// </summary>
        public WorkflowTransitionRules[] Workflows { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of any errors encountered while updating workflow transition rules for a workflow.
    /// </summary>
    public class WorkflowTransitionRulesUpdateErrorDetails
    {
        /// <summary>
        /// not-used
        /// </summary>
        public WorkflowId WorkflowId { get; set; }

        /// <summary>
        /// Details of any errors encountered while updating workflow transition rules for a workflow.
        /// </summary>
        public RuleUpdateErrors RuleUpdateErrors { get; set; }

        /// <summary>
        /// The list of errors that specify why the workflow update failed. The workflow was not updated if the list contains any entries.
        /// </summary>
        public string[] UpdateErrors { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of any errors encountered while updating workflow transition rules.
    /// </summary>
    public class WorkflowTransitionRulesUpdateErrors
    {
        /// <summary>
        /// A list of workflows.
        /// </summary>
        public WorkflowTransitionRulesUpdateErrorDetails[] UpdateResults { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Details of a worklog.
    /// </summary>
    public class Worklog
    {
        /// <summary>
        /// The URL of the worklog item.
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// Details of a worklog.
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// Details of a worklog.
        /// </summary>
        public UpdateAuthor UpdateAuthor { get; set; }

        /// <summary>
        /// Details of a worklog.
        /// </summary>
        public Comment Comment { get; set; }

        /// <summary>
        /// The datetime on which the worklog was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The datetime on which the worklog was last updated.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// Details of a worklog.
        /// </summary>
        public Visibility Visibility { get; set; }

        /// <summary>
        /// The datetime on which the worklog effort was started. Required when creating a worklog. Optional when updating a worklog.
        /// </summary>
        public DateTime Started { get; set; }

        /// <summary>
        /// The time spent working on the issue as days (\#d), hours (\#h), or minutes (\#m or \#). Required when creating a worklog if `timeSpentSeconds` isn't provided. Optional when updating a worklog. Cannot be provided if `timeSpentSecond` is provided.
        /// </summary>
        public string TimeSpent { get; set; }

        /// <summary>
        /// The time in seconds spent working on the issue. Required when creating a worklog if `timeSpent` isn't provided. Optional when updating a worklog. Cannot be provided if `timeSpent` is provided.
        /// </summary>
        public long TimeSpentSeconds { get; set; }

        /// <summary>
        /// The ID of the worklog record.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The ID of the issue this worklog is for.
        /// </summary>
        public string IssueId { get; set; }

        /// <summary>
        /// Details of properties for the worklog. Optional when creating or updating a worklog.
        /// </summary>
        public EntityProperty[] Properties { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public class WorklogIdsRequestBean
    {
        /// <summary>
        /// A list of worklog IDs.
        /// </summary>
        public long[] Ids { get; set; }
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class TypeConstants
    {
        public const string Issuetype = "issuetype";

        public const string Project = "project";

        public const string User = "user";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The nominal user type used to determine the assignee for issues created with this component. See `realAssigneeType` for details on how the type of the user, and hence the user, assigned to issues is determined. Can take the following values: *  `PROJECT_LEAD` the assignee to any issues created with this component is nominally the lead for the project the component is in. *  `COMPONENT_LEAD` the assignee to any issues created with this component is nominally the lead for the component. *  `UNASSIGNED` an assignee is not set for issues created with this component. *  `PROJECT_DEFAULT` the assignee to any issues created with this component is nominally the default assignee for the project that the component is in.Default value: `PROJECT_DEFAULT`.  Optional when creating or updating a component.
    /// </summary>
    public static class ProjectComponentAssigneeTypeConstants
    {
        public const string PROJECTDEFAULT = "PROJECT_DEFAULT";

        public const string COMPONENTLEAD = "COMPONENT_LEAD";

        public const string PROJECTLEAD = "PROJECT_LEAD";

        public const string UNASSIGNED = "UNASSIGNED";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The type of the assignee that is assigned to issues created with this component, when an assignee cannot be set from the `assigneeType`. For example, `assigneeType` is set to `COMPONENT_LEAD` but no component lead is set. This property is set to one of the following values: *  `PROJECT_LEAD` when `assigneeType` is `PROJECT_LEAD` and the project lead has permission to be assigned issues in the project that the component is in. *  `COMPONENT_LEAD` when `assignee`Type is `COMPONENT_LEAD` and the component lead has permission to be assigned issues in the project that the component is in. *  `UNASSIGNED` when `assigneeType` is `UNASSIGNED` and Jira is configured to allow unassigned issues. *  `PROJECT_DEFAULT` when none of the preceding cases are true.
    /// </summary>
    public static class ProjectComponentRealAssigneeTypeConstants
    {
        public const string PROJECTDEFAULT = "PROJECT_DEFAULT";

        public const string COMPONENTLEAD = "COMPONENT_LEAD";

        public const string PROJECTLEAD = "PROJECT_LEAD";

        public const string UNASSIGNED = "UNASSIGNED";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The format that will appear on an issue's *Time Spent* field.
    /// </summary>
    public static class TimeTrackingConfigurationTimeFormatConstants
    {
        public const string Pretty = "pretty";

        public const string Days = "days";

        public const string Hours = "hours";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default unit of time applied to logged time.
    /// </summary>
    public static class TimeTrackingConfigurationDefaultUnitConstants
    {
        public const string Minute = "minute";

        public const string Hour = "hour";

        public const string Day = "day";

        public const string Week = "week";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class FilterConstants
    {
        public const string My = "my";

        public const string Favourite = "favourite";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class OrderByConstants
    {
        public const string Description = "description";

        public const string Description = "-description";

        public const string Description = "+description";

        public const string FavoriteCount = "favorite_count";

        public const string FavoriteCount = "-favorite_count";

        public const string FavoriteCount = "+favorite_count";

        public const string Id = "id";

        public const string Id = "-id";

        public const string Id = "+id";

        public const string IsFavorite = "is_favorite";

        public const string IsFavorite = "-is_favorite";

        public const string IsFavorite = "+is_favorite";

        public const string Name = "name";

        public const string Name = "-name";

        public const string Name = "+name";

        public const string Owner = "owner";

        public const string Owner = "-owner";

        public const string Owner = "+owner";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class CheckConstants
    {
        public const string Syntax = "syntax";

        public const string Type = "type";

        public const string Complexity = "complexity";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class Constants
    {
        public const string Custom = "custom";

        public const string System = "system";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class OrderByConstants1
    {
        public const string ContextsCount = "contextsCount";

        public const string ContextsCount = "-contextsCount";

        public const string ContextsCount = "+contextsCount";

        public const string LastUsed = "lastUsed";

        public const string LastUsed = "-lastUsed";

        public const string LastUsed = "+lastUsed";

        public const string Name = "name";

        public const string Name = "-name";

        public const string Name = "+name";

        public const string ScreensCount = "screensCount";

        public const string ScreensCount = "-screensCount";

        public const string ScreensCount = "+screensCount";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The status of the task.
    /// </summary>
    public static class TaskProgressBeanRemoveOptionFromIssuesResultStatusConstants
    {
        public const string ENQUEUED = "ENQUEUED";

        public const string RUNNING = "RUNNING";

        public const string COMPLETE = "COMPLETE";

        public const string FAILED = "FAILED";

        public const string CANCELREQUESTED = "CANCEL_REQUESTED";

        public const string CANCELLED = "CANCELLED";

        public const string DEAD = "DEAD";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The scope of the default sharing for new filters and dashboards: *  `AUTHENTICATED` Shared with all logged-in users. *  `GLOBAL` Shared with all logged-in users. This shows as `AUTHENTICATED` in the response. *  `PRIVATE` Not shared with any users.
    /// </summary>
    public static class DefaultShareScopeScopeConstants
    {
        public const string GLOBAL = "GLOBAL";

        public const string AUTHENTICATED = "AUTHENTICATED";

        public const string PRIVATE = "PRIVATE";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class OrderByConstants2
    {
        public const string Description = "description";

        public const string Description = "-description";

        public const string Description = "+description";

        public const string FavouriteCount = "favourite_count";

        public const string FavouriteCount = "-favourite_count";

        public const string FavouriteCount = "+favourite_count";

        public const string Id = "id";

        public const string Id = "-id";

        public const string Id = "+id";

        public const string IsFavourite = "is_favourite";

        public const string IsFavourite = "-is_favourite";

        public const string IsFavourite = "+is_favourite";

        public const string Name = "name";

        public const string Name = "-name";

        public const string Name = "+name";

        public const string Owner = "owner";

        public const string Owner = "-owner";

        public const string Owner = "+owner";

        public const string IsShared = "is_shared";

        public const string IsShared = "-is_shared";

        public const string IsShared = "+is_shared";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The type of share permission: *  `user` Shared with a user. *  `group` Shared with a group. If set in a request, then specify `sharePermission.group` as well. *  `project` Shared with a project. If set in a request, then specify `sharePermission.project` as well. *  `projectRole` Share with a project role in a project. This value is not returned in responses. It is used in requests, where it needs to be specify with `projectId` and `projectRoleId`. *  `global` Shared globally. If set in a request, no other `sharePermission` properties need to be specified. *  `loggedin` Shared with all logged-in users. Note: This value is set in a request by specifying `authenticated` as the `type`. *  `project-unknown` Shared with a project that the user does not have access to. Cannot be set in a request.
    /// </summary>
    public static class SharePermissionTypeConstants
    {
        public const string User = "user";

        public const string Group = "group";

        public const string Project = "project";

        public const string ProjectRole = "projectRole";

        public const string Global = "global";

        public const string Loggedin = "loggedin";

        public const string Authenticated = "authenticated";

        public const string ProjectUnknown = "project-unknown";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class AvatarSizeConstants
    {
        public const string Xsmall = "xsmall";

        public const string Xsmall2x = "xsmall@2x";

        public const string Xsmall3x = "xsmall@3x";

        public const string Small = "small";

        public const string Small2x = "small@2x";

        public const string Small3x = "small@3x";

        public const string Medium = "medium";

        public const string Medium2x = "medium@2x";

        public const string Medium3x = "medium@3x";

        public const string Large = "large";

        public const string Large2x = "large@2x";

        public const string Large3x = "large@3x";

        public const string Xlarge = "xlarge";

        public const string Xlarge2x = "xlarge@2x";

        public const string Xlarge3x = "xlarge@3x";

        public const string Xxlarge = "xxlarge";

        public const string Xxlarge2x = "xxlarge@2x";

        public const string Xxlarge3x = "xxlarge@3x";

        public const string Xxxlarge = "xxxlarge";

        public const string Xxxlarge2x = "xxxlarge@2x";

        public const string Xxxlarge3x = "xxxlarge@3x";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class DeleteSubtasksConstants
    {
        public const string True = "true";

        public const string False = "false";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class OrderByConstants3
    {
        public const string Created = "created";

        public const string Created = "-created";

        public const string Created = "+created";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class AdjustEstimateConstants
    {
        public const string New = "new";

        public const string Leave = "leave";

        public const string Manual = "manual";

        public const string Auto = "auto";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class ValidationConstants
    {
        public const string Strict = "strict";

        public const string Warn = "warn";

        public const string None = "none";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The user account type. Can take the following values: *  `atlassian` regular Atlassian user account *  `app` system account used for Connect applications and OAuth to represent external systems *  `customer` Jira Service Desk account representing an external service desk
    /// </summary>
    public static class UserAccountTypeConstants
    {
        public const string Atlassian = "atlassian";

        public const string App = "app";

        public const string Customer = "customer";

        public const string Unknown = "unknown";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class OrderByConstants4
    {
        public const string Category = "category";

        public const string Category = "-category";

        public const string Category = "+category";

        public const string Key = "key";

        public const string Key = "-key";

        public const string Key = "+key";

        public const string Name = "name";

        public const string Name = "-name";

        public const string Name = "+name";

        public const string Owner = "owner";

        public const string Owner = "-owner";

        public const string Owner = "+owner";

        public const string IssueCount = "issueCount";

        public const string IssueCount = "-issueCount";

        public const string IssueCount = "+issueCount";

        public const string LastIssueUpdatedDate = "lastIssueUpdatedDate";

        public const string LastIssueUpdatedDate = "-lastIssueUpdatedDate";

        public const string LastIssueUpdatedDate = "+lastIssueUpdatedDate";

        public const string ArchivedDate = "archivedDate";

        public const string ArchivedDate = "+archivedDate";

        public const string ArchivedDate = "-archivedDate";

        public const string DeletedDate = "deletedDate";

        public const string DeletedDate = "+deletedDate";

        public const string DeletedDate = "-deletedDate";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class ActionConstants
    {
        public const string View = "view";

        public const string Browse = "browse";

        public const string Edit = "edit";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class Constants1
    {
        public const string Live = "live";

        public const string Archived = "archived";

        public const string Deleted = "deleted";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class ProjectTypeKeyConstants
    {
        public const string Software = "software";

        public const string ServiceDesk = "service_desk";

        public const string Business = "business";

        public const string ProductDiscovery = "product_discovery";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default assignee when creating issues for this project.
    /// </summary>
    public static class ProjectAssigneeTypeConstants
    {
        public const string PROJECTLEAD = "PROJECT_LEAD";

        public const string UNASSIGNED = "UNASSIGNED";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The [project type](https://confluence.atlassian.com/x/GwiiLQ#Jiraapplicationsoverview-Productfeaturesandprojecttypes) of the project.
    /// </summary>
    public static class ProjectProjectTypeKeyConstants
    {
        public const string Software = "software";

        public const string ServiceDesk = "service_desk";

        public const string Business = "business";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The type of the project.
    /// </summary>
    public static class ProjectStyleConstants
    {
        public const string Classic = "classic";

        public const string NextGen = "next-gen";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class OrderByConstants5
    {
        public const string Description = "description";

        public const string Description = "-description";

        public const string Description = "+description";

        public const string IssueCount = "issueCount";

        public const string IssueCount = "-issueCount";

        public const string IssueCount = "+issueCount";

        public const string Lead = "lead";

        public const string Lead = "-lead";

        public const string Lead = "+lead";

        public const string Name = "name";

        public const string Name = "-name";

        public const string Name = "+name";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The status of the task.
    /// </summary>
    public static class TaskProgressBeanObjectStatusConstants
    {
        public const string ENQUEUED = "ENQUEUED";

        public const string RUNNING = "RUNNING";

        public const string COMPLETE = "COMPLETE";

        public const string FAILED = "FAILED";

        public const string CANCELREQUESTED = "CANCEL_REQUESTED";

        public const string CANCELLED = "CANCELLED";

        public const string DEAD = "DEAD";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class NewProjectTypeKeyConstants
    {
        public const string Software = "software";

        public const string ServiceDesk = "service_desk";

        public const string Business = "business";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class OrderByConstants6
    {
        public const string Description = "description";

        public const string Description = "-description";

        public const string Description = "+description";

        public const string Name = "name";

        public const string Name = "-name";

        public const string Name = "+name";

        public const string ReleaseDate = "releaseDate";

        public const string ReleaseDate = "-releaseDate";

        public const string ReleaseDate = "+releaseDate";

        public const string Sequence = "sequence";

        public const string Sequence = "-sequence";

        public const string Sequence = "+sequence";

        public const string StartDate = "startDate";

        public const string StartDate = "-startDate";

        public const string StartDate = "+startDate";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class ValidateQueryConstants
    {
        public const string Strict = "strict";

        public const string Warn = "warn";

        public const string None = "none";

        public const string True = "true";

        public const string False = "false";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class TypeConstants1
    {
        public const string Project = "project";

        public const string Issuetype = "issuetype";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class TypeConstants2
    {
        public const string Issuetype = "issuetype";

        public const string Project = "project";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class SizeConstants
    {
        public const string Xsmall = "xsmall";

        public const string Small = "small";

        public const string Medium = "medium";

        public const string Large = "large";

        public const string Xlarge = "xlarge";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class FormatConstants
    {
        public const string Png = "png";

        public const string Svg = "svg";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class Constants2
    {
        public const string Postfunction = "postfunction";

        public const string Condition = "condition";

        public const string Validator = "validator";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class OrderByConstants7
    {
        public const string Name = "name";

        public const string Name = "-name";

        public const string Name = "+name";

        public const string Created = "created";

        public const string Created = "-created";

        public const string Created = "+created";

        public const string Updated = "updated";

        public const string Updated = "+updated";

        public const string Updated = "-updated";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class WorkflowModeConstants
    {
        public const string Live = "live";

        public const string Draft = "draft";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class EntityTypeConstants
    {
        public const string IssueProperty = "IssueProperty";

        public const string CommentProperty = "CommentProperty";

        public const string DashboardItemProperty = "DashboardItemProperty";

        public const string IssueTypeProperty = "IssueTypeProperty";

        public const string ProjectProperty = "ProjectProperty";

        public const string UserProperty = "UserProperty";

        public const string WorklogProperty = "WorklogProperty";

        public const string BoardProperty = "BoardProperty";

        public const string SprintProperty = "SprintProperty";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The type of the assignee that is assigned to issues created with this component, when an assignee cannot be set from the `assigneeType`. For example, `assigneeType` is set to `COMPONENT_LEAD` but no component lead is set. This property is set to one of the following values: *  `PROJECT_LEAD` when `assigneeType` is `PROJECT_LEAD` and the project lead has permission to be assigned issues in the project that the component is in. *  `COMPONENT_LEAD` when `assignee`Type is `COMPONENT_LEAD` and the component lead has permission to be assigned issues in the project that the component is in. *  `UNASSIGNED` when `assigneeType` is `UNASSIGNED` and Jira is configured to allow unassigned issues. *  `PROJECT_DEFAULT` when none of the preceding cases are true.
    /// </summary>
    public static class ComponentWithIssueCountRealAssigneeTypeConstants
    {
        public const string PROJECTDEFAULT = "PROJECT_DEFAULT";

        public const string COMPONENTLEAD = "COMPONENT_LEAD";

        public const string PROJECTLEAD = "PROJECT_LEAD";

        public const string UNASSIGNED = "UNASSIGNED";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The nominal user type used to determine the assignee for issues created with this component. See `realAssigneeType` for details on how the type of the user, and hence the user, assigned to issues is determined. Takes the following values: *  `PROJECT_LEAD` the assignee to any issues created with this component is nominally the lead for the project the component is in. *  `COMPONENT_LEAD` the assignee to any issues created with this component is nominally the lead for the component. *  `UNASSIGNED` an assignee is not set for issues created with this component. *  `PROJECT_DEFAULT` the assignee to any issues created with this component is nominally the default assignee for the project that the component is in.
    /// </summary>
    public static class ComponentWithIssueCountAssigneeTypeConstants
    {
        public const string PROJECTDEFAULT = "PROJECT_DEFAULT";

        public const string COMPONENTLEAD = "COMPONENT_LEAD";

        public const string PROJECTLEAD = "PROJECT_LEAD";

        public const string UNASSIGNED = "UNASSIGNED";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The operator between the clauses.
    /// </summary>
    public static class CompoundClauseOperatorConstants
    {
        public const string And = "and";

        public const string Or = "or";

        public const string Not = "not";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The type of custom field.
    /// </summary>
    public static class ConnectCustomFieldValueTypeConstants
    {
        public const string StringIssueField = "StringIssueField";

        public const string NumberIssueField = "NumberIssueField";

        public const string RichTextIssueField = "RichTextIssueField";

        public const string SingleSelectIssueField = "SingleSelectIssueField";

        public const string MultiSelectIssueField = "MultiSelectIssueField";

        public const string TextIssueField = "TextIssueField";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default assignee when creating issues for this project.
    /// </summary>
    public static class CreateProjectDetailsAssigneeTypeConstants
    {
        public const string PROJECTLEAD = "PROJECT_LEAD";

        public const string UNASSIGNED = "UNASSIGNED";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The [project type](https://confluence.atlassian.com/x/GwiiLQ#Jiraapplicationsoverview-Productfeaturesandprojecttypes), which defines the application-specific feature set. If you don't specify the project template you have to specify the project type.
    /// </summary>
    public static class CreateProjectDetailsProjectTypeKeyConstants
    {
        public const string Software = "software";

        public const string ServiceDesk = "service_desk";

        public const string Business = "business";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// A predefined configuration for a project. The type of the `projectTemplateKey` must match with the type of the `projectTypeKey`.
    /// </summary>
    public static class CreateProjectDetailsProjectTemplateKeyConstants
    {
        public const string ComPyxisGreenhopperJiraGhSimplifiedAgilityKanban = "com.pyxis.greenhopper.jira:gh-simplified-agility-kanban";

        public const string ComPyxisGreenhopperJiraGhSimplifiedAgilityScrum = "com.pyxis.greenhopper.jira:gh-simplified-agility-scrum";

        public const string ComPyxisGreenhopperJiraGhSimplifiedBasic = "com.pyxis.greenhopper.jira:gh-simplified-basic";

        public const string ComPyxisGreenhopperJiraGhSimplifiedKanbanClassic = "com.pyxis.greenhopper.jira:gh-simplified-kanban-classic";

        public const string ComPyxisGreenhopperJiraGhSimplifiedScrumClassic = "com.pyxis.greenhopper.jira:gh-simplified-scrum-classic";

        public const string ComAtlassianServicedeskSimplifiedItServiceManagement = "com.atlassian.servicedesk:simplified-it-service-management";

        public const string ComAtlassianServicedeskSimplifiedGeneralServiceDesk = "com.atlassian.servicedesk:simplified-general-service-desk";

        public const string ComAtlassianServicedeskSimplifiedInternalServiceDesk = "com.atlassian.servicedesk:simplified-internal-service-desk";

        public const string ComAtlassianServicedeskSimplifiedExternalServiceDesk = "com.atlassian.servicedesk:simplified-external-service-desk";

        public const string ComAtlassianServicedeskSimplifiedHrServiceDesk = "com.atlassian.servicedesk:simplified-hr-service-desk";

        public const string ComAtlassianServicedeskSimplifiedFacilitiesServiceDesk = "com.atlassian.servicedesk:simplified-facilities-service-desk";

        public const string ComAtlassianServicedeskSimplifiedLegalServiceDesk = "com.atlassian.servicedesk:simplified-legal-service-desk";

        public const string ComAtlassianJiraCoreProjectTemplatesJiraCoreSimplifiedContentManagement = "com.atlassian.jira-core-project-templates:jira-core-simplified-content-management";

        public const string ComAtlassianJiraCoreProjectTemplatesJiraCoreSimplifiedDocumentApproval = "com.atlassian.jira-core-project-templates:jira-core-simplified-document-approval";

        public const string ComAtlassianJiraCoreProjectTemplatesJiraCoreSimplifiedLeadTracking = "com.atlassian.jira-core-project-templates:jira-core-simplified-lead-tracking";

        public const string ComAtlassianJiraCoreProjectTemplatesJiraCoreSimplifiedProcessControl = "com.atlassian.jira-core-project-templates:jira-core-simplified-process-control";

        public const string ComAtlassianJiraCoreProjectTemplatesJiraCoreSimplifiedProcurement = "com.atlassian.jira-core-project-templates:jira-core-simplified-procurement";

        public const string ComAtlassianJiraCoreProjectTemplatesJiraCoreSimplifiedProjectManagement = "com.atlassian.jira-core-project-templates:jira-core-simplified-project-management";

        public const string ComAtlassianJiraCoreProjectTemplatesJiraCoreSimplifiedRecruitment = "com.atlassian.jira-core-project-templates:jira-core-simplified-recruitment";

        public const string ComAtlassianJiraCoreProjectTemplatesJiraCoreSimplifiedTask = "com.atlassian.jira-core-project-templates:jira-core-simplified-task-";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The compound condition operator.
    /// </summary>
    public static class CreateWorkflowConditionOperatorConstants
    {
        public const string AND = "AND";

        public const string OR = "OR";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The type of the transition.
    /// </summary>
    public static class CreateWorkflowTransitionDetailsTypeConstants
    {
        public const string Global = "global";

        public const string Initial = "initial";

        public const string Directed = "directed";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The searcher defines the way the field is searched in Jira. For example, *com.atlassian.jira.plugin.system.customfieldtypes:grouppickersearcher*.  The search UI (basic search and JQL search) will display different operations and values for the field, based on the field searcher. You must specify a searcher that is valid for the field type, as listed below (abbreviated values shown): *  `cascadingselect`: `cascadingselectsearcher` *  `datepicker`: `daterange` *  `datetime`: `datetimerange` *  `float`: `exactnumber` or `numberrange` *  `grouppicker`: `grouppickersearcher` *  `importid`: `exactnumber` or `numberrange` *  `labels`: `labelsearcher` *  `multicheckboxes`: `multiselectsearcher` *  `multigrouppicker`: `multiselectsearcher` *  `multiselect`: `multiselectsearcher` *  `multiuserpicker`: `userpickergroupsearcher` *  `multiversion`: `versionsearcher` *  `project`: `projectsearcher` *  `radiobuttons`: `multiselectsearcher` *  `readonlyfield`: `textsearcher` *  `select`: `multiselectsearcher` *  `textarea`: `textsearcher` *  `textfield`: `textsearcher` *  `url`: `exacttextsearcher` *  `userpicker`: `userpickergroupsearcher` *  `version`: `versionsearcher`If no searcher is provided, the field isn't searchable. However, [Forge custom fields](https://developer.atlassian.com/platform/forge/manifest-reference/modules/#jira-custom-field-type--beta-) have a searcher set automatically, so are always searchable.
    /// </summary>
    public static class CustomFieldDefinitionJsonBeanSearcherKeyConstants
    {
        public const string ComAtlassianJiraPluginSystemCustomfieldtypesCascadingselectsearcher = "com.atlassian.jira.plugin.system.customfieldtypes:cascadingselectsearcher";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesDaterange = "com.atlassian.jira.plugin.system.customfieldtypes:daterange";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesDatetimerange = "com.atlassian.jira.plugin.system.customfieldtypes:datetimerange";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesExactnumber = "com.atlassian.jira.plugin.system.customfieldtypes:exactnumber";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesExacttextsearcher = "com.atlassian.jira.plugin.system.customfieldtypes:exacttextsearcher";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesGrouppickersearcher = "com.atlassian.jira.plugin.system.customfieldtypes:grouppickersearcher";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesLabelsearcher = "com.atlassian.jira.plugin.system.customfieldtypes:labelsearcher";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesMultiselectsearcher = "com.atlassian.jira.plugin.system.customfieldtypes:multiselectsearcher";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesNumberrange = "com.atlassian.jira.plugin.system.customfieldtypes:numberrange";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesProjectsearcher = "com.atlassian.jira.plugin.system.customfieldtypes:projectsearcher";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesTextsearcher = "com.atlassian.jira.plugin.system.customfieldtypes:textsearcher";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesUserpickergroupsearcher = "com.atlassian.jira.plugin.system.customfieldtypes:userpickergroupsearcher";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesVersionsearcher = "com.atlassian.jira.plugin.system.customfieldtypes:versionsearcher";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Identifies the recipients of the notification.
    /// </summary>
    public static class EventNotificationNotificationTypeConstants
    {
        public const string CurrentAssignee = "CurrentAssignee";

        public const string Reporter = "Reporter";

        public const string CurrentUser = "CurrentUser";

        public const string ProjectLead = "ProjectLead";

        public const string ComponentLead = "ComponentLead";

        public const string User = "User";

        public const string Group = "Group";

        public const string ProjectRole = "ProjectRole";

        public const string EmailAddress = "EmailAddress";

        public const string AllWatchers = "AllWatchers";

        public const string UserCustomField = "UserCustomField";

        public const string GroupCustomField = "GroupCustomField";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The operator applied to the field.
    /// </summary>
    public static class FieldChangedClauseOperatorConstants
    {
        public const string Changed = "changed";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Last used value type: *  *TRACKED*: field is tracked and a last used date is available. *  *NOT\_TRACKED*: field is not tracked, last used date is not available. *  *NO\_INFORMATION*: field is tracked, but no last used date is available.
    /// </summary>
    public static class FieldLastUsedTypeConstants
    {
        public const string TRACKED = "TRACKED";

        public const string NOTTRACKED = "NOT_TRACKED";

        public const string NOINFORMATION = "NO_INFORMATION";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Whether the field can be used in a query's `ORDER BY` clause.
    /// </summary>
    public static class FieldReferenceDataOrderableConstants
    {
        public const string True = "true";

        public const string False = "false";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Whether the content of this field can be searched.
    /// </summary>
    public static class FieldReferenceDataSearchableConstants
    {
        public const string True = "true";

        public const string False = "false";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Whether the field provide auto-complete suggestions.
    /// </summary>
    public static class FieldReferenceDataAutoConstants
    {
        public const string True = "true";

        public const string False = "false";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The operator between the field and operand.
    /// </summary>
    public static class FieldValueClauseOperatorConstants
    {
        public const string Equal = "=";

        public const string Equal = "!=";

        public const string GreaterThan = ">";

        public const string LessThan = "<";

        public const string GreaterThanEqual = ">=";

        public const string LessThanEqual = "<=";

        public const string In = "in";

        public const string NotIn = "not in";

        public const string Approximately = "~";

        public const string ApproximatelyEqual = "~=";

        public const string Is = "is";

        public const string IsNot = "is not";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The operator between the field and operand.
    /// </summary>
    public static class FieldWasClauseOperatorConstants
    {
        public const string Was = "was";

        public const string WasIn = "was in";

        public const string WasNotIn = "was not in";

        public const string WasNot = "was not";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Whether the function can take a list of arguments.
    /// </summary>
    public static class FunctionReferenceDataIsListConstants
    {
        public const string True = "true";

        public const string False = "false";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class GlobalScopeBeanConstants
    {
        public const string NotSelectable = "notSelectable";

        public const string DefaultValue = "defaultValue";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The type of the group label.
    /// </summary>
    public static class GroupLabelTypeConstants
    {
        public const string ADMIN = "ADMIN";

        public const string SINGLE = "SINGLE";

        public const string MULTIPLE = "MULTIPLE";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class HierarchyLevelGlobalHierarchyLevelConstants
    {
        public const string SUBTASK = "SUBTASK";

        public const string BASE = "BASE";

        public const string EPIC = "EPIC";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class IssueFieldOptionConfigurationConstants
    {
        public const string NotSelectable = "notSelectable";

        public const string DefaultValue = "defaultValue";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Deprecated. Use `hierarchyLevel` instead.Whether the issue type is `subtype` or `standard`. Defaults to `standard`.
    /// </summary>
    public static class IssueTypeCreateBeanTypeConstants
    {
        public const string Subtask = "subtask";

        public const string Standard = "standard";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Determines how to validate the JQL query and treat the validation results.
    /// </summary>
    public static class JexpJqlIssuesValidationConstants
    {
        public const string Strict = "strict";

        public const string Warn = "warn";

        public const string None = "none";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The error type.
    /// </summary>
    public static class JiraExpressionValidationErrorTypeConstants
    {
        public const string Syntax = "syntax";

        public const string Type = "type";

        public const string Other = "other";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The operator between the field and the operand.
    /// </summary>
    public static class JqlQueryClauseTimePredicateOperatorConstants
    {
        public const string Before = "before";

        public const string After = "after";

        public const string From = "from";

        public const string To = "to";

        public const string On = "on";

        public const string During = "during";

        public const string By = "by";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The type of the property value extraction. Not available if the extraction for the property is not registered on the instance with the [Entity property](https://developer.atlassian.com/cloud/jira/platform/modules/entity-property/) module.
    /// </summary>
    public static class JqlQueryFieldEntityPropertyTypeConstants
    {
        public const string Number = "number";

        public const string String = "string";

        public const string Text = "text";

        public const string Date = "date";

        public const string User = "user";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The direction in which to order the results.
    /// </summary>
    public static class JqlQueryOrderByClauseElementDirectionConstants
    {
        public const string Asc = "asc";

        public const string Desc = "desc";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class JsonNodeNumberTypeConstants
    {
        public const string INT = "INT";

        public const string LONG = "LONG";

        public const string BIGINTEGER = "BIG_INTEGER";

        public const string FLOAT = "FLOAT";

        public const string DOUBLE = "DOUBLE";

        public const string BIGDECIMAL = "BIG_DECIMAL";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The keyword that is the operand value.
    /// </summary>
    public static class KeywordOperandKeywordConstants
    {
        public const string Empty = "empty";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The licensing plan.
    /// </summary>
    public static class LicensedApplicationPlanConstants
    {
        public const string UNLICENSED = "UNLICENSED";

        public const string FREE = "FREE";

        public const string PAID = "PAID";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The named position to which the screen tab field should be moved. Required if `after` isn't provided.
    /// </summary>
    public static class MoveFieldBeanPositionConstants
    {
        public const string Earlier = "Earlier";

        public const string Later = "Later";

        public const string First = "First";

        public const string Last = "Last";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The position the custom field options should be moved to. Required if `after` isn't provided.
    /// </summary>
    public static class OrderOfCustomFieldOptionsPositionConstants
    {
        public const string First = "First";

        public const string Last = "Last";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The position the issue types should be moved to. Required if `after` isn't provided.
    /// </summary>
    public static class OrderOfIssueTypesPositionConstants
    {
        public const string First = "First";

        public const string Last = "Last";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The [project type](https://confluence.atlassian.com/x/GwiiLQ#Jiraapplicationsoverview-Productfeaturesandprojecttypes) of the project.
    /// </summary>
    public static class ProjectDetailsProjectTypeKeyConstants
    {
        public const string Software = "software";

        public const string ServiceDesk = "service_desk";

        public const string Business = "business";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The state of the feature. When updating the state of a feature, only ENABLED and DISABLED are supported. Responses can contain all values
    /// </summary>
    public static class ProjectFeatureStateConstants
    {
        public const string ENABLED = "ENABLED";

        public const string DISABLED = "DISABLED";

        public const string COMINGSOON = "COMING_SOON";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The feature state.
    /// </summary>
    public static class ProjectFeatureStateStateConstants
    {
        public const string ENABLED = "ENABLED";

        public const string DISABLED = "DISABLED";

        public const string COMINGSOON = "COMING_SOON";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class ProjectScopeBeanConstants
    {
        public const string NotSelectable = "notSelectable";

        public const string DefaultValue = "defaultValue";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The type of role actor.
    /// </summary>
    public static class RoleActorTypeConstants
    {
        public const string AtlassianGroupRoleActor = "atlassian-group-role-actor";

        public const string AtlassianUserRoleActor = "atlassian-user-role-actor";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The type of scope.
    /// </summary>
    public static class ScopeTypeConstants
    {
        public const string PROJECT = "PROJECT";

        public const string TEMPLATE = "TEMPLATE";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Determines how to validate the JQL query and treat the validation results. Supported values: *  `strict` Returns a 400 response code if any errors are found, along with a list of all errors (and warnings). *  `warn` Returns all errors as warnings. *  `none` No validation is performed. *  `true` *Deprecated* A legacy synonym for `strict`. *  `false` *Deprecated* A legacy synonym for `warn`.The default is `strict`.Note: If the JQL is not correctly formed a 400 response code is returned, regardless of the `validateQuery` value.
    /// </summary>
    public static class SearchRequestBeanValidateQueryConstants
    {
        public const string Strict = "strict";

        public const string Warn = "warn";

        public const string None = "none";

        public const string True = "true";

        public const string False = "false";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The type of the share permission.Specify the type as follows: *  `user` Share with a user. *  `group` Share with a group. Specify `groupname` as well. *  `project` Share with a project. Specify `projectId` as well. *  `projectRole` Share with a project role in a project. Specify `projectId` and `projectRoleId` as well. *  `global` Share globally, including anonymous users. If set, this type overrides all existing share permissions and must be deleted before any non-global share permissions is set. *  `authenticated` Share with all logged-in users. This shows as `loggedin` in the response. If set, this type overrides all existing share permissions and must be deleted before any non-global share permissions is set.
    /// </summary>
    public static class SharePermissionInputBeanTypeConstants
    {
        public const string User = "user";

        public const string Project = "project";

        public const string Group = "group";

        public const string ProjectRole = "projectRole";

        public const string Global = "global";

        public const string Authenticated = "authenticated";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The type of the transition.
    /// </summary>
    public static class TransitionTypeConstants
    {
        public const string Global = "global";

        public const string Initial = "initial";

        public const string Directed = "directed";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The searcher that defines the way the field is searched in Jira. It can be set to `null`, otherwise you must specify the valid searcher for the field type, as listed below (abbreviated values shown): *  `cascadingselect`: `cascadingselectsearcher` *  `datepicker`: `daterange` *  `datetime`: `datetimerange` *  `float`: `exactnumber` or `numberrange` *  `grouppicker`: `grouppickersearcher` *  `importid`: `exactnumber` or `numberrange` *  `labels`: `labelsearcher` *  `multicheckboxes`: `multiselectsearcher` *  `multigrouppicker`: `multiselectsearcher` *  `multiselect`: `multiselectsearcher` *  `multiuserpicker`: `userpickergroupsearcher` *  `multiversion`: `versionsearcher` *  `project`: `projectsearcher` *  `radiobuttons`: `multiselectsearcher` *  `readonlyfield`: `textsearcher` *  `select`: `multiselectsearcher` *  `textarea`: `textsearcher` *  `textfield`: `textsearcher` *  `url`: `exacttextsearcher` *  `userpicker`: `userpickergroupsearcher` *  `version`: `versionsearcher`
    /// </summary>
    public static class UpdateCustomFieldDetailsSearcherKeyConstants
    {
        public const string ComAtlassianJiraPluginSystemCustomfieldtypesCascadingselectsearcher = "com.atlassian.jira.plugin.system.customfieldtypes:cascadingselectsearcher";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesDaterange = "com.atlassian.jira.plugin.system.customfieldtypes:daterange";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesDatetimerange = "com.atlassian.jira.plugin.system.customfieldtypes:datetimerange";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesExactnumber = "com.atlassian.jira.plugin.system.customfieldtypes:exactnumber";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesExacttextsearcher = "com.atlassian.jira.plugin.system.customfieldtypes:exacttextsearcher";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesGrouppickersearcher = "com.atlassian.jira.plugin.system.customfieldtypes:grouppickersearcher";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesLabelsearcher = "com.atlassian.jira.plugin.system.customfieldtypes:labelsearcher";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesMultiselectsearcher = "com.atlassian.jira.plugin.system.customfieldtypes:multiselectsearcher";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesNumberrange = "com.atlassian.jira.plugin.system.customfieldtypes:numberrange";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesProjectsearcher = "com.atlassian.jira.plugin.system.customfieldtypes:projectsearcher";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesTextsearcher = "com.atlassian.jira.plugin.system.customfieldtypes:textsearcher";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesUserpickergroupsearcher = "com.atlassian.jira.plugin.system.customfieldtypes:userpickergroupsearcher";

        public const string ComAtlassianJiraPluginSystemCustomfieldtypesVersionsearcher = "com.atlassian.jira.plugin.system.customfieldtypes:versionsearcher";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The default assignee when creating issues for this project.
    /// </summary>
    public static class UpdateProjectDetailsAssigneeTypeConstants
    {
        public const string PROJECTLEAD = "PROJECT_LEAD";

        public const string UNASSIGNED = "UNASSIGNED";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The type of the permission.
    /// </summary>
    public static class UserPermissionTypeConstants
    {
        public const string GLOBAL = "GLOBAL";

        public const string PROJECT = "PROJECT";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// An absolute position in which to place the moved version. Cannot be used with `after`.
    /// </summary>
    public static class VersionMoveBeanPositionConstants
    {
        public const string Earlier = "Earlier";

        public const string Later = "Later";

        public const string First = "First";

        public const string Last = "Last";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// Whether visibility of this item is restricted to a group or role.
    /// </summary>
    public static class VisibilityTypeConstants
    {
        public const string Group = "group";

        public const string Role = "role";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class WebhookConstants
    {
        public const string JiraIssueCreated = "jira:issue_created";

        public const string JiraIssueUpdated = "jira:issue_updated";

        public const string JiraIssueDeleted = "jira:issue_deleted";

        public const string CommentCreated = "comment_created";

        public const string CommentUpdated = "comment_updated";

        public const string CommentDeleted = "comment_deleted";

        public const string IssuePropertySet = "issue_property_set";

        public const string IssuePropertyDeleted = "issue_property_deleted";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    public static class WebhookDetailsConstants
    {
        public const string JiraIssueCreated = "jira:issue_created";

        public const string JiraIssueUpdated = "jira:issue_updated";

        public const string JiraIssueDeleted = "jira:issue_deleted";

        public const string CommentCreated = "comment_created";

        public const string CommentUpdated = "comment_updated";

        public const string CommentDeleted = "comment_deleted";

        public const string IssuePropertySet = "issue_property_set";

        public const string IssuePropertyDeleted = "issue_property_deleted";
    }
}

namespace RestEaseClientGeneratorConsoleApp.Examples.Jira.Models
{
    /// <summary>
    /// The compound condition operator.
    /// </summary>
    public static class WorkflowCompoundConditionOperatorConstants
    {
        public const string AND = "AND";

        public const string OR = "OR";
    }
}
