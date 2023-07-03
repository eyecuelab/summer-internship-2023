import NextAuth from "next-auth";
import axios from "axios";
import GoogleProvider from "next-auth/providers/google";

export default NextAuth({
  providers: [
    GoogleProvider({
        clientId: process.env.GOOGLE_CLIENT_ID as string,
        clientSecret: process.env.GOOGLE_CLIENT_SECRET as string,
    }),
  ],
  callbacks: {
    async signIn(user, account, profile) {
      if (account.provider === "google") {
        // You can use the token to call the Google APIs
        const googleIdToken = account.idToken;

        // Here you would make a request to your backend to register/login the user.
        // For example, if you have a 'register' endpoint, you could call it like so:
        const res = await axios.post(
          "http://localhost:7243/api/Users/register",
          {
            // idToken: googleIdToken,
            email: user.email,
            entityId: user.entityId,
          }
        );
      }
    },
  },
});
