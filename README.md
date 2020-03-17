# PAAS

## Pun As A Service

Modern Pun Delivery Platform.

## API 

NOTE: _Content will be returned in a JSON format_

### Operations

> /random

- Will return a random pun

### Example Pun Payload

```json
{
  "pun": "I broke my finger today, but on the other hand I was completely fine"
}
```

---

## Potential Future Features

- Pun Twitter/Discord Bot
- Pun of the Day (POTD)
- Increased Pun Library

---

## Setup

To run PAAS locally:

1. Spin up a local mongodb database with the following details:
     - **Database:** PAAS
     - **Collection:** Pun

2. Import **puns.json** into the new Pun Collection.

3. Run the PAAS application and navigate to the /pun endpoint in the browser! *PRESTO*

To run PAAS using an Atlas Mongo Database:

1. Add the mongo atlas instance connection string to the appsettings.java file in the following location:

     - ConnectionStrings -> Atlas

2. Navigate to the startup.cs file and update the service to configure the IMongoCredentialProvider to point to the Atlas class like so:

     - > services.AddScoped<IMongoCredentialProvider, MongoAtlasCredentialProvider>();

3. Assuming puns have been imported to Atlas instance, run the PAAS application and navigate to the /pun endpoint in the browser! *PRESTO*

---

Created by DF (2020).
