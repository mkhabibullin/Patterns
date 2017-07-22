using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleDispatcher
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Множественная диспетчеризация или мультиметод (multiple dispatch) является вариацией концепции в ООП для выбора вызываемого метода во время исполнения, а не компиляции.

            Node node = new Document();
            //Document node = new Document();
            //Node node = new Document();
            new Sanitizer().Cleanup(node);
            
            new Sanitizer().Cleanup(node as Document);
        }

        #region Simple

        class Sanitizer
        {
            public void Cleanup(Node node) { Trace.WriteLine($"{nameof(node)} - {node.GetType().Name}"); }

            public void Cleanup(Attribute attribute) { Trace.WriteLine($"{nameof(attribute)} - {attribute.GetType().Name}"); }

            public void Cleanup(Document document) { Trace.WriteLine($"{nameof(document)} - {document.GetType().Name}"); }

            public void Cleanup(Text text) { Trace.WriteLine($"{nameof(text)} - {text.GetType().Name}"); }
        }

        class Node { }

        class Attribute : Node { }

        class Document : Node { }

        class Element : Node { }

        class Text : Node { }

        #endregion
    }
}
