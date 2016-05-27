// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
namespace ServiceStack.Discovery.Consul
{
    using System;
    using System.Collections.Generic;

    public interface IDiscovery
    {
        /// <summary>
        /// Holds the current service registration
        /// </summary>
        ServiceRegistration Registration { get; }

        /// <summary>
        /// Registers the service for discovery
        /// </summary>
        /// <param name="host"></param>
        void Register(IAppHost host);

        /// <summary>
        /// Unregisters the service from discovery
        /// </summary>
        /// <param name="host"></param>
        void Unregister(IAppHost host);

        /// <summary>
        /// Returns a list of available services
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        ConsulService[] GetServices(string serviceName);

        /// <summary>
        /// Returns a single service for a dto
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="dtoName"></param>
        /// <returns></returns>
        ConsulService GetService(string serviceName, string dtoName);

        /// <summary>
        /// Inspects the IAppHost and returns a list of strings that will represent the RequestDTO types
        /// These strings are used by <see cref="ResolveBaseUri(object)"/> to find the AppHost's BaseUri
        /// </summary>
        /// <param name="host">the apphost</param>
        /// <returns>list of types to register for discovery</returns>
        HashSet<Type> GetRequestTypes(IAppHost host);

        /// <summary>
        /// Takes a dto object and returns the correct BaserUri for the gateway to send it to
        /// </summary>
        /// <param name="dto">the request dto</param>
        /// <returns>the BaseUri that will serve this request</returns>
        string ResolveBaseUri(object dto);

        /// <summary>
        /// Takes a dto type and returns the correct BaseUri for the gateway to send it to
        /// </summary>
        /// <param name="dtoType">The request dto type</param>
        /// <returns>the BaserUri that will serve this request</returns>
        string ResolveBaseUri(Type dtoType);
    }
}