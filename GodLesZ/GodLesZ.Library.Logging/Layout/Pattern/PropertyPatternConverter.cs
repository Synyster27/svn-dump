using System;
using System.Text;
using System.IO;
using System.Collections;

using GodLesZ.Library.Logging.Core;
using GodLesZ.Library.Logging.Repository;

namespace GodLesZ.Library.Logging.Layout.Pattern {
	/// <summary>
	/// Property pattern converter
	/// </summary>
	/// <remarks>
	/// <para>
	/// Writes out the value of a named property. The property name
	/// should be set in the <see cref="GodLesZ.Library.Logging.Util.PatternConverter.Option"/>
	/// property.
	/// </para>
	/// <para>
	/// If the <see cref="GodLesZ.Library.Logging.Util.PatternConverter.Option"/> is set to <c>null</c>
	/// then all the properties are written as key value pairs.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	internal sealed class PropertyPatternConverter : PatternLayoutConverter {
		/// <summary>
		/// Write the property value to the output
		/// </summary>
		/// <param name="writer"><see cref="TextWriter" /> that will receive the formatted result.</param>
		/// <param name="loggingEvent">the event being logged</param>
		/// <remarks>
		/// <para>
		/// Writes out the value of a named property. The property name
		/// should be set in the <see cref="GodLesZ.Library.Logging.Util.PatternConverter.Option"/>
		/// property.
		/// </para>
		/// <para>
		/// If the <see cref="GodLesZ.Library.Logging.Util.PatternConverter.Option"/> is set to <c>null</c>
		/// then all the properties are written as key value pairs.
		/// </para>
		/// </remarks>
		override protected void Convert(TextWriter writer, LoggingEvent loggingEvent) {
			if (Option != null) {
				// Write the value for the specified key
				WriteObject(writer, loggingEvent.Repository, loggingEvent.LookupProperty(Option));
			} else {
				// Write all the key value pairs
				WriteDictionary(writer, loggingEvent.Repository, loggingEvent.GetProperties());
			}
		}
	}
}