using System;
using System.Collections.Generic;
using System.Net.Http;
using FullContact.Contacts.API.Models;
using FullContact.Contacts.API.Requests;
using FullContact.Contacts.API.Requests.Contacts;
using FullContact.Contacts.API.Responses;
using FullContact.Contacts.API.Responses.Contacts;
using System.Threading.Tasks;

namespace FullContact.Contacts.API
{
    public class Contacts : API
    {
        public Contacts(IDictionary<string, object> config) : base(config)
        {
        }

        public Contacts(IDictionary<string, object> config, HttpClient client) : base(config, client)
        {
        }

        /// <summary>
        /// Gets a list of contacts by their ids.
        /// </summary>
        /// <returns>The list of contacts.</returns>
        /// <param name="accessToken">Access token.</param>
        /// <param name="contactIds">Contact identifiers.</param>
        /// <param name="teamId">Team identifier.</param>
        public async Task<APIResponse<ContactsResponseBody>> Get(String accessToken, List<String> contactIds, String teamId)
        {
            return await this.RequestAsync<ContactsResponseBody>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/contacts.get",
                new GetContactsRequest{ ContactIds = contactIds, TeamId = teamId },
                null
            );
        }

        /// <summary>
        /// Scrolls a list of the user's contacts.
        /// </summary>
        /// <returns>The list of contacts.</returns>
        /// <param name="accessToken">Access token.</param>
        /// <param name="teamId">Team identifier.</param>
        public async Task<APIResponse<ContactsResponseBody>> Scroll(String accessToken, String teamId)
        {
            return await this.Scroll(accessToken, null, null, teamId, null);
        }

        /// <summary>
        /// Scrolls a list of the user's contacts.
        /// </summary>
        /// <returns>The list of contacts/</returns>
        /// <param name="accessToken">Access token.</param>
        /// <param name="cursor">Cursor.</param>
        /// <param name="teamId">Team identifier.</param>
        public async Task<APIResponse<ContactsResponseBody>> Scroll(String accessToken, String cursor, String teamId)
        {
            return await this.Scroll(accessToken, cursor, null, teamId, null);
        }

        /// <summary>
        /// Scrolls a list of the user's contacts.
        /// </summary>
        /// <returns>The list of contacts.</returns>
        /// <param name="accessToken">Access token.</param>
        /// <param name="cursor">Cursor.</param>
        /// <param name="includeDeleted">Include deleted.</param>
        /// <param name="teamId">Team identifier.</param>
        /// <param name="size">Size.</param>
        public async Task<APIResponse<ContactsResponseBody>> Scroll(String accessToken, String cursor, Boolean? includeDeleted, String teamId, int? size)
        {
            return await this.RequestAsync<ContactsResponseBody>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/contacts.scroll",
                new ScrollContactsRequest { 
                    TeamId = teamId, 
                    ScrollCursor = cursor, 
                    IncludeDeletedContacts = includeDeleted, 
                    Size = size 
                },
                null
            );
        }

        /// <summary>
        /// Searches the user's contacts.
        /// </summary>
        /// <returns>The list of matching contacts.</returns>
        /// <param name="accessToken">Access token.</param>
        /// <param name="query">Query.</param>
        /// <param name="teamId">Team identifier.</param>
        public async Task<APIResponse<ContactsResponseBody>> Search(String accessToken, String query, String teamId)
        {
            return await this.Search(accessToken, query, null, teamId, null);
        }

        /// <summary>
        /// Searches the user's contacts.
        /// </summary>
        /// <returns>The list of matching contacts.</returns>
        /// <param name="accessToken">Access token.</param>
        /// <param name="query">Query.</param>
        /// <param name="cursor">Cursor.</param>
        /// <param name="teamId">Team identifier.</param>
        public async Task<APIResponse<ContactsResponseBody>> Search(String accessToken, String query, String cursor, String teamId)
        {
            return await this.Search(accessToken, query, cursor, teamId, null);
        }

        /// <summary>
        /// Searches the user's contacts.
        /// </summary>
        /// <returns>The list of matching contacts.</returns>
        /// <param name="accessToken">Access token.</param>
        /// <param name="query">Query.</param>
        /// <param name="cursor">Cursor.</param>
        /// <param name="teamId">Team identifier.</param>
        /// <param name="tagIds">Tag identifiers.</param>
        public async Task<APIResponse<ContactsResponseBody>> Search(String accessToken, String query, String cursor, String teamId, List<String> tagIds)
        {
            return await this.RequestAsync<ContactsResponseBody>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/contacts.search",
                new SearchContactsRequest
                {
                    TeamId = teamId,
                    SearchCursor = cursor,
                    SearchQuery = query,
                    TagIds = tagIds
                },
                null
            );
        }

        /// <summary>
        /// Creates a new contact.
        /// </summary>
        /// <returns>The created contact.</returns>
        /// <param name="accessToken">Access token.</param>
        /// <param name="contact">Contact.</param>
        /// <param name="teamId">Team identifier.</param>
        public async Task<APIResponse<ContactResponseBody>> Create(String accessToken, Contact contact, String teamId)
        {
            return await this.RequestAsync<ContactResponseBody>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/contacts.create",
                new CreateContactRequest
                {
                    TeamId = teamId,
                    Contact = contact
                },
                null
            );
        }

        /// <summary>
        /// Updates an existing contact.
        /// </summary>
        /// <returns>The updated contact.</returns>
        /// <param name="accessToken">Access token.</param>
        /// <param name="contact">Contact.</param>
        /// <param name="teamId">Team identifier.</param>
        public async Task<APIResponse<ContactResponseBody>> Update(String accessToken, Contact contact, String teamId)
        {
            return await this.RequestAsync<ContactResponseBody>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/contacts.update",
                new UpdateContactRequest
                {
                    TeamId = teamId,
                    Contact = contact
                },
                null
            );
        }

        /// <summary>
        /// Adds or removes tags for a list of contacts.
        /// </summary>
        /// <returns></returns>
        /// <param name="accessToken">Access token.</param>
        /// <param name="contactIds">Contact identifiers.</param>
        /// <param name="addTagIds">Add tag identifiers.</param>
        /// <param name="removeTagIds">Remove tag identifiers.</param>
        /// <param name="teamId">Team identifier.</param>
        public async Task<APIResponse<dynamic>> ManageTags(String accessToken, List<String> contactIds, List<String> addTagIds, List<String> removeTagIds, String teamId)
        {
            return await this.RequestAsync<dynamic>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/contacts.manageTags",
                new ManageTagsRequest
                {
                    TeamId = teamId,
                    ContactIds = contactIds,
                    AddTagIds = addTagIds,
                    RemoveTagIds = removeTagIds
                },
                null
            );
        }

        /// <summary>
        /// Deletes and existing contact.
        /// </summary>
        /// <returns></returns>
        /// <param name="accessToken">Access token.</param>
        /// <param name="contactId">Contact identifier.</param>
        /// <param name="etag">Etag.</param>
        /// <param name="teamId">Team identifier.</param>
        public async Task<APIResponse<dynamic>> Delete(String accessToken, String contactId, String etag, String teamId)
        {
            return await this.RequestAsync<dynamic>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/contacts.delete",
                new DeleteContactRequest
                {
                    TeamId = teamId,
                    ContactId = contactId,
                    Etag = etag
                },
                null
            );
        }
    }
}
