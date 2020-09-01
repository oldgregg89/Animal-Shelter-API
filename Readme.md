<h1 align="center"><strong>

# _Animal Shelter API_ 
</strong></h1>
![Robert-E-Kahn](https://media.giphy.com/media/9Y1uuCxj8AWiC4FjOc/giphy.gif)

#### A practice in creating APIs within C# & .Net through an example of a database for an animal shelter._ , 2020 ver 1.0.0_

#### By _Ian Gregg_
[Animal-Shelter](https://github.com/oldgregg89/Animal-Shelter-API)

## Description

_A practice in creating APIs within C# & .Net through an example of a database for an animal shelter._

## Setup/Installation Requirements

* to clone this content, copy the url provided by the `clone or download` button in GitHub
* in command line use the command 'git clone (GitHub url)'
* open the program in a code editor
* you will need [.NET] (https://dotnet.microsoft.com/download/dotnet-core/2.2) installed to run this program 
* then install dotnet script REPL by typing `dotnet tool install -g dotnet-script` in the command line
* type dotnet build in the command line to compile the code
* create a `.gitignore` file and store the bin and obj folders in .gitignore
* type `dotnet watch run` in the command line to run the program
* run `dotnet add package Microsoft.EntityFrameworkCore -v 2.2.0`  &
`dotnet add package Pomelo.EntityFrameworkCore.MySql -v 2.2.0`
in the terminal
* add a file called `appsetting.json` in the HairSalon directory.
* in `appsetting.json` add: 
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=(port#);database=(DB name);uid=root;pwd=(password);"
  }
}
```
* fill in your `server`, `port`,`database`,`uid`, and `pwd`
* Make suere to have your `MySQLWorkbench` open
* run 
`dotnet ef migrations add Initial`
then `dotnet ef database update`

## HTTP Request

```
GET /api/
POST /api/animal
GET /api/animal/{id}
PUT /api/animal/{id}
DELETE /api/animal/{id}
```

## Example Query

```
http://localhost:5000/api/Animals/
```


## Sample JSON Response 

```
  {
    "animalId": 1,
    "name": "A dog",
    "breed": "something",
    "age": 2,
    "gender": "male"
  }
```

## Pagination 

This Application programming interface includes pagination which allows the developer to customize and mark up the displayed information of database as they see fit. Its currently set at 10 entries per 1 page under the `UrlQuery.cs` file under `Models`. 

Example below: 
```
...
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public UrlQuery()
        {
   ---->    this.PageNumber = 1;   <-------//This can change the page number
   ---->    this.PageSize = 10;    <-------//This can change the number of records shown on the page
        }

        public UrlQuery(int pageNumber, int pageSize)
        {
   ---->     this.PageNumber = pageNumber < 1 ? 1 : pageNumber;     <-------//Set starting page on the database 
   ---->     this.PageSize = pageSize > 10 ? 10 : pageSize;         <-------//Sets the number of records viewed on each page
        }
    }
 ...
 ```
 The developer can set page number with `this.Pagenumber` along with the how many data entries can be shown through the `this.PageSize` (as shown above).


## Known Bugs

_No known bugs_

## Support and contact details

_Contact Ian Gregg: <iangregg188@gmail.com>_

## Technologies Used

_The Technologies used in the making of this software was Chrome browser, Visual Studio editor, and Mac, C#, .Net, Authentication with Identity, MySQL, pagination_

### License

Copyright (c) 2020 **_Ian Gregg_**

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

## Remember you can always reach out to the editors if this doesn't make sense.
![Monkey reading](https://media.giphy.com/media/SiMcadhDEZDm93GmTL/giphy.gif)
</h1>
