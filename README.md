# InfoTrack Development Project - README

## Overview

This project automates the process of finding and displaying rankings for the company InfoTrack on Google search results. The application takes a search phrase and a target URL, scrapes Google for the top 100 results, and identifies the rankings where the URL appears. The results are displayed in a user-friendly web interface.

## The solution is built using:

Backend: ASP.NET Core Web API
Frontend: React.js

## Features

- Keyword and URL Input: Users can input search phrases and a URL to search.
- Google Scraper: Scrapes Google search results without using third-party libraries or APIs.
- Rankings Display: Shows the positions where the URL appears in search results.
- Enhanced User Experience: Includes an animated spinner during searches and error handling for failed requests.

## Prerequisites

- .NET 8
- C# 12
- Node.js and npm (for React)

CORS is configured in the backend to allow requests from the React frontend running on `http://localhost:3000`. Ensure no issues arise by using the same ports specified in this README.

It's best to open a separate terminal for both the backend and the frontend.

1. Clone the Repository:

```
git clone https://github.com/saksunyoung/InfoTrackSearch.git
cd InfoTrackSearch
```

2. Backend Setup:
   
From the InfoTrackSearch Folder:

```
cd Backend
dotnet restore
dotnet build
dotnet run
```

3. Frontend Setup:
   
From the InfoTrackSearch Folder:

```
cd Frontend
npm install
npm start
```

## Application Features

1. Input Form:

- Accepts a search phrase and a target URL.
- Submits the input to the backend API.

2. Google Search Scraper:

- Scrapes the first 100 search results for the input phrase.
- Identifies the positions of the specified URL.

3. Results Display:

- Displays the rankings as a list.
- Links to the identified search results.

4. Error Handling:

- Provides meaningful error messages for user feedback.

## To Test:

1. Start the backend API.
2. Start the React frontend.
3. Enter a search phrase (`"land registry searches"`) and URL (`"https://www.infotrack.co.uk/"`) in the form.
4. Click "Get Rankings" to view the results.
5. Click one of the results to view the page.

## Future Enhancements

- Track historical ranking trends.
- Extend functionality to support additional search engines.
- Improve UI/UX design for better user interaction.
- The backend scraper is temperamental—this seems to be due to Google's anti-scraping mechanism. This could be remedied by implementing strategies such as rotating IP addresses, using headless browsers like Puppeteer or Playwright to mimic human behaviour or introducing delays between requests.
