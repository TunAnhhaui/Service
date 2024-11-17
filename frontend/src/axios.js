import axios from "axios";
import store from "./store/store";
import { jwtDecode } from "jwt-decode";

axios.defaults.baseURL = "https://localhost:7224/";

axios.defaults.withCredentials = true;

axios.interceptors.request.use(
  function (config) {
    const token = store.state.user?.token;
    if (token) {
      const decodedToken = jwtDecode(token);
      const currentTime = Date.now() / 1000;
      if (currentTime > decodedToken.exp) {
        store.commit("LOGOUT");
      }
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  function (error) {
    return Promise.reject(error);
  }
);

export default axios;
