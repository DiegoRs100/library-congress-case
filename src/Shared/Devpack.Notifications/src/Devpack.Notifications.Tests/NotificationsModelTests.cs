using FluentAssertions;
using System.Net;
using System;
using Xunit;
using System.Collections.Generic;
using Bogus;
using System.Linq;

namespace Devpack.Notifications.Tests
{
    public class NotificationsModelTests
    {
        [Fact(DisplayName = "Deve gerar e separar as lista de notificações quando o construtor for chamado.")]
        [Trait("Category", "Models")]
        public void Constructor()
        {
            var faker = new Faker();
            var field = faker.Random.Word();

            var notifications = new List<Notification>
            {
                new Notification(faker.Random.Words(10), HttpStatusCode.UnprocessableEntity),
                new Notification(Guid.NewGuid().ToString(), field, faker.Random.Words(10), HttpStatusCode.UnprocessableEntity),
                new Notification(Guid.NewGuid().ToString(), field, faker.Random.Words(10), HttpStatusCode.UnprocessableEntity)
            };

            var model = new NotificationsModel(notifications);

            model.Core.Should().BeEquivalentTo(notifications.Take(1));
            model.Fields.Should().HaveCount(1);
            model.Fields[field].Should().BeEquivalentTo(notifications.Skip(1).Take(2));
        }
    }
}