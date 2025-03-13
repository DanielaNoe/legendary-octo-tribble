import axios from "axios";

const API_BASE_URL = "https://localhost:7005/api";

const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

export default api;
