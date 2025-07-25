import { getDiscordUser } from "@/services/discord_service";
import { addUserAsync, existUser, getUserAsync } from "@/services/user_service";
import NextAuth from "next-auth/next";
import DiscordProvider from "next-auth/providers/discord"
const scopes = ['identify'].join(' ')

export const authOptions = 
{
  providers: [
    DiscordProvider({
      clientId: process.env.DISCORD_ID,
      clientSecret: process.env.DISCORD_SECRET,
      authorization: { params: { scope: scopes } },
    }),
  ],
  callbacks: {
    async jwt({ token, account, user }) {
      if (account) {
        token.accessToken = account.access_token;
        token.refreshToken = account.refresh_token;
        token.expiresAt = account.expires_at;
        
        const u = await getDiscordUser(token);

        const responseExist = await existUser(u.loginId);
        

        if(!responseExist.status)
        {
          try
          { 
            const response = await addUserAsync(u);
            token.id = response.id; 
          }
          catch(error)
          {
            console.log(error);
          }
        }
        else
        {
          token.id = responseExist.id;
        }

      }
      return token;
    },
    async session({ session, token }) 
    {
      if(session)
      {
        const response = await getUserAsync(token.id);
        
        if(response.status)
          session.user = response.user;
      }

      return session;
    },
  },
  secret: process.env.NEXTAUTH_SECRET
};

export default NextAuth(authOptions);
