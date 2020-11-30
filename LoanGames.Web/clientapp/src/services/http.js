import axios from 'axios';
import { baseApiUrl } from "@/global";

  
const client = axios.create({
  baseURL: baseApiUrl,
  timeout: 1000,
});

export default client; 