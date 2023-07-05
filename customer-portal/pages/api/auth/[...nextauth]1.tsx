// import NextAuth, { NextAuthOptions } from "next-auth/next";
// import GoogleProvider from "next-auth/providers/google";
// import { PrismaAdapter } from "@auth/prisma-adapter";
// import { PrismaClient } from "@prisma/client";
// import { NextApiHandler } from "next";
// import Adapters from 'next-auth/adapters';
// import Providers from 'next-auth/providers';
// import EmailProvider from "next-auth/providers/email";
// import CredentialsProvider from "next-auth/providers/credentials";

// export const prisma = new PrismaClient();

// const authHandler: NextApiHandler = NextAuth({
//   site: process.env.NEXTAUTH_URL,
//   adapter: PrismaAdapter(prisma),
//   providers: [
//     GoogleProvider({
//       clientId: process.env.GOOGLE_CLIENT_ID as string,
//       clientSecret: process.env.GOOGLE_CLIENT_SECRET as string,
//     }),
//   ],
//   session: {
//     jwt: true,
//     maxAge: 30 * 24 * 60 * 60,
//   },
//   secret: process.env.JWT_SECRET,
//   database: process.env.DATABASE_URL,
// });

// export default authHandler;