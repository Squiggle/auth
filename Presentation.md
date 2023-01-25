---
marp: true
theme: gaia
class:
  - lead
  - invert
---
<style>
section p {
  text-align: left;
}
h2 img { width: 180px; }
</style>

# So you want to build a web app with auth?

---

# About me

Technology Principal, Club Hamilton

**AND Digital**

## ![](images/and_logo.webp)

---

# Why?

AS an employee
I WANT TO view my latest payslip
SO THAT I can know if I can afford a new phone

AS a banking customer
I WANT TO send a payment to my plumber from my phone
SO THAT they will stop chasing that invoice

---

# Why

- Identity - **Authentication** - _Who are you?_
- Access control - **Authorization** - _What are you allowed to do?_

---

# History of Auth

Someone wanted to make two machines talk to each other
- same network
- same owners
- trusted network

However... the Internet is an untrusted network. So how do we verify you are who you claim to be?

---

# We made mistakes

...Like Basic Authentication

Sending username and password in clear text, in the header _on every request_.

```
Authorization: Basic YWRtaW46cGE1NXcwcmQ=
```

👆 base64, decoded reads: `admin:pa55w0rd`

---

# Security on the Internet is hard

- SSL provides a (fairly) secure connection between two points
- **Connections** are still prone to attack (MITM)
- **Content** is still prone to attack (script injection, XSS)
- Security misconfiguration (OWASP A05:2021)

---

# Solution: Don't allow ourselves to make mistaes

Prefer **Authentiction Providers** over creating our own services, or hosting our own auth database.

---

# OAuth2

- Resources
- Clients
- Providers
- Tokens

---

## OAuth2: Resources

The things that we build
- Websites
- REST or GraphQL APIs

---

## OAuth2: Clients

Require access to our resources
- Web browsers
- Mobile apps
- Other hosted services (machine-to-machine)

---

## OAuth2: Providers

Offload the stress of authenticting

![](images/auth_providers.png)

---

## Tokens

aka "Bearer Token": A string which conveys identity or claims on a resource.

Given to the client by the Authentication Provider.

- **access_token** - sent by the client on every request to a private resource
- **id_token** - used by the client to identify the user

---

# Recap

- Authentication: Who are you?
- Authorisation: What are you allowed to do?
- OAuth2: Standard protocol to build trust between
  - Resources
  - Clients
  - Providers

---

# Fetching A Token

_Capturing passwords on our own servers is a security concern_

1. Redirect the client to the Authentication Provider
1. Prompt for login credentials (bonus: 2FA)
1. Redirect back to the client with a token

Tokens will expire, but can be refreshed automatically.

---

# Demo

- Client: Web browser
- Resource: Website
- Provider: Auth0

Technology: C#