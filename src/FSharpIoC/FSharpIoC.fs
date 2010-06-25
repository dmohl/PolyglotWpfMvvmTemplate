namespace FSharpIoC

open System
open System.Collections.Generic
open System.Reflection

module FSharpIoCModule = 
    let ResolveType requestedType (typeContainer:Dictionary<Type,Type>) =
        typeContainer.[requestedType]
    let FindMostComplexConstructor (newType:Type) =
        let constructors = newType.GetConstructors() 
                           |> Array.sortBy (fun c -> c.GetParameters().Length) 
                           |> Array.rev
        constructors.[0]
    let rec Resolve requestedType (typeContainer:Dictionary<Type,Type>) =
        let newType = ResolveType requestedType typeContainer
        let theConstructor = newType |> FindMostComplexConstructor
        match theConstructor.GetParameters() with
        | cstorParams when cstorParams.Length = 0 -> Activator.CreateInstance(newType)
        | cstorParams -> cstorParams 
                         |> Seq.map(fun (paramInfo:ParameterInfo) -> 
                                (Resolve paramInfo.ParameterType typeContainer)) 
                         |> Seq.toArray 
                         |> theConstructor.Invoke

type Container =
    val typeContainer : Dictionary<Type, Type>
    new () = {typeContainer = new Dictionary<Type, Type>()}
    member x.Register<'a,'b> () =        
        x.typeContainer.Add(typeof<'a>, typeof<'b>)
    member x.Resolve(requestedType) =
        FSharpIoCModule.Resolve requestedType x.typeContainer
    member x.Resolve<'a> () =
        FSharpIoCModule.Resolve typeof<'a> x.typeContainer :?> 'a


module IoC =
    let GetIoC = new Container()