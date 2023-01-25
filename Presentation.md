---
marp: true
theme: gaia
class:
  - lead
  - invert
---

# Auth

So you want to build a web app with auth?

---

# Why?

- Identity
- Access control

---

# Why

- Identity - **Authentication** - _Who are you?_
- Access control - **Authorization** - _What are you allowed to do?_

---

# History of Auth

Plugging machines together
- same network
- same controllers
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

## OAuth2: Providers

Offload the stress of authenticting





