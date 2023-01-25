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
h2 img { height: 240px; margin: 2em; }
</style>

# So you want to build a web app with auth?

---

# About me

Technology Principal, Club Hamilton

**AND Digital**

## ![](images/and_logo.webp) ![](images/me.jpg)

---

# Why?

AS an employee
I WANT TO view my latest payslip
SO THAT I can know if I can afford a new phone

AS a banking customer
I WANT TO send a payment to my plumber from my phone
SO THAT they will stop chasing that invoice

---

# Auth?

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

# Enter OAuth2

Formalises the concepts of
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

A string which conveys **identity to the client** or **claims over a resource**.

Given to the client by the **Authentication Provider**.

- **access_token** - sent by the client on every request to access a resource
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

1. Client accesses a secure Resource
1. Client is redirected to the Authentication Provider
1. Prompt for login credentials if not already known
1. Redirect back to the Client with a Token

---

# Demo

- Client: Web browser
- Resource: Website
- Provider: Auth0

Technology: C#

---

# Recap - Auth Flow


Authentication Provider **manages users**

Authentication Provider knows about the Resource
The Resource knows about Authentication Provider

The Client is issued a Token

---

# Into the Code

- The default `/` route demands authentication using `[Authorize]`
- The `/Account/Login` route which constructs the challenge and managers redirects
- Auth is **middleware** - it enforces auth against any route decorated with `[Authorize]`

---

# Further reading

This demonstration used *Implicit Flow*.

There are [many other types of auth flow](https://auth0.com/docs/get-started/authentication-and-authorization-flow)

- Authorization Flow, for web auth with multiple resources
- Authorization Flow with PKCE, adding another layer of security
- Hybrid Flow, a simpler flow for trusted clients
- Device Authorization flow, useful for command line apps
- Client Credentials, for machine-to-machine auth
- ~~Resource Owner Password Flow~~

---

# Q&A

---

# Thank you

Code and slides: https://github.com/Squiggle/auth

Auth0: https://auth0.com/

aspnet minimal APIs: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis
