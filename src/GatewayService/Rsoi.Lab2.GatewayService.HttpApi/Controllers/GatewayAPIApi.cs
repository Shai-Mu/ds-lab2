using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rsoi.Lab2.GatewayService.HttpApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Rsoi.Lab2.GatewayService.HttpApi.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class LibraryController : ControllerBase
    { 
        /// <summary>
        /// Получить список библиотек в городе
        /// </summary>
        /// <param name="city">Город</param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <response code="200">Список библиотек в городе</response>
        [HttpGet]
        [Route("/api/v1/libraries")]
        [SwaggerOperation("ApiV1LibrariesGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(LibraryPaginationResponse), description: "Список библиотек в городе")]
        public IActionResult ApiV1LibrariesGet([FromQuery][Required()]string city, [FromQuery]decimal? page, [FromQuery][Range(1, 100)]decimal? size)
        { 
            
            // return StatusCode(200, default(LibraryPaginationResponse));
            return Ok();
        }

        /// <summary>
        /// Получить список книг в выбранной библиотеке
        /// </summary>
        /// <param name="libraryUid">UUID библиотеки</param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="showAll"></param>
        /// <response code="200">Список книг библиотеке</response>
        [HttpGet]
        [Route("/api/v1/libraries/{libraryUid}/books")]
        [SwaggerOperation("ApiV1LibrariesLibraryUidBooksGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(LibraryBookPaginationResponse), description: "Список книг библиотеке")]
        public IActionResult ApiV1LibrariesLibraryUidBooksGet([FromRoute][Required]string libraryUid, [FromQuery]decimal? page, [FromQuery][Range(1, 100)]decimal? size, [FromQuery]bool? showAll)
        { 

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(LibraryBookPaginationResponse));
            string exampleJson = null;
            exampleJson = "{\r\n  \"page\" : 1,\r\n  \"pageSize\" : 1,\r\n  \"totalElements\" : 1,\r\n  \"items\" : [ {\r\n    \"bookUid\" : \"f7cdc58f-2caf-4b15-9727-f89dcc629b27\",\r\n    \"name\" : \"Краткий курс C++ в 7 томах\",\r\n    \"author\" : \"Бьерн Страуструп\",\r\n    \"genre\" : \"Научная фантастика\",\r\n    \"condition\" : \"EXCELLENT\",\r\n    \"availableCount\" : 1\r\n  } ]\r\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<LibraryBookPaginationResponse>(exampleJson)
            : default(LibraryBookPaginationResponse);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Получить рейтинг пользователя
        /// </summary>
        /// <param name="xUserName">Имя пользователя</param>
        /// <response code="200">Рейтинг пользователя</response>
        [HttpGet]
        [Route("/api/v1/rating")]
        [SwaggerOperation("ApiV1RatingGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(UserRatingResponse), description: "Рейтинг пользователя")]
        public IActionResult ApiV1RatingGet([FromHeader][Required()]string xUserName)
        { 

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(UserRatingResponse));
            string exampleJson = null;
            exampleJson = "{\r\n  \"stars\" : 75\r\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<UserRatingResponse>(exampleJson)
            : default(UserRatingResponse);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Получить информацию по всем взятым в прокат книгам пользователя
        /// </summary>
        /// <param name="xUserName">Имя пользователя</param>
        /// <response code="200">Информация по всем взятым в прокат книгам</response>
        [HttpGet]
        [Route("/api/v1/reservations")]
        [SwaggerOperation("ApiV1ReservationsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<BookReservationResponse>), description: "Информация по всем взятым в прокат книгам")]
        public IActionResult ApiV1ReservationsGet([FromHeader][Required()]string xUserName)
        { 

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<BookReservationResponse>));
            string exampleJson = null;
            exampleJson = "{\r\n  \"reservationUid\" : \"f464ca3a-fcf7-4e3f-86f0-76c7bba96f72\",\r\n  \"status\" : \"RENTED\",\r\n  \"startDate\" : \"2021-10-09\",\r\n  \"tillDate\" : \"2021-10-11\",\r\n  \"book\" : {\r\n    \"bookUid\" : \"f7cdc58f-2caf-4b15-9727-f89dcc629b27\",\r\n    \"name\" : \"Краткий курс C++ в 7 томах\",\r\n    \"author\" : \"Бьерн Страуструп\",\r\n    \"genre\" : \"Научная фантастика\"\r\n  },\r\n  \"library\" : {\r\n    \"libraryUid\" : \"83575e12-7ce0-48ee-9931-51919ff3c9ee\",\r\n    \"name\" : \"Библиотека имени 7 Непьющих\",\r\n    \"address\" : \"2-я Бауманская ул., д.5, стр.1\",\r\n    \"city\" : \"Москва\"\r\n  }\r\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<BookReservationResponse>>(exampleJson)
            : default(List<BookReservationResponse>);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Взять книгу в библиотеке
        /// </summary>
        /// <param name="xUserName">Имя пользователя</param>
        /// <param name="takeBookRequest"></param>
        /// <response code="200">Информация о бронировании</response>
        /// <response code="400">Ошибка валидации данных</response>
        [HttpPost]
        [Route("/api/v1/reservations")]
        [SwaggerOperation("ApiV1ReservationsPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(TakeBookResponse), description: "Информация о бронировании")]
        [SwaggerResponse(statusCode: 400, type: typeof(ValidationErrorResponse), description: "Ошибка валидации данных")]
        public IActionResult ApiV1ReservationsPost([FromHeader][Required()]string xUserName, [FromBody]TakeBookRequest takeBookRequest)
        { 

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(TakeBookResponse));
            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(ValidationErrorResponse));
            string exampleJson = null;
            exampleJson = "{\r\n  \"reservationUid\" : \"f464ca3a-fcf7-4e3f-86f0-76c7bba96f72\",\r\n  \"status\" : \"RENTED\",\r\n  \"startDate\" : \"2021-10-09\",\r\n  \"tillDate\" : \"2021-10-11\",\r\n  \"book\" : {\r\n    \"bookUid\" : \"f7cdc58f-2caf-4b15-9727-f89dcc629b27\",\r\n    \"name\" : \"Краткий курс C++ в 7 томах\",\r\n    \"author\" : \"Бьерн Страуструп\",\r\n    \"genre\" : \"Научная фантастика\"\r\n  },\r\n  \"library\" : {\r\n    \"libraryUid\" : \"83575e12-7ce0-48ee-9931-51919ff3c9ee\",\r\n    \"name\" : \"Библиотека имени 7 Непьющих\",\r\n    \"address\" : \"2-я Бауманская ул., д.5, стр.1\",\r\n    \"city\" : \"Москва\"\r\n  },\r\n  \"rating\" : {\r\n    \"stars\" : 75\r\n  }\r\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<TakeBookResponse>(exampleJson)
            : default(TakeBookResponse);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Вернуть книгу
        /// </summary>
        /// <param name="reservationUid">UUID бронирования</param>
        /// <param name="xUserName">Имя пользователя</param>
        /// <param name="returnBookRequest"></param>
        /// <response code="204">Книга успешно возвращена</response>
        /// <response code="404">Бронирование не найдено</response>
        [HttpPost]
        [Route("/api/v1/reservations/{reservationUid}/return")]
        [SwaggerOperation("ApiV1ReservationsReservationUidReturnPost")]
        [SwaggerResponse(statusCode: 404, type: typeof(ErrorResponse), description: "Бронирование не найдено")]
        public IActionResult ApiV1ReservationsReservationUidReturnPost([FromRoute][Required]Guid reservationUid, [FromHeader][Required()]string xUserName, [FromBody]ReturnBookRequest returnBookRequest)
        { 

            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);
            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(ErrorResponse));

            throw new NotImplementedException();
        }
    }
}
