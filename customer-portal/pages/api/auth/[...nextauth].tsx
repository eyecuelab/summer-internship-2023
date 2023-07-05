import NextAuth from "next-auth/next";
import GoogleProvider from "next-auth/providers/google";
import { NextApiHandler } from "next";

const authHandler: NextApiHandler = NextAuth({
  providers: [
    GoogleProvider({
      clientId: process.env.GOOGLE_CLIENT_ID as string,
      clientSecret: process.env.GOOGLE_CLIENT_SECRET as string,
    }),
  ],
  secret: process.env.JWT_SECRET,
});

export default authHandler;
