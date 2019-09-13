// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bot.Connector
{
    using Microsoft.Rest;
    
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System;
    using System.Text;

    /// <summary>
    /// OAuthClient operations.
    /// </summary>
    public partial class OAuthApi : IServiceOperations<OAuthClient>, IOAuthApiEx
    {
        /// <summary>
        /// Initializes a new instance of the OAuthApi class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public OAuthApi(OAuthClient client)
        {
            if (client == null)
            {
                throw new System.ArgumentNullException("client");
            }
            Client = client;
        }

        /// <summary>
        /// Gets a reference to the OAuthClient
        /// </summary>
        public OAuthClient Client { get; private set; }

        [Obsolete("Use IOAuthApiEx.GetUserTokenAsync")]
        public Task<TokenResponse> GetUserTokenAsync(string userId, string connectionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetUserTokenAsync(null, userId, connectionName, null, cancellationToken);
        }
        
        [Obsolete("Use IOAuthApiEx.GetUserTokenAsync")]
        public Task<TokenResponse> GetUserTokenAsync(string userId, string connectionName, string magicCode, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetUserTokenAsync(null, userId, connectionName, magicCode, cancellationToken);
        }
        
        public async Task<TokenResponse> GetUserTokenAsync(string channelId, string userId, string connectionName, string magicCode = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (connectionName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "connectionName");
            }
            if (userId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "userId");
            }

            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("channelId", channelId);
                tracingParameters.Add("userId", userId);
                tracingParameters.Add("connectionName", connectionName);
                tracingParameters.Add("magicCode", magicCode);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "GetUserTokenAsync", tracingParameters);
            }

            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "api/usertoken/GetToken?userId={userId}&connectionName={connectionName}{magicCodeParam}{channelIdParam}").ToString();
            _url = _url.Replace("{connectionName}", System.Uri.EscapeDataString(connectionName));
            _url = _url.Replace("{userId}", System.Uri.EscapeDataString(userId));
            if (!string.IsNullOrEmpty(magicCode))
            {
                _url = _url.Replace("{magicCodeParam}", $"&code={System.Uri.EscapeDataString(magicCode)}");
            }
            else
            {
                _url = _url.Replace("{magicCodeParam}", String.Empty);
            }

            if (!string.IsNullOrEmpty(channelId))
            {
                _url = _url.Replace("{channelIdParam}", $"&channelId={System.Uri.EscapeDataString(channelId)}");
            }
            else
            {
                _url = _url.Replace("{channelIdParam}", String.Empty);
            }

            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("GET");
            _httpRequest.RequestUri = new System.Uri(_url);
            
            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            cancellationToken.ThrowIfCancellationRequested();

            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if (_statusCode == HttpStatusCode.OK)
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    var tokenResponse = Rest.Serialization.SafeJsonConvert.DeserializeObject<TokenResponse>(_responseContent);
                    return tokenResponse;
                }
                catch (JsonException)
                {
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    return null;
                }
            }
            else if (_statusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                return null;
            }
        }

        [Obsolete("Use IOAuthApiEx.SignOutUserAsync")]
        public Task<bool> SignOutUserAsync(string userId, string connectionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return SignOutUserAsync(null, userId, connectionName, cancellationToken);
        }

        public async Task<bool> SignOutUserAsync(string channelId, string userId, string connectionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (connectionName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "connectionName");
            }
            if (userId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "userId");
            }

            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("userId", userId);
                tracingParameters.Add("connectionName", connectionName);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "SignOutUserAsync", tracingParameters);
            }

            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "api/usertoken/SignOut?&userId={userId}&connectionName={connectionName}{channelIdParam}").ToString();
            _url = _url.Replace("{connectionName}", System.Uri.EscapeDataString(connectionName));
            _url = _url.Replace("{userId}", System.Uri.EscapeDataString(userId));
            if (!string.IsNullOrEmpty(channelId))
            {
                _url = _url.Replace("{channelIdParam}", $"&channelId={System.Uri.EscapeDataString(channelId)}");
            }
            else
            {
                _url = _url.Replace("{channelIdParam}", String.Empty);
            }
            
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("DELETE");
            _httpRequest.RequestUri = new System.Uri(_url);

            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            cancellationToken.ThrowIfCancellationRequested();

            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }

            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (_statusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> GetSignInLinkAsync(IActivity activity, string connectionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (connectionName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "connectionName");
            }
            if (activity == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "activity");
            }
            
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("activity", activity);
                tracingParameters.Add("connectionName", connectionName);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "GetSignInLinkAsync", tracingParameters);
            }

            var tokenExchangeState = new TokenExchangeState()
            {
                ConnectionName = connectionName,
                Conversation = new ConversationReference()
                {
                    ActivityId = activity.Id,
                    Bot = activity.Recipient,       // Activity is from the user to the bot
                    ChannelId = activity.ChannelId,
                    Conversation = activity.Conversation,
                    ServiceUrl = activity.ServiceUrl,
                    User = activity.From
                },
                MsAppId = (Client.Credentials as MicrosoftAppCredentials)?.MicrosoftAppId
            };

            var serializedState = JsonConvert.SerializeObject(tokenExchangeState);
            var encodedState = Encoding.UTF8.GetBytes(serializedState);
            var finalState = Convert.ToBase64String(encodedState);

            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "api/botsignin/getsigninurl?&state={state}").ToString();
            _url = _url.Replace("{state}", finalState);

            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("GET");
            _httpRequest.RequestUri = new System.Uri(_url);

            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            cancellationToken.ThrowIfCancellationRequested();

            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }

            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (_statusCode == HttpStatusCode.OK)
            {
                var link = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                return link;
            }
            return String.Empty;
        }

        public async Task SendEmulateOAuthCardsAsync(bool emulateOAuthCards)
        {
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("emulateOAuthCards", emulateOAuthCards);
                ServiceClientTracing.Enter(_invocationId, this, "SendEmulateOAuthCards", tracingParameters);
            }

            var cancellationToken = default(CancellationToken);
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "api/usertoken/emulateOAuthCards?emulate={emulate}").ToString();
            _url = _url.Replace("{emulate}", emulateOAuthCards.ToString());

            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("POST");
            _httpRequest.RequestUri = new System.Uri(_url);

            // Set Credentials
            if (Client.Credentials != null)
            {
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }

            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
        }
    }
}
