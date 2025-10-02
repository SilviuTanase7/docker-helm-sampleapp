# 🚀 Docker Helm Sample App

This repository contains a sample **.NET application** packaged with **Docker**, deployed using **Helm**.  
The project is integrated with an **Azure DevOps CI/CD pipeline** for automated build, scan, sign, and deploy.

---

## 📦 Features
- .NET Core application
- Dockerized build and runtime
- Vulnerability scanning with **grype**
- Code quality checks via **SonarQube**
- Helm chart for Kubernetes deployment
- CI/CD pipeline with **Azure DevOps**

---

## 🛠 Prerequisites
To work with this repo locally, you’ll need:

- [.NET SDK](https://dotnet.microsoft.com/download) (7.0)
- [Docker](https://www.docker.com/)
- [Helm](https://helm.sh/)
- [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli) (for ACR login)

---

## ⚡ Build and Run Locally

```bash
# Restore packages
dotnet restore

# Build solution
dotnet build

# Run tests (if any)
dotnet test

# Build Docker image
docker build -t sampleapp .

# Run container
docker run -p 8080:80 sampleapp


---

## ⚡ Plan for myself

Fail fast: run cheap/quick checks first (linters, type checks, unit tests) so obvious issues stop the run early.
Expensive tests later: run integration/e2e, DAST, long performance tests after basic quality gates pass.

Static analysis & code quality
Linters & formatters: ESLint/Prettier, flake8/black, rubocop — enforce style and avoid trivial failures. - dotnet format whitespace --verify-no-changes / dotnet format analyzers
Type checks: mypy / TypeScript tsc to catch type errors before runtime. - not the case
SAST Static Application Security Testing/ code-quality scanners: SonarQube, CodeQL — detect code smells, security hotspots and complexity metrics. - SonarQube added and tested
Pre-commit hooks: run linters/formatters locally with Husky/pre-commit to reduce pipeline failures. - Add pre-commit locally for developers → reduces pipeline failures and shortens feedback loop.

Unit tests (details to mention)
Fast, isolated, deterministic: mock external I/O; keep unit tests small and <100ms–1s ideally. - Xunit, FluentAssertions & Moq
Test pyramid: many unit tests, less integration tests, fewer E2E tests. 
Parallelize: run unit tests in parallel or sharded to reduce wall clock time. - just tried
Coverage thresholds: enforce minimum coverage (e.g., 70–80%) but avoid gaming the metric — pair with meaningful tests. - not the case
Flaky tests: quarantine flaky tests, add retries judiciously, fix root causes; track flakiness metric. - not the case

Recommandation: Unit Tests Test pyramid: many unit tests, fewer integration tests, fewer E2E tests.

Dependency & vulnerability scanning
Dependency scanning: Dependabot, Renovate, npm audit, pip-audit, Snyk — detect vulnerable libraries early.
Container/image scanning: Trivy, Clair, Azure Defender for Container Registries — scan images before push/publish.
SBOM: generate Software Bill of Materials for each build (helpful for audits & quick vuln lookup). - tried with Cyclone but got issued with .Net 7, saw some SBOM json results locally
Pinning & CVSS gating: pin or limit auto-upgrades; optionally block deploys for CVEs above threshold. - no block included

Secrets & credentials
Secrets management: never store secrets in repo. Use Azure Key Vault / HashiCorp Vault / managed identities.
Scan for secrets: truffleHog/git-secrets in CI and pre-commit. - tried truffleHog 
Least privilege: service principals & identities scoped to only needed resources; rotate creds. - only service principals

Infrastructure as Code (IaC) safety
IaC scanners: Checkov, tfsec, terrascan to find insecure patterns (open security groups, permissive IAM). - Checkov reports
Policy as code: OPA/Gatekeeper or Azure Policy to enforce rules in cluster/cloud (deny-by-default). - not the case
Plan checks: require terraform plan review and automated drift detection. - Plan review Gate & helm diff

Build & artifact management
Immutable artifacts: tag artifacts with build id/commit SHA; store in artifact registry (ACR, Artifacts feed). - OCI standard included
Artifact signing & provenance: Cosign/Notary for image signing and provenance. - tried with Cosing on both keyless/key methods
Retention & cleanup: automated cleanup policies (keep last N, remove untagged manifests).
