# Basis-Image
FROM node:23-alpine AS base

WORKDIR /app

# Nur package.json & package-lock.json für Layer-Cache bei Abhängigkeiten
COPY package*.json ./

RUN npm ci

# Alles andere danach (wird häufiger geändert, invalidiert Cache)
COPY . .

RUN npm run build

# Finales Image
FROM node:23-alpine AS final

WORKDIR /app

COPY --from=base /app/.next .next
COPY --from=base /app/package*.json ./
COPY --from=base /app/public ./public
COPY --from=base /app/node_modules ./node_modules

CMD ["npm", "start"]
