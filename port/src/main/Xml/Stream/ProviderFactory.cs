#region License
//
// ProviderFactory.cs January 2010
//
// Copyright (C) 2010, Niall Gallagher <niallg@users.sf.net>
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied. See the License for the specific language governing
// permissions and limitations under the License.
//
#endregion
#region Using directives
using System;
#endregion
namespace SimpleFramework.Xml.Stream {
   /// <summary>
   /// The <c>ProviderFactory</c> object is used to instantiate a
   /// provider of XML parsing to the framework. This scans the classpath
   /// for the classes required for StAX, if they are present then this
   /// is what will be used to process XML. If however StAX can not be
   /// used then a DOM implementation is provided. A DOM provider as a
   /// default suits most Java profiles as it is a very common parser.
   /// </summary>
   /// <seealso>
   /// SimpleFramework.Xml.Stream.NodeBuilder
   /// </seealso>
   sealed class ProviderFactory {
      /// <summary>
      /// This is used to acquire the <c>Provider</c> to be used
      /// to process XML documents. The provider returned is determined
      /// by scanning the classpath for StAX dependencies, if they are
      /// available then the provider used is StAX otherwise it is DOM.
      /// Scanning the classpath in this manner ensures the most suitable
      /// parser is used for the host platform.
      /// </summary>
      /// <returns>
      /// this returns the provider that has been instantiate
      /// </returns>
      public Provider Instance {
         get {
            try {
               return new StreamProvider();
            } catch(Throwable e) {
               return new DocumentProvider();
            }
         }
      }
      //public Provider GetInstance() {
      //   try {
      //      return new StreamProvider();
      //   } catch(Throwable e) {
      //      return new DocumentProvider();
      //   }
      //}
}
