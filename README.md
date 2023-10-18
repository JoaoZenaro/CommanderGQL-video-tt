# CommanderGQL

[Video Tutorial](https://youtu.be/HuN94qNwQmM?si=mNJuZ3fPJcKPNMLO)

# GraphQL Requests

## Queries

```graphql
# Simple query to retreive [id, name] from platform
query {
  platform {
    id
    name
  }
}

# Three parallel queries with aliases (a, b, c)
query {
  a: platform {
    id
    name
  }
  b: platform {
    id
    name
  }
  c: platform {
    id
    name
  }
}

# Query with nested fields (commands)
query {
  platform {
    id
    name
    commands {
      id
      howTo
      commandLine
    }
  }
}

# Query with nested fields (platform) in the 'command' type
query {
  command {
    howTo
    commandLine
    platform {
      name
    }
  }
}

# Query with a filter (where)
query {
  command(where: { platformId: { eq: 1 } }) {
    id
    platform {
      name
    }
    commandLine
    howTo
  }
}

# Query with sorting (order)
query {
  platform(order: { name: DESC }) {
    name
  }
}
```

## Mutations

```graphql
# Mutation to add a new platform (and return the added value on success)
mutation {
  addPlatform(input: { name: "Ubuntu" }) {
    platform {
      id
      name
    }
  }
}

# Mutation to add a new command
mutation {
  addCommand(
    input: {
      howTo: "Perform directory listing"
      commandLine: "ls"
      platformId: 5
    }
  ) {
    command {
      id
      howTo
      commandLine
      platform {
        name
      }
    }
  }
}
```

## Extra

```graphql
# Subscription to listen for added platforms
subscription {
  onPlatformAdded {
    id
    name
  }
}
```
