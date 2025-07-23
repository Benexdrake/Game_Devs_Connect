# Chapter 2: Frontend Web Application

Welcome back, aspiring game developers! In [Chapter 1: API Communication & Data Models](01_api_communication___data_models_.md), we learned how different parts of `Game Devs Connect` talk to each other, using "menus" (APIs) and "recipes" (Data Models) to understand what information looks like.

Now, let's talk about the part of `Game Devs Connect` that you, the user, will see and interact with directly. This is the **Frontend Web Application**.

### What Problem Does It Solve?

Imagine `Game Devs Connect` is a bustling city. The APIs and Data Models we discussed are like the roads and the agreed-upon rules for delivering goods between different buildings. But what about the actual buildings themselves, where people work and visit? What about the public spaces like parks, dashboards, or public notice boards?

That's where the Frontend Web Application comes in! It's the **visual "face"** of `Game Devs Connect`. It's the part that:
*   **Displays information** (like posts, user profiles, or quest details).
*   **Allows you to interact** (by clicking buttons, typing messages, or uploading files).

Without a Frontend, `Game Devs Connect` would be just a bunch of computers talking to each other, but no way for *you* to join the conversation!

**Our Central Use Case:** Let's stick with our example from Chapter 1. You want to open `Game Devs Connect` in your web browser and **browse exciting posts** from other game developers. The Frontend is what makes this happen, presenting the posts clearly and letting you scroll through them.

### What is a Frontend Web Application?

The "Frontend" is simply **everything you see and interact with** when you use a website or application.
*   When you visit `Game Devs Connect`, all the buttons, text, images, and forms you see are part of the Frontend.
*   Think of it like the **dashboard of a car**. You see the speedometer, the fuel gauge, and buttons to turn on the radio or air conditioning. You interact with these controls to make the car do things. You don't see the engine or the fuel tank, just the controls.
*   For `Game Devs Connect`, our Frontend is built using a powerful tool called **Next.js**. Next.js helps us create a fast and interactive website that looks good and works smoothly.

### How Does It Help You Browse Posts?

When you visit `Game Devs Connect` (for example, `https://gamedevsconnect.com`), your web browser loads the main page. This main page is specifically designed to show you a list of posts.

Let's look at a simplified version of the code that handles this:

```typescript
// GameDevsConnect.Frontend/GameDevsConnect.Frontend.Web/pages/index.tsx

import InfiniteScrollPosts from "@/components/infinite_scroll_posts";
import { getPostIdsAsync } from "@/services/post_service";

// This is the main page you see when you visit Game Devs Connect
export default function Home({ids}: {ids:string[]}) 
{
  // This component displays many posts and loads more as you scroll
  return (
    <InfiniteScrollPosts initialIds={ids} search="" parentId=""/>
  )
}
```

**What this code does:**
*   This piece of code (`pages/index.tsx`) defines the "Home" page of our application.
*   When you visit the website's main address (`/`), Next.js uses this `Home` component to build what you see.
*   The `<InfiniteScrollPosts />` part is a special helper that takes a list of `ids` (unique identifiers for posts) and displays the posts. It's smart enough to load more posts automatically as you scroll down the page, so you don't have to click "next page."

But where do those initial `ids` come from? They come from a special function that runs *before* the page is shown to you:

```typescript
// Part of: GameDevsConnect.Frontend/GameDevsConnect.Frontend.Web/pages/index.tsx

// This function runs on the server BEFORE the page is shown to you.
// It helps fetch the first set of post IDs from the Backend.
export async function getServerSideProps()
{
  const response = await getPostIdsAsync(); // Ask for post IDs from the Backend

  return {
    props: {
      ids: response.ids || [] // Pass the IDs to the Home component
    }
  }
}
```

**How it works:**
1.  When your browser asks for the `Game Devs Connect` homepage, Next.js first runs `getServerSideProps` on the server.
2.  `getServerSideProps` then asks our "Backend" (the hidden "departments" we talked about in [API Communication & Data Models](01_api_communication___data_models_.md) and will cover more in [Backend Microservices](04_backend_microservices_.md)) for the latest post IDs using `getPostIdsAsync`.
3.  Once it gets the IDs, it passes them to the `Home` component.
4.  Finally, the `Home` component uses the `InfiniteScrollPosts` feature to display the posts to you.

This ensures that when you first load the page, you immediately see some posts without having to wait for them to load separately.

### What Happens "Under the Hood"?

Let's trace the journey from you opening your browser to seeing posts on `Game Devs Connect`:

```mermaid
sequenceDiagram
    participant User
    participant Browser
    participant Frontend (Next.js)
    participant Backend (API)

    User->>Browser: Types GameDevsConnect.com in address bar
    Browser->>Frontend (Next.js): Request homepage
    Note over Frontend (Next.js): Runs getServerSideProps
    Frontend (Next.js)->>Backend (API): Request initial Post IDs
    Backend (API)-->>Frontend (Next.js): Sends a list of Post IDs
    Frontend (Next.js)-->>Browser: Sends the prepared homepage content
    Browser->>User: Displays initial posts
    Note over Browser: User scrolls down the page
    Browser->>Frontend (Next.js): Request more Post IDs (via InfiniteScrollPosts)
    Frontend (Next.js)->>Backend (API): Request more Post IDs
    Backend (API)-->>Frontend (Next.js): Sends more Post IDs
    Frontend (Next.js)-->>Browser: Sends updated page content
    Browser->>User: Displays more posts
```

