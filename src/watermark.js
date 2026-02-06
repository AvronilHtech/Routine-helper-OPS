/**
 * Anti-piracy watermark utilities.
 * Watermark owner: Avronil Htech
 */

export const WATERMARK = "Avronil Htech";

/**
 * Adds a visible watermark banner to generated text output.
 * @param {string} content
 * @returns {string}
 */
export function withWatermark(content) {
  return `${content}\n\n---\nWatermark: ${WATERMARK}`;
}
