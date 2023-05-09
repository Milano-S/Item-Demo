# Puppy API

An adorable CRUD based API for a fictional puppy adoption agency. Utilised by @harmoney-dev for Frontend Coding
Exercises.

## Installation

Follow the below commands to pull the latest Puppy API image from Github and run on your local machine at port 3000.

```shell
docker pull ghcr.io/mttchpmn/puppyapi:master
```

```shell
docker run -p 3000:80 ghcr.io/mttchpmn/puppyapi:master
```

Note - To run the API on a port other than `3000`, replace the value with a port number of your choosing.

## Usage

The API expects body inputs to be in `application/json` format, and will return all responses in JSON format with standard HTTP status codes.

### Get all puppies

---

#### Example Request

Returns a JSON list of all puppies who are available for adoption.

```shell
curl localhost:3000/puppy
```

#### Example Response

HTTP 200

```json
[
  {
    "key": "849380b1-8507-4ee0-8c42-01884e356c2e",
    "name": "Samuel",
    "age": 1,
    "breed": "Jack Russell",
    "photoUrl": "https://images.unsplash.com/photo-1593134257782-e89567b7718a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
    "adoptionStatus": 0
  },
  {
    "key": "1415dd59-7db0-40fd-ac18-6a14818187e4",
    "name": "Tillie",
    "age": 2,
    "breed": "Collie cross",
    "photoUrl": "https://images.unsplash.com/photo-1601979031925-424e53b6caaa?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80",
    "adoptionStatus": 0
  },
  {
    "key": "5d0c53a5-9dae-41dc-9634-cfa6d641820d",
    "name": "Barnaby",
    "age": 1,
    "breed": "Labrador",
    "photoUrl": "https://images.unsplash.com/photo-1600804340584-c7db2eacf0bf?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80",
    "adoptionStatus": 0
  },
  {
    "key": "f501a943-2f56-4375-9f98-8505751fa28b",
    "name": "Emily",
    "age": 3,
    "breed": "Springer Spaniel",
    "photoUrl": "https://images.unsplash.com/photo-1583511655826-05700d52f4d9?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=688&q=80",
    "adoptionStatus": 0
  }
]
```

### Get a specific puppy

---

Returns a JSON object for a specific puppy with a given key. Returns HTTP 404 if no puppy is found matching the given
key.

```shell
curl localhost:3000/puppy/7d7c1b77-c033-45bb-bb2e-57f760da02f0
```

#### Example Response

HTTP 200

```json
{
  "key": "7d7c1b77-c033-45bb-bb2e-57f760da02f0",
  "name": "Barnaby",
  "age": 1,
  "breed": "Labrador",
  "photoUrl": "https://images.unsplash.com/photo-1600804340584-c7db2eacf0bf?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80",
  "adoptionStatus": 0
}
```

### Add a new puppy

---

Adds a new puppy to the list of available puppies for adoption.

#### Example Request

```shell
curl -XPOST -H "Content-type: application/json" -d '{"name":"Dolly","age":1,"breed":"Border Collie","photoUrl":"https://images.unsplash.com/photo-1508109742312-c7d531211d11?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1740&q=80"}' 'localhost:3000/puppy'
```

#### Example Response

```json
{
  "key": "bdd1c7ee-1e79-4272-b405-188e744b5523",
  "name": "Dolly",
  "age": 1,
  "breed": "Border Collie",
  "photoUrl": "https://images.unsplash.com/photo-1508109742312-c7d531211d11?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1740&q=80",
  "adoptionStatus": 0
}
```

### Update a puppy

---

Updates puppy properties with the provided values. Returns HTTP 404 if no puppy found matching provided key.

#### Example Request

```shell
curl -XPUT -H "Content-type: application/json" -d '{"key": "bdd1c7ee-1e79-4272-b405-188e744b5523","name":"Dolly Barkin","age":1,"breed":"Border Collie","photoUrl":"https://images.unsplash.com/photo-1508109742312-c7d531211d11?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1740&q=80"}' 'localhost:3000/puppy'
```

#### Example Response

```json
{
  "key": "bdd1c7ee-1e79-4272-b405-188e744b5523",
  "name": "Dolly Barkin",
  "age": 1,
  "breed": "Border Collie",
  "photoUrl": "https://images.unsplash.com/photo-1508109742312-c7d531211d11?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1740&q=80",
  "adoptionStatus": 0
}
```

### Set a puppy's status to 'Adopted'

---

Updates a puppy's status to be 'Adopted'. The puppy will then disappear from the available puppies list.  Note, you can't undo this because who un-adopts a puppy?! Returns HTTP 404 if no puppy found matching given key.

#### Example Request

```shell
curl -XPOST 'localhost:3000/puppy/adopt/bdd1c7ee-1e79-4272-b405-188e744b5523'
```

#### Example Response

```json
{
  "key": "bdd1c7ee-1e79-4272-b405-188e744b5523",
  "name": "Dolly Barkin",
  "age": 1,
  "breed": "Border Collie",
  "photoUrl": "https://images.unsplash.com/photo-1508109742312-c7d531211d11?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1740&q=80",
  "adoptionStatus": 1
}
```
