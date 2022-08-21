namespace Fable.Remoting.Falco

open Microsoft.AspNetCore.Http

open Falco
open System.IO
open Fable.Remoting.Server
open Newtonsoft.Json
open Fable.Remoting.Server.Proxy

module Remoting =
    let buildHttpHandler (options : RemotingOptions<HttpContext) =
        match options.Implementation with
        | Empty -> fun _ _ -> skipPipeline
        | StaticValue impl -> GiraffeUtil.buildFromImplementation (fun _ -> impl) options
        | FromContext createImplementationFrom -> GiraffeUtil.buildFromImplementation createImplementationFrom options