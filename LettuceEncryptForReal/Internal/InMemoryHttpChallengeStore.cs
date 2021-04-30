﻿// Copyright (c) Nate McMaster.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace LettuceEncrypt.Internal
{
    internal class InMemoryHttpChallengeResponseStore : IHttpChallengeResponseStore
    {
        private readonly ConcurrentDictionary<string, string> _values
            = new ConcurrentDictionary<string, string>();

        public void AddChallengeResponse(string token, string response)
            => _values.AddOrUpdate(token, response, (_, __) => response);

        public bool TryGetResponse(string token, out string? value)
            => _values.TryGetValue(token, out value);
    }
}
