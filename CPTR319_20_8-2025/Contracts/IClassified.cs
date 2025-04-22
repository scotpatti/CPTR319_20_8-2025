namespace CPTR319_20_8_2025.Contracts
{
    /// THIS IS HERE TO MAKE SURE THE TESTS RUN DO NOT MODIFY
    /// <summary>
    /// Example Training Data: (1,2,3,A,hello,A), (1,2,10,A,stuff,B), 
    /// (2,1,1,B,Junk,A), (5,2,2,Z,dunk,C) The last value in the list
    /// denotes the class E.g. A, B, A, C for the data above. The first 
    /// 5 pieces of data are data that is to be classified. As long as 
    /// the each data set is the same length, this is a valid list. E.g. 
    /// adding an additional element of {1,2,3,A} would be invalid because
    /// the cardinality is 4, whereas all the other elements have a 
    /// cardinality of 6. 
    /// </summary> 
    public interface IClassified
    {
        /// E.g. [1, 2, 3, A, Hello] in the first training datam above.
        List<string> Attributes { get; set; }

        /// Used to store the class E.g. A in the first training datam above.
        string Class { get; set; }
    }
}
