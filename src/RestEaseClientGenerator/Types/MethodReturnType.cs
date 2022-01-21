using System.ComponentModel;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Types;

/// <summary>
/// See also https://github.com/canton7/RestEase#return-types
/// </summary>
[TypeConverter(typeof(EnumDescriptionConverter))]
public enum MethodReturnType
{
    /// <summary>
    /// The method returns a typed object
    /// </summary>
    [Description("T")]
    Type,

    /// <summary>
    /// The method returns the raw response, as a string.
    /// </summary>
    [Description("string")]
    String,

    /// <summary>
    /// The method returns the raw HttpResponseMessage resulting from the request. It does not do any deserialization. You must dispose this object after use.
    /// </summary>
    [Description("HttpResponseMessage")]
    HttpResponseMessage,

    /// <summary>
    /// The method returns a Response{T}. A Response{T{>} contains both the deserialized response (of type T), but also the HttpResponseMessage. Use this when you want to have both the deserialized response, and access to things like the response headers. You must dispose this object after use.
    /// </summary>
    [Description("Response<T>")]
    Response,

    /// <summary>
    /// The method returns a Stream containing the response. Use this to e.g. download a file and stream it to disk. You must dispose this object after use.
    /// </summary>
    [Description("Stream")]
    Stream
}