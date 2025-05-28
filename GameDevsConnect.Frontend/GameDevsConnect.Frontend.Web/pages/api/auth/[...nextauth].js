import axios from "axios";
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
        token.expiresAt = account.expires_at * 1;

        // await addDiscordUser(token);
        
        // token.id = user?.id;

        // name: 'benexdrake.net',
        // email: 'benex@hotmail.de',
        // picture: 'https://cdn.discordapp.com/avatars/248882444005015552/ca607040d42518b2c1fe76819b0b3d79.png',
        // sub: '248882444005015552',
        // accessToken: 'mvrzosjK6037Boac0oSwTVLalGlLEb',
        // refreshToken: 'PxXHzwpT5WfpodGYYCT4SV5zjIxqZH',
        // expiresAt: 1748272013000
        console.log('JWT', token);

        // Senden des token Objects an das Gateway zum speichern des Users, aber auch speichern des accessToken
        // Somit kann jede weitere API mit dem AccessToken angesteuert werden.
        
      }
      return token;
    },
    async session({ session, token }) 
    {
      try 
      {

        console.log('SESSION', token.name);
        
        // const user = await getUser(token)
        // session.user = user;
        session.accessToken = token.accessToken;
      } 
      catch (error) 
      {
        console.error("Error fetching Discord user:", error);
        session.user = null;
      }
      return session;
    },
  },
  secret: process.env.NEXTAUTH_SECRET
};


export default NextAuth(authOptions);
