Important Copilot Instructions

- Do not create new terminals. If an operation fails due to a port conflict or "address already in use" message, this indicates another terminal/process is already running and using the port.
- If you encounter such an error, do NOT attempt to spawn or kill processes yourself. Instead, immediately notify me with the exact error message so I can stop the existing process manually.

## Trusted Publishing Reminder

**CRITICAL: All NuGet package publishing uses Trusted Publishing (OIDC) via GitHub Actions.**
- Never use API keys in workflows or code
- Workflows automatically receive OIDC tokens from GitHub Actions
- Use `${{ secrets.NUGET_PUBLISH_KEY }}` as NUGET_AUTH_TOKEN environment variable for `dotnet nuget push`
- The `NuGet/login@v1` action is NOT compatible with OIDC - use environment variables instead
- For local publishing (not recommended), API keys are NOT stored in the repository

## Release Workflows

When user says "release MudComponent", "release Services", "release Components", or "release Helpers", execute the following workflow:

### Release MudComponent (TheNerdCollective.MudComponents.MudQuillEditor)
1. Bump version in: `src/TheNerdCollective.MudComponents.MudQuillEditor/TheNerdCollective.MudComponents.MudQuillEditor.csproj`
2. Commit: `git commit -m "chore: bump MudQuillEditor to vX.Y.Z - <description>"`
3. Create tag: `git tag -a vX.Y.Z -m "Release vX.Y.Z - <description>"`
4. Push: `git push origin main && git push origin vX.Y.Z`
5. Build: `cd src/TheNerdCollective.MudComponents.MudQuillEditor && dotnet pack -c Release`
6. Publish: `dotnet nuget push bin/Release/TheNerdCollective.MudComponents.X.Y.Z.nupkg --source https://api.nuget.org/v3/index.json` (uses trusted publishing)

### Release Services (TheNerdCollective.Services)
1. Bump version in: `src/TheNerdCollective.Services/TheNerdCollective.Services.csproj`
2. Commit: `git commit -m "chore: bump Services to vX.Y.Z - <description>"`
3. Create tag: `git tag -a services-vX.Y.Z -m "Release vX.Y.Z - <description>"`
4. Push: `git push origin main && git push origin services-vX.Y.Z`
5. Build: `cd src/TheNerdCollective.Services && dotnet pack -c Release`
6. Publish: `dotnet nuget push bin/Release/TheNerdCollective.Services.X.Y.Z.nupkg --source https://api.nuget.org/v3/index.json` (uses trusted publishing)

### Release Components (TheNerdCollective.Components)
1. Bump version in: `src/TheNerdCollective.Components/TheNerdCollective.Components.csproj`
2. Commit: `git commit -m "chore: bump Components to vX.Y.Z - <description>"`
3. Create tag: `git tag -a components-vX.Y.Z -m "Release vX.Y.Z - <description>"`
4. Push: `git push origin main && git push origin components-vX.Y.Z`
5. Build: `cd src/TheNerdCollective.Components && dotnet pack -c Release`
6. Publish: `dotnet nuget push bin/Release/TheNerdCollective.Components.X.Y.Z.nupkg --source https://api.nuget.org/v3/index.json` (uses trusted publishing)

### Release Helpers (TheNerdCollective.Helpers)
1. Bump version in: `src/TheNerdCollective.Helpers/TheNerdCollective.Helpers.csproj`
2. Commit: `git commit -m "chore: bump Helpers to vX.Y.Z - <description>"`
3. Create tag: `git tag -a helpers-vX.Y.Z -m "Release vX.Y.Z - <description>"`
4. Push: `git push origin main && git push origin helpers-vX.Y.Z`
5. Build: `cd src/TheNerdCollective.Helpers && dotnet pack -c Release`
6. Publish: `dotnet nuget push bin/Release/TheNerdCollective.Helpers.X.Y.Z.nupkg --source https://api.nuget.org/v3/index.json` (uses trusted publishing)

**Note:** Replace X.Y.Z with actual version number and <description> with meaningful release description. Always ask user for the version and description if not provided.
