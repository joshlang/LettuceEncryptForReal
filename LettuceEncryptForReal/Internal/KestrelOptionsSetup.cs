// Copyright (c) Nate McMaster.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using McMaster.AspNetCore.Kestrel.Certificates;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Options;

namespace LettuceEncrypt.Internal
{
    internal class KestrelOptionsSetup : IConfigureOptions<KestrelServerOptions>
    {
        private readonly IServerCertificateSelector _certificateSelector;

        public KestrelOptionsSetup(IServerCertificateSelector certificateSelector)
        {
            _certificateSelector = certificateSelector ?? throw new ArgumentNullException(nameof(certificateSelector));
        }

        public void Configure(KestrelServerOptions options)
        {
            options.ConfigureHttpsDefaults(o =>
            {
                o.UseServerCertificateSelector(_certificateSelector);
            });
        }
    }
}
