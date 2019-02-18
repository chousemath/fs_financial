open System

// Calculate Calculates the payment for a loan 
// based on constant payments and a constant interest rate
// e.g. mortage payments.
let annuity_immediate(present_value : float, per_term_interest_rate : float, number_of_terms : float) =
    let a_ni = (1.0 - (1.0 + per_term_interest_rate)**(-number_of_terms)) / per_term_interest_rate
    present_value * a_ni

let annuity_due(present_value : float, per_term_interest_rate : float, number_of_terms : float) =
    ((1.0 + per_term_interest_rate)**number_of_terms) * annuity_immediate(present_value, per_term_interest_rate, number_of_terms)


let get_distance(speed : float, time : float) = speed * time

// amortization means making periodic payments over time to pay off debt
let ammortized_monthly_payment(principal : float, interest_rate : float, number_of_periods : int, payments_per_period : int) =
    let numerator = principal * interest_rate / float(payments_per_period)
    let denominator = (1.0-(1.0+interest_rate/float(payments_per_period))**(float(-payments_per_period * number_of_periods)))
    numerator / denominator

let simple_interest(principal : float, interest_rate : float, number_of_periods : int) =
    principal * interest_rate * float(number_of_periods)

[<EntryPoint>]
let main argv =
    printfn "PMT: %f" (annuity_immediate(300000.0, 0.004166667, 240.0))
    let annuity_1 = annuity_due(100.0, 0.09 / 12.0, 7.0 * 12.0)
    printfn "Annuity Due, Future: %f" annuity_1
    printfn "The distance is %f" (get_distance(3.0, 2.0))
    let name = "Joseph Choi"
    printfn "My name is %s" name
    printfn "Ammortized monthly cost: %f" (ammortized_monthly_payment(300000.0, 0.02, 240, 1))
    printfn "Simple interest rate on $5,000 with 3%% interest over 5 years is %f" (simple_interest(5000.0, 0.03, 5))
    Console.ReadLine()
    0 // return an integer exit code
