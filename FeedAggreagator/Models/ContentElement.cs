namespace Suyati.FeedAggreagator
{
    using XmlExtractor;

    /// <summary>
    /// The Content Element
    /// </summary>
    public class ContentElement
    {
        /// <summary>
        /// The Value
        /// </summary>
        [Value]
        public string Value { get; set; }

        /// <summary>
        /// Converting To String()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Value;
        }

        /// <summary>
        /// Enabling Implicit convertion to string
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static implicit operator string(ContentElement element)
        {
            return element.ToString();
        }
    }

    /// <summary>
    /// The Generic Content Element for Value Type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ContentElement<T> where T : struct
    {
        /// <summary>
        /// The Value
        /// </summary>
        [Value]
        public T Value { get; set; }

        /// <summary>
        /// Converting to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Value.ToString();
        }

        /// <summary>
        /// Enabling Implicit convertion to T
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static implicit operator T(ContentElement<T> element)
        {
            return element.Value;
        }
    }

    /// <summary>
    /// The Named Entity
    /// </summary>
    public class NamedEntity
    {
        /// <summary>
        /// The Name
        /// </summary>
        [Element(Name = "name")]
        public string Name { get; set; }
    }

}
