using FwksLab.Libs.AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace FwksLab.Libs.AspNetCore.Attributes;

public sealed class AppProblemResponseAttribute(int statusCode) : ProducesResponseTypeAttribute(typeof(AppProblem), statusCode);