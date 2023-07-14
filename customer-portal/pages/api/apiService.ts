// import axios, { AxiosResponse } from 'axios';

// // You would define an interface for the user based on what data you're working with.
// interface User {
//   name: string;
//   email: string;
// }

// const apiClient = axios.create({
//   baseURL: 'https://localhost:7243/api',
//   headers: {
//     'Content-Type': 'application/json',
//   },
// });

// export const registerUser = async (user: User): Promise<AxiosResponse> => {
//   try {
//     const response = await apiClient.post('/Users/register', user);
//     return response.data;
//   } catch (error) {
//     throw error;
//   }
// };

// export const fetchCurrentRole = async (email: string): Promise<string | object> => {
//   try {
//     const response = await apiClient.get(`/Users/VerifyUser?email=${email}`);
//     return response.data;
//   } catch (error) {
//     throw error;
//   }
// };