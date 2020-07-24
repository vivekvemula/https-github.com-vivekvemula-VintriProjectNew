Task 1: Url: http://localhost:1028/api/beers/1

Details: 
1. Validate the beer id from https://api.punkapi.com/v2/beers/1
2. If the beer id exists then a web page is shown. If the beer id doesn't exist, "Invelid Beer Id" message is shown.
3. User enters name, rating and comments. Name and Rating fileds must be entered.
4. User Name should be email. If not "User name should be email" error is returned.
5. If the rating is not in the range 1-5, "Rating should be 1-5" error is returned.
6. If valid values are entered and create button is clicked, the C:\Temp\database.json is appended with User Name, Rating and Comments.

Task 2: Url : http://localhost:1028/api/beers?beerName=Buzz

Details:
1. Validate if the punk url http://localhost:1028/api/beers?beerName=Buzz.
2. If the list of beers is not null, create Json out.
** I couldn't figure out how to sort the json out put.
** LINQ query always returns the duplicate records if I join the Beers with Ratings dataset.
So I used a class BeerRatings to achieve the objective.
[{
	"userRatings": [{
		"UserName": "Vemula1@test.com",
		"Rating": 3,
		"Comments": "Test"
	}, {
		"UserName": "vivek@test.com",
		"Rating": 3,
		"Comments": "comments"
	}, {
		"UserName": "john@test.com",
		"Rating": 5,
		"Comments": "test"
	}],
	"Id": 1,
	"name": "Buzz",
	"description": "A light, crisp and bitter IPA brewed with English and American hops. A small batch brewed only once."
}]

Task 3: Validations are explained above

Task 4: Created a xUnit project and tested one url.
