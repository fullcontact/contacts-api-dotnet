[![NuGet Badge](https://buildstats.info/nuget/FullContact.Contacts.API)](https://www.nuget.org/packages/FullContact.Contacts.API/)
[![Build Status](https://travis-ci.org/fullcontact/contacts-api-dotnet.svg?branch=master)](https://travis-ci.org/fullcontact/contacts-api-dotnet)

.NET SDK for [FullContact Contacts API](https://www.fullcontact.com/apps/docs)

### Installation

`PM> Install-Package FullContact.Contacts.API -Version 1.0.3`

`dotnet add package FullContact.Contacts.API --version 1.0.3`


### Documentation

API Documentation can be found at [https://www.fullcontact.com/apps/docs](https://www.fullcontact.com/apps/docs)

### Usage

##### Getting Started
---

```
using FullContact.Contacts.API;

namespace FullContact.Contacts.API.Example
{
    public class APITest
    {
        ContactsAPIClient client = new ContactsAPIClient("<client_id>", "<client_secret>");
    }
}
```

#### Tests
---

To run tests:

`dotnet test contacts-api-dotnet-tests`
