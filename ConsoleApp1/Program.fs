// Learn more about F# at http://fsharp.org

open System

// Calculate Calculates the payment for a loan 
// based on constant payments and a constant interest rate
// e.g. mortage payments.
let annuity_immediate(present_value : float, per_term_interest_rate : float, number_of_terms : float) =
    let a_ni = (1.0 - (1.0 + per_term_interest_rate)**(-number_of_terms)) / per_term_interest_rate
    present_value * a_ni

let annuity_due(present_value : float, per_term_interest_rate : float, number_of_terms : float) =
    let effective_rate_of_discount = per_term_interest_rate / (per_term_interest_rate + 1.0)
    let present = (1.0 - (1.0 + per_term_interest_rate)**(-number_of_terms)) / effective_rate_of_discount
    let future = ((1.0 + per_term_interest_rate)**number_of_terms - 1.0) / effective_rate_of_discount
    (present, future)


let get_distance(speed : float, time : float) = speed * time

[<EntryPoint>]
let main argv =
    printfn "PMT: %f" (annuity_immediate(300000.0, 0.004166667, 240.0))
    printfn "The distance is %f" (get_distance(3.0, 2.0))
    let name = "Joseph Choi"
    printfn "My name is %s" name
    Console.ReadLine()
    0 // return an integer exit code
