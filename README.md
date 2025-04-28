# API_Labb3
-------------------------------------------------------------------
request: GET [BaseUrl]/api/Interest/{personId} 
(Gets all interest for a specific person)

response {personId = 1}: 
[
  "Fiska",
  "Läsa böcker",
  "Resa"
]
-------------------------------------------------------------------
request: GET [BaseUrl]/api/Link/person/{personId}
(Gets all links for a specifik person)

response {personId = 1}:
[
  "www.fiske.nu",
  "www.vattendjur.se"
]
-------------------------------------------------------------------
request: GET [BaseUrl]/api/Link/link/{linkId}
(Gets the link with specifik linkId. Used when adding a new link)

response {linkId = 1}:
{
  "id": 1,
  "url": "www.fiske.nu",
  "personInterestId": 1,
  "personInterest": null
}
-------------------------------------------------------------------
request: POST [BaseUrl]/api/Link/{personInterestId}/{url}
(Posts a new link to a specifik persons specific interest)

response {personInterestId = 4}{url = www.djuptvatten.se}:
{
  "id": 16,
  "url": "www.djuptvatten.se",
  "personInterestId": 4
}
-------------------------------------------------------------------
request: GET [BaseUrl]/api/Person
(Gets all persons with interests and links)

response:
[
  {
    "firstName": "Jenny",
    "lastName": "Olandersson",
    "phoneNumber": "076-8400716",
    "interests": [
      {
        "title": "Fiska",
        "links": [
          "www.fiske.nu",
          "www.vattendjur.se"
        ]
      },
      {
        "title": "Läsa böcker",
        "links": []
      },
      {
        "title": "Resa",
        "links": []
      }
    ]
  },
  ...
]
-------------------------------------------------------------------
request: PUT [BaseUrl]/api/Person/{peronId}/{interestIdToAdd}
(Puts a new interest to a specific person)

response {personId = 3}{interestIdToAdd = 3}:
{
  "message": "IntresseId 3 har adderats till personId 3"
}
-------------------------------------------------------------------
