import React, { useState } from "react";
import axios from "axios";
import "./App.css";

const App = () => {
  const [keywords, setKeywords] = useState("");
  const [urlToFind, setUrlToFind] = useState("");
  const [rankings, setRankings] = useState([]);
  const [resultUrls, setResultUrls] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState("");
  const [hasSearched, setHasSearched] = useState(false);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setIsLoading(true);
    setError("");
    setRankings([]);
    setResultUrls([]);
    setHasSearched(true);

    try {
      const response = await axios.post("https://localhost:7250/api/search", {
        keywords,
        urlToFind,
      });

      if (response.data ) {
        if(response.data.rankings){
        setRankings(response.data.rankings);
        }
        if(response.data.resultUrls){
        setResultUrls(response.data.resultUrls);
        }
      } else {
        setError("No data returned");
      }
    } catch (error) {
      setError("An error occurred while fetching the rankings");
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="App">
      <h1>Google Search Rankings</h1>
      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="searchPhrase">Search Phrase:</label>
          <input
            type="text"
            id="searchPhrase"
            value={keywords}
            onChange={(e) => setKeywords(e.target.value)}
            placeholder="Enter search phrase"
            required
          />
        </div>

        <div>
          <label htmlFor="searchUrl">Company URL:</label>
          <input
            type="url"
            id="searchUrl"
            value={urlToFind}
            onChange={(e) => setUrlToFind(e.target.value)}
            placeholder="Enter URL"
            required
          />
        </div>

        <button type="submit" disabled={isLoading}>
          {isLoading ? "Fetching..." : "Get Rankings"}
        </button>
      </form>

      {error && <div className="error">{error}</div>}

      {rankings.length > 0 && (
        <div>
          <h2>Ranking Positions</h2>
          <ul>
            {rankings.map((rank, index) => (
              <li key={index}>Position {rank}: <a href={resultUrls[index]} >{resultUrls[index]}</a></li>
            ))}
          </ul>
        </div>
      )}

      {hasSearched && !isLoading && rankings.length === 0 &&<div>No results found. Please try again.</div>}
    </div>
  );
};

export default App;
