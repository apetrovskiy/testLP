#!/bin/sh

rm allure-results/* -y

SOLUTION_NAME=TestLP
ROOT_FOLDER=src
MAIN_PRJ_NAME=LP.Core
MAIN_PRJ_FOLDER="${ROOT_FOLDER}/${MAIN_PRJ_NAME}"
MAIN_PRJ_FILE="${MAIN_PRJ_FOLDER}/${MAIN_PRJ_NAME}.csproj"
TEST_PRJ_NAME=LP.Tests
TEST_PRJ_FOLDER="${ROOT_FOLDER}/${TEST_PRJ_NAME}"
TEST_PRJ_FILE="${TEST_PRJ_FOLDER}/${TEST_PRJ_NAME}.csproj"
TEST_PRJ_TMP_FILE="${TEST_PRJ_FOLDER}/test.tmp"

rm -f "${TEST_PRJ_FILE}"
rm -f "${TEST_PRJ_FOLDER}/Class1.cs"
rm -f "${MAIN_PRJ_FILE}"
rm -f "${MAIN_PRJ_FOLDER}/Class1.cs"
rm -f "${SOLUTION_NAME}.sln"

dotnet new sln --name "${SOLUTION_NAME}"
dotnet new classlib --name "${MAIN_PRJ_NAME}" --framework net7.0 --output "${MAIN_PRJ_FOLDER}"
dotnet new classlib --name "${TEST_PRJ_NAME}" --framework net7.0 --output "${TEST_PRJ_FOLDER}"
dotnet sln add "${MAIN_PRJ_FILE}"
dotnet sln add "${TEST_PRJ_FILE}"
dotnet add "${TEST_PRJ_FILE}" reference "${MAIN_PRJ_FILE}"

rm -f "${TEST_PRJ_FOLDER}/Class1.cs"
rm -f "${MAIN_PRJ_FOLDER}/Class1.cs"

dotnet add "${MAIN_PRJ_FOLDER}" package Stylecop.Analyzers
dotnet add "${TEST_PRJ_FOLDER}" package Stylecop.Analyzers

dotnet add "${TEST_PRJ_FOLDER}" package Microsoft.NET.Test.Sdk
dotnet add "${TEST_PRJ_FOLDER}" package coverlet.collector
dotnet add "${TEST_PRJ_FOLDER}" package NUnit
dotnet add "${TEST_PRJ_FOLDER}" package NUnit3TestAdapter
# dotnet add "${TEST_PRJ_FOLDER}" package NUnit.Allure
# dotnet add "${TEST_PRJ_FOLDER}" package NUnit.Allure.Steps
dotnet add "${TEST_PRJ_FOLDER}" package Allure.Commons
dotnet add "${TEST_PRJ_FOLDER}" package NUnit.Analyzers
dotnet add "${TEST_PRJ_FOLDER}" package SpecFlow
dotnet add "${TEST_PRJ_FOLDER}" package Allure.SpecFlow --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package SpecFlow.NUnit
# experimentally
dotnet add "${TEST_PRJ_FOLDER}" package SpecFlow.NUnit.Runners
#
dotnet add "${TEST_PRJ_FOLDER}" package Selenium.WebDriver
dotnet add "${TEST_PRJ_FOLDER}" package FluentAssertions

##########
# dotnet add "${TEST_PRJ_FOLDER}" package Swashbuckle.AspNetCore
dotnet add "${TEST_PRJ_FOLDER}" package RestSharp
# dotnet add "${TEST_PRJ_FOLDER}" package SpecFlow.Plus.LivingDocPlugin
##########

PROJECT_TAG="</Project>"
ITEM_GROUP="\n  <ItemGroup>\n    <Content Include=\"allureConfig.json\">\n      <CopyToOutputDirectory>Always</CopyToOutputDirectory>\n    </Content>\n  </ItemGroup>\n\n</Project>"

echo "============================="
echo "${ITEM_GROUP}"
echo "============================="
echo "${PROJECT_TAG}"

sed '$d' "${TEST_PRJ_FILE}"
tail -r "${TEST_PRJ_FILE}" | tail -n +3 | tail -r >"${TEST_PRJ_TMP_FILE}"
echo "${ITEM_GROUP}" >>"${TEST_PRJ_TMP_FILE}"
mv "${TEST_PRJ_TMP_FILE}" "${TEST_PRJ_FILE}"

dotnet clean
dotnet restore
# from here: dotnet tool install dotnet-format --version "7.*" --add-source https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet7/nuget/v3/index.json
dotnet tool restore
dotnet format
dotnet build
dotnet test
