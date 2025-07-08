import type { NextConfig } from "next";

const nextConfig: NextConfig = 
{
  productionBrowserSourceMaps: false,
  webpack(config, { dev, isServer }) {
    if (dev && !isServer) {
      config.devtool = false;
    }
    return config;
  },
  reactStrictMode: true,
};

export default nextConfig;