This diagram shows how the Frontend acts as a middleman, taking your requests, talking to the Backend (which stores all the actual data), and then presenting the information back to you in a friendly way. The communication between the Frontend and Backend happens using the rules we learned in [API Communication & Data Models](01_api_communication___data_models_.md).

#### The Application's Foundation (`_app.tsx` and `layout.tsx`)

Every application needs a foundation. In `Game Devs Connect`, all our web pages share a common structure and functionality, defined in a couple of important files:

*   **`pages/_app.tsx`**: This file is the "root" of our web application. Think of it as the main entrance that *every* visitor passes through. It wraps all our individual pages (like the Home page, Login page, etc.) with common features.

    ```typescript
    // GameDevsConnect.Frontend/GameDevsConnect.Frontend.Web/pages/_app.tsx

    import Layout from "@/components/layout";
    import { SessionProvider } from "next-auth/react"; // For login info
    import type { AppProps } from "next/app";

    // This file is like the main entry point for our web application.
    export default function App({ Component, pageProps }: AppProps) 
    {
      return (
        // SessionProvider helps manage who is logged in (more in Chapter 3)
        <SessionProvider session={pageProps.session}>
          {/* Layout provides a common header, sidebar, etc., for all pages */}
          <Layout>
            {/* Component is the actual page being shown (e.g., Home, Login) */}
            <Component {...pageProps} />
          </Layout>
        </SessionProvider>
      )
    }
    ```
    **Explanation:** The `_app.tsx` file ensures that all pages benefit from a consistent `Layout` (like a consistent frame around all pictures) and can access user session information (e.g., whether you're logged in or not, which is crucial for the [Authentication System](03_authentication_system_.md)).

*   **`components/layout.tsx`**: This component defines the overall visual structure of our website, like where the navigation bar goes, where the main content appears, and so on.

    ```typescript
    // GameDevsConnect.Frontend/GameDevsConnect.Frontend.Web/components/layout.tsx

    import styles from '@/styles/layout.module.css'
    import Navbar from "./nav/navbar";
    import { useSession } from 'next-auth/react'; // For user login check

    // This component sets up the general structure for our website.
    export default function Layout({children}:{children:any})
    {
        const {data:session} = useSession(); // Checks if a user is logged in

        return (
            <div className={styles.main}>
                <nav className={styles.sidebar}>
                    {/* Only show navigation if a user is logged in */}
                    {session && <Navbar/>}
                </nav>
                <div className={styles.child}>
                    {/* This is where the actual page content goes */}
                    {children}
                </div>
            </div>
        )
    }
    ```
    **Explanation:** This code defines our website's main structure. It creates a `sidebar` (where a navigation bar might be) and a `child` area where the actual content of each page (like the list of posts) will be placed. Notice how it checks if a user is `session` (logged in) before showing the `Navbar`.

#### Packaging the Frontend (`Dockerfile`)

Finally, how do we get this Frontend application ready to run on a server so everyone can access it? We use something called a `Dockerfile`. Think of a `Dockerfile` as a recipe for baking a cake:

```dockerfile
# GameDevsConnect.Frontend/GameDevsConnect.Frontend.Web/Dockerfile

# Stage 1: Build the application (like mixing ingredients and baking)
FROM node:23-alpine AS base
WORKDIR /app
COPY package.json .
COPY package-lock.json .
RUN npm ci # Install project dependencies
COPY . .    # Copy all source code
RUN npm run build # Prepare the Next.js application for deployment

# Stage 2: Create a smaller, final image for running (like packaging the finished cake)
FROM node:23-alpine AS final
WORKDIR /app
# Copy only the necessary built files and dependencies
COPY --from=base /app/.next .next
COPY --from=base /app/package.json .
COPY --from=base /app/package-lock.json .
COPY --from=base /app/public ./public
COPY --from=base /app/node_modules ./node_modules
CMD ["npm", "start"] # Command to start the application
```
**Explanation:** This recipe tells a special tool (Docker) how to:
1.  **Build** our Next.js application: It starts with a base "Node.js" environment, copies our code, installs necessary parts, and then "builds" the website (Stage 1).
2.  **Package** the ready-to-run application: It then takes only the essential parts of the built application and puts them into a smaller, cleaner package (Stage 2). This package is called a "container," which makes our application easy to run anywhere. We will learn more about this in [Containerization (Docker)](08_containerization__docker__.md).

### Conclusion

In this chapter, we learned that the **Frontend Web Application** is the part of `Game Devs Connect` that you see and interact with directly in your browser. It's built using **Next.js** and acts as your personal "control panel" to browse posts, manage your profile, and more. We saw how it uses pages like `index.tsx` to display content, how `_app.tsx` and `layout.tsx` provide a consistent structure, and how a `Dockerfile` prepares it for deployment.

However, before you can start browsing posts or managing your profile, `Game Devs Connect` needs to know *who you are*. This leads us to our next important topic: the **Authentication System**.

[Next Chapter: Authentication System](03_authentication_system_.md)