// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Sql.ElasticPool.Cmdlet;
using Microsoft.Azure.Commands.Sql.Test.Utilities;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using Microsoft.Azure.Commands.Sql.ElasticPool.Services;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Adapter;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.UnitTests
{
    public class AzureSqlInstanceUnitTests
    {
        public AzureSqlInstanceUnitTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetInstanceSkuPrefix()
        {
            Assert.Equal(
                "GP",
                AzureSqlManagedInstanceAdapter.GetInstanceSkuPrefix("GeneralPurpose"));
            Assert.Equal(
                "BC",
                AzureSqlManagedInstanceAdapter.GetInstanceSkuPrefix("BusinessCritical"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetHardwareGenerationFromSkuName()
        {
            Assert.Equal(
                "Gen4",
                AzureSqlManagedInstanceAdapter.GetHardwareGenerationFromSkuName("GP_Gen4"));
            Assert.Equal(
                "Gen5",
                AzureSqlManagedInstanceAdapter.GetHardwareGenerationFromSkuName("GP_Gen5"));
            Assert.Equal(
                "Gen4",
                AzureSqlManagedInstanceAdapter.GetHardwareGenerationFromSkuName("BC_Gen4"));
            Assert.Equal(
                "Gen5",
                AzureSqlManagedInstanceAdapter.GetHardwareGenerationFromSkuName("BC_Gen5"));
            Assert.Equal(
                "Gen5_Gen5",
                AzureSqlManagedInstanceAdapter.GetHardwareGenerationFromSkuName("BC_Gen5_Gen5"));
            Assert.Equal(
                "",
                AzureSqlManagedInstanceAdapter.GetHardwareGenerationFromSkuName("BC_"));
            Assert.Null(AzureSqlManagedInstanceAdapter.GetHardwareGenerationFromSkuName("GPGen5"));
            Assert.Null(AzureSqlManagedInstanceAdapter.GetHardwareGenerationFromSkuName("GPGen5"));
            Assert.Null(AzureSqlManagedInstanceAdapter.GetHardwareGenerationFromSkuName(""));
            Assert.Null(AzureSqlManagedInstanceAdapter.GetHardwareGenerationFromSkuName(null));
        }
    }
}
