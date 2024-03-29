﻿namespace AplixaTools.PDFEdit.Models;

/// <summary>
/// Contains custom ICC color profiles
/// </summary>
public static class IccProfiles
{
    /// <summary>
    /// The sRGB Profile required for PDF/A-3a
    /// </summary>
    public static readonly byte[] SRgbIec6196621 = {
      0x00, 0x00, 0x0b, 0xec, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x6d, 0x6e, 0x74, 0x72,
      0x52, 0x47, 0x42, 0x20, 0x58, 0x59, 0x5a, 0x20, 0x07, 0xd9, 0x00, 0x03, 0x00, 0x1b, 0x00, 0x15,
      0x00, 0x25, 0x00, 0x2d, 0x61, 0x63, 0x73, 0x70, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0xf6, 0xd6, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0xd3, 0x2d,
      0x00, 0x00, 0x00, 0x00, 0xc9, 0x5b, 0xd6, 0x37, 0xe9, 0x5d, 0x8a, 0x3b, 0x0d, 0xf3, 0x8f, 0x99,
      0xc1, 0x32, 0x03, 0x89, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x10, 0x64, 0x65, 0x73, 0x63, 0x00, 0x00, 0x01, 0x44, 0x00, 0x00, 0x00, 0x7d,
      0x62, 0x58, 0x59, 0x5a, 0x00, 0x00, 0x01, 0xc4, 0x00, 0x00, 0x00, 0x14, 0x62, 0x54, 0x52, 0x43,
      0x00, 0x00, 0x01, 0xd8, 0x00, 0x00, 0x08, 0x0c, 0x64, 0x6d, 0x64, 0x64, 0x00, 0x00, 0x09, 0xe4,
      0x00, 0x00, 0x00, 0x88, 0x67, 0x58, 0x59, 0x5a, 0x00, 0x00, 0x0a, 0x6c, 0x00, 0x00, 0x00, 0x14,
      0x67, 0x54, 0x52, 0x43, 0x00, 0x00, 0x01, 0xd8, 0x00, 0x00, 0x08, 0x0c, 0x6c, 0x75, 0x6d, 0x69,
      0x00, 0x00, 0x0a, 0x80, 0x00, 0x00, 0x00, 0x14, 0x6d, 0x65, 0x61, 0x73, 0x00, 0x00, 0x0a, 0x94,
      0x00, 0x00, 0x00, 0x24, 0x62, 0x6b, 0x70, 0x74, 0x00, 0x00, 0x0a, 0xb8, 0x00, 0x00, 0x00, 0x14,
      0x72, 0x58, 0x59, 0x5a, 0x00, 0x00, 0x0a, 0xcc, 0x00, 0x00, 0x00, 0x14, 0x72, 0x54, 0x52, 0x43,
      0x00, 0x00, 0x01, 0xd8, 0x00, 0x00, 0x08, 0x0c, 0x74, 0x65, 0x63, 0x68, 0x00, 0x00, 0x0a, 0xe0,
      0x00, 0x00, 0x00, 0x0c, 0x76, 0x75, 0x65, 0x64, 0x00, 0x00, 0x0a, 0xec, 0x00, 0x00, 0x00, 0x87,
      0x77, 0x74, 0x70, 0x74, 0x00, 0x00, 0x0b, 0x74, 0x00, 0x00, 0x00, 0x14, 0x63, 0x70, 0x72, 0x74,
      0x00, 0x00, 0x0b, 0x88, 0x00, 0x00, 0x00, 0x37, 0x63, 0x68, 0x61, 0x64, 0x00, 0x00, 0x0b, 0xc0,
      0x00, 0x00, 0x00, 0x2c, 0x64, 0x65, 0x73, 0x63, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x23,
      0x73, 0x52, 0x47, 0x42, 0x20, 0x49, 0x45, 0x43, 0x36, 0x31, 0x39, 0x36, 0x36, 0x2d, 0x32, 0x2d,
      0x31, 0x20, 0x6e, 0x6f, 0x20, 0x62, 0x6c, 0x61, 0x63, 0x6b, 0x20, 0x73, 0x63, 0x61, 0x6c, 0x69,
      0x6e, 0x67, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x58, 0x59, 0x5a, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x24, 0xa0,
      0x00, 0x00, 0x0f, 0x84, 0x00, 0x00, 0xb6, 0xcf, 0x63, 0x75, 0x72, 0x76, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x04, 0x00, 0x03, 0x33, 0x03, 0x38, 0x03, 0x3d, 0x03, 0x42, 0x03, 0x47, 0x03, 0x4c,
      0x03, 0x51, 0x03, 0x56, 0x03, 0x5b, 0x03, 0x60, 0x03, 0x65, 0x03, 0x69, 0x03, 0x6d, 0x03, 0x72,
      0x03, 0x77, 0x03, 0x7c, 0x03, 0x81, 0x03, 0x86, 0x03, 0x8b, 0x03, 0x90, 0x03, 0x95, 0x03, 0x9a,
      0x03, 0x9f, 0x03, 0xa4, 0x03, 0xa9, 0x03, 0xae, 0x03, 0xb3, 0x03, 0xb8, 0x03, 0xbc, 0x03, 0xc1,
      0x03, 0xc6, 0x03, 0xcb, 0x03, 0xd0, 0x03, 0xd5, 0x03, 0xda, 0x03, 0xdf, 0x03, 0xe3, 0x03, 0xe8,
      0x03, 0xed, 0x03, 0xf2, 0x03, 0xf7, 0x03, 0xfc, 0x04, 0x01, 0x04, 0x06, 0x04, 0x0b, 0x04, 0x10,
      0x04, 0x15, 0x04, 0x1b, 0x04, 0x20, 0x04, 0x26, 0x04, 0x2b, 0x04, 0x31, 0x04, 0x37, 0x04, 0x3d,
      0x04, 0x43, 0x04, 0x49, 0x04, 0x4f, 0x04, 0x55, 0x04, 0x5a, 0x04, 0x61, 0x04, 0x67, 0x04, 0x6d,
      0x04, 0x74, 0x04, 0x7b, 0x04, 0x81, 0x04, 0x88, 0x04, 0x8f, 0x04, 0x96, 0x04, 0x9d, 0x04, 0xa4,
      0x04, 0xaa, 0x04, 0xb1, 0x04, 0xb9, 0x04, 0xc0, 0x04, 0xc8, 0x04, 0xcf, 0x04, 0xd7, 0x04, 0xdf,
      0x04, 0xe7, 0x04, 0xef, 0x04, 0xf6, 0x04, 0xfe, 0x05, 0x06, 0x05, 0x0e, 0x05, 0x16, 0x05, 0x1f,
      0x05, 0x27, 0x05, 0x30, 0x05, 0x39, 0x05, 0x41, 0x05, 0x49, 0x05, 0x52, 0x05, 0x5b, 0x05, 0x64,
      0x05, 0x6d, 0x05, 0x77, 0x05, 0x80, 0x05, 0x89, 0x05, 0x92, 0x05, 0x9c, 0x05, 0xa5, 0x05, 0xaf,
      0x05, 0xb9, 0x05, 0xc3, 0x05, 0xcd, 0x05, 0xd7, 0x05, 0xe1, 0x05, 0xeb, 0x05, 0xf5, 0x05, 0xff,
      0x06, 0x0a, 0x06, 0x15, 0x06, 0x1f, 0x06, 0x2a, 0x06, 0x34, 0x06, 0x3f, 0x06, 0x4a, 0x06, 0x56,
      0x06, 0x61, 0x06, 0x6c, 0x06, 0x78, 0x06, 0x82, 0x06, 0x8e, 0x06, 0x9a, 0x06, 0xa6, 0x06, 0xb2,
      0x06, 0xbe, 0x06, 0xca, 0x06, 0xd5, 0x06, 0xe1, 0x06, 0xee, 0x06, 0xfa, 0x07, 0x07, 0x07, 0x13,
      0x07, 0x1f, 0x07, 0x2c, 0x07, 0x39, 0x07, 0x46, 0x07, 0x53, 0x07, 0x61, 0x07, 0x6d, 0x07, 0x7a,
      0x07, 0x88, 0x07, 0x96, 0x07, 0xa3, 0x07, 0xb1, 0x07, 0xbe, 0x07, 0xcc, 0x07, 0xda, 0x07, 0xe8,
      0x07, 0xf7, 0x08, 0x05, 0x08, 0x13, 0x08, 0x21, 0x08, 0x30, 0x08, 0x3f, 0x08, 0x4e, 0x08, 0x5c,
      0x08, 0x6b, 0x08, 0x7a, 0x08, 0x89, 0x08, 0x99, 0x08, 0xa7, 0x08, 0xb7, 0x08, 0xc7, 0x08, 0xd6,
      0x08, 0xe6, 0x08, 0xf6, 0x09, 0x05, 0x09, 0x16, 0x09, 0x26, 0x09, 0x36, 0x09, 0x47, 0x09, 0x56,
      0x09, 0x67, 0x09, 0x78, 0x09, 0x89, 0x09, 0x99, 0x09, 0xaa, 0x09, 0xbb, 0x09, 0xcd, 0x09, 0xde,
      0x09, 0xee, 0x0a, 0x00, 0x0a, 0x12, 0x0a, 0x24, 0x0a, 0x35, 0x0a, 0x47, 0x0a, 0x59, 0x0a, 0x6b,
      0x0a, 0x7d, 0x0a, 0x8f, 0x0a, 0xa1, 0x0a, 0xb4, 0x0a, 0xc7, 0x0a, 0xd9, 0x0a, 0xec, 0x0a, 0xff,
      0x0b, 0x12, 0x0b, 0x24, 0x0b, 0x38, 0x0b, 0x4b, 0x0b, 0x5f, 0x0b, 0x72, 0x0b, 0x86, 0x0b, 0x9a,
      0x0b, 0xae, 0x0b, 0xc1, 0x0b, 0xd5, 0x0b, 0xe9, 0x0b, 0xfe, 0x0c, 0x11, 0x0c, 0x26, 0x0c, 0x3b,
      0x0c, 0x50, 0x0c, 0x64, 0x0c, 0x79, 0x0c, 0x8e, 0x0c, 0xa4, 0x0c, 0xb8, 0x0c, 0xce, 0x0c, 0xe3,
      0x0c, 0xf9, 0x0d, 0x0e, 0x0d, 0x24, 0x0d, 0x3a, 0x0d, 0x4f, 0x0d, 0x66, 0x0d, 0x7c, 0x0d, 0x93,
      0x0d, 0xa9, 0x0d, 0xbf, 0x0d, 0xd6, 0x0d, 0xec, 0x0e, 0x03, 0x0e, 0x1b, 0x0e, 0x32, 0x0e, 0x48,
      0x0e, 0x60, 0x0e, 0x78, 0x0e, 0x8e, 0x0e, 0xa6, 0x0e, 0xbe, 0x0e, 0xd5, 0x0e, 0xee, 0x0f, 0x06,
      0x0f, 0x1f, 0x0f, 0x36, 0x0f, 0x4f, 0x0f, 0x68, 0x0f, 0x80, 0x0f, 0x99, 0x0f, 0xb2, 0x0f, 0xca,
      0x0f, 0xe3, 0x0f, 0xfd, 0x10, 0x16, 0x10, 0x2f, 0x10, 0x49, 0x10, 0x62, 0x10, 0x7c, 0x10, 0x96,
      0x10, 0xb0, 0x10, 0xca, 0x10, 0xe5, 0x10, 0xfe, 0x11, 0x19, 0x11, 0x34, 0x11, 0x4e, 0x11, 0x69,
      0x11, 0x84, 0x11, 0x9f, 0x11, 0xba, 0x11, 0xd6, 0x11, 0xf1, 0x12, 0x0c, 0x12, 0x28, 0x12, 0x43,
      0x12, 0x60, 0x12, 0x7c, 0x12, 0x97, 0x12, 0xb4, 0x12, 0xd0, 0x12, 0xec, 0x13, 0x09, 0x13, 0x26,
      0x13, 0x42, 0x13, 0x60, 0x13, 0x7c, 0x13, 0x99, 0x13, 0xb7, 0x13, 0xd4, 0x13, 0xf2, 0x14, 0x10,
      0x14, 0x2d, 0x14, 0x4b, 0x14, 0x68, 0x14, 0x87, 0x14, 0xa5, 0x14, 0xc3, 0x14, 0xe2, 0x15, 0x00,
      0x15, 0x1f, 0x15, 0x3e, 0x15, 0x5c, 0x15, 0x7c, 0x15, 0x9b, 0x15, 0xba, 0x15, 0xda, 0x15, 0xf9,
      0x16, 0x19, 0x16, 0x39, 0x16, 0x58, 0x16, 0x78, 0x16, 0x98, 0x16, 0xb9, 0x16, 0xd9, 0x16, 0xf9,
      0x17, 0x1a, 0x17, 0x3b, 0x17, 0x5c, 0x17, 0x7c, 0x17, 0x9e, 0x17, 0xbf, 0x17, 0xe0, 0x18, 0x02,
      0x18, 0x23, 0x18, 0x45, 0x18, 0x67, 0x18, 0x89, 0x18, 0xab, 0x18, 0xcd, 0x18, 0xf0, 0x19, 0x12,
      0x19, 0x35, 0x19, 0x57, 0x19, 0x7a, 0x19, 0x9d, 0x19, 0xc0, 0x19, 0xe4, 0x1a, 0x06, 0x1a, 0x2a,
      0x1a, 0x4d, 0x1a, 0x71, 0x1a, 0x95, 0x1a, 0xb9, 0x1a, 0xdd, 0x1b, 0x01, 0x1b, 0x26, 0x1b, 0x4a,
      0x1b, 0x6f, 0x1b, 0x93, 0x1b, 0xb9, 0x1b, 0xdd, 0x1c, 0x03, 0x1c, 0x27, 0x1c, 0x4d, 0x1c, 0x72,
      0x1c, 0x98, 0x1c, 0xbd, 0x1c, 0xe4, 0x1d, 0x09, 0x1d, 0x30, 0x1d, 0x56, 0x1d, 0x7c, 0x1d, 0xa3,
      0x1d, 0xc9, 0x1d, 0xf1, 0x1e, 0x17, 0x1e, 0x3f, 0x1e, 0x65, 0x1e, 0x8d, 0x1e, 0xb4, 0x1e, 0xdc,
      0x1f, 0x03, 0x1f, 0x2b, 0x1f, 0x53, 0x1f, 0x7b, 0x1f, 0xa3, 0x1f, 0xcc, 0x1f, 0xf4, 0x20, 0x1c,
      0x20, 0x45, 0x20, 0x6e, 0x20, 0x97, 0x20, 0xbf, 0x20, 0xe9, 0x21, 0x12, 0x21, 0x3c, 0x21, 0x65,
      0x21, 0x8f, 0x21, 0xb9, 0x21, 0xe3, 0x22, 0x0d, 0x22, 0x38, 0x22, 0x62, 0x22, 0x8d, 0x22, 0xb7,
      0x22, 0xe2, 0x23, 0x0d, 0x23, 0x37, 0x23, 0x63, 0x23, 0x8e, 0x23, 0xba, 0x23, 0xe5, 0x24, 0x11,
      0x24, 0x3d, 0x24, 0x69, 0x24, 0x95, 0x24, 0xc1, 0x24, 0xed, 0x25, 0x1a, 0x25, 0x47, 0x25, 0x73,
      0x25, 0xa1, 0x25, 0xcd, 0x25, 0xfa, 0x26, 0x28, 0x26, 0x55, 0x26, 0x83, 0x26, 0xb0, 0x26, 0xdf,
      0x27, 0x0c, 0x27, 0x3a, 0x27, 0x69, 0x27, 0x97, 0x27, 0xc6, 0x27, 0xf4, 0x28, 0x23, 0x28, 0x52,
      0x28, 0x81, 0x28, 0xb1, 0x28, 0xe0, 0x29, 0x0f, 0x29, 0x3f, 0x29, 0x6e, 0x29, 0x9f, 0x29, 0xce,
      0x29, 0xfe, 0x2a, 0x2f, 0x2a, 0x5f, 0x2a, 0x90, 0x2a, 0xc0, 0x2a, 0xf1, 0x2b, 0x23, 0x2b, 0x53,
      0x2b, 0x85, 0x2b, 0xb6, 0x2b, 0xe7, 0x2c, 0x1a, 0x2c, 0x4b, 0x2c, 0x7d, 0x2c, 0xaf, 0x2c, 0xe1,
      0x2d, 0x13, 0x2d, 0x46, 0x2d, 0x79, 0x2d, 0xac, 0x2d, 0xdf, 0x2e, 0x11, 0x2e, 0x45, 0x2e, 0x78,
      0x2e, 0xab, 0x2e, 0xdf, 0x2f, 0x13, 0x2f, 0x46, 0x2f, 0x7b, 0x2f, 0xaf, 0x2f, 0xe3, 0x30, 0x18,
      0x30, 0x4c, 0x30, 0x81, 0x30, 0xb6, 0x30, 0xeb, 0x31, 0x20, 0x31, 0x55, 0x31, 0x8b, 0x31, 0xc0,
      0x31, 0xf6, 0x32, 0x2c, 0x32, 0x61, 0x32, 0x98, 0x32, 0xce, 0x33, 0x04, 0x33, 0x3c, 0x33, 0x72,
      0x33, 0xa8, 0x33, 0xdf, 0x34, 0x17, 0x34, 0x4e, 0x34, 0x85, 0x34, 0xbd, 0x34, 0xf5, 0x35, 0x2c,
      0x35, 0x65, 0x35, 0x9d, 0x35, 0xd5, 0x36, 0x0d, 0x36, 0x46, 0x36, 0x7e, 0x36, 0xb7, 0x36, 0xf1,
      0x37, 0x29, 0x37, 0x62, 0x37, 0x9c, 0x37, 0xd6, 0x38, 0x0f, 0x38, 0x49, 0x38, 0x83, 0x38, 0xbd,
      0x38, 0xf7, 0x39, 0x32, 0x39, 0x6c, 0x39, 0xa7, 0x39, 0xe2, 0x3a, 0x1d, 0x3a, 0x58, 0x3a, 0x94,
      0x3a, 0xcf, 0x3b, 0x0a, 0x3b, 0x45, 0x3b, 0x82, 0x3b, 0xbe, 0x3b, 0xfa, 0x3c, 0x36, 0x3c, 0x73,
      0x3c, 0xaf, 0x3c, 0xec, 0x3d, 0x29, 0x3d, 0x66, 0x3d, 0xa3, 0x3d, 0xe0, 0x3e, 0x1e, 0x3e, 0x5b,
      0x3e, 0x9a, 0x3e, 0xd7, 0x3f, 0x15, 0x3f, 0x53, 0x3f, 0x92, 0x3f, 0xd0, 0x40, 0x0f, 0x40, 0x4d,
      0x40, 0x8c, 0x40, 0xcc, 0x41, 0x0b, 0x41, 0x4a, 0x41, 0x8a, 0x41, 0xc9, 0x42, 0x0a, 0x42, 0x49,
      0x42, 0x89, 0x42, 0xc9, 0x43, 0x0a, 0x43, 0x4b, 0x43, 0x8c, 0x43, 0xcc, 0x44, 0x0d, 0x44, 0x4e,
      0x44, 0x8f, 0x44, 0xd1, 0x45, 0x13, 0x45, 0x54, 0x45, 0x96, 0x45, 0xd8, 0x46, 0x1a, 0x46, 0x5d,
      0x46, 0xa0, 0x46, 0xe2, 0x47, 0x25, 0x47, 0x68, 0x47, 0xaa, 0x47, 0xee, 0x48, 0x32, 0x48, 0x75,
      0x48, 0xb9, 0x48, 0xfc, 0x49, 0x40, 0x49, 0x84, 0x49, 0xc9, 0x4a, 0x0e, 0x4a, 0x52, 0x4a, 0x97,
      0x4a, 0xdc, 0x4b, 0x21, 0x4b, 0x66, 0x4b, 0xab, 0x4b, 0xf0, 0x4c, 0x37, 0x4c, 0x7d, 0x4c, 0xc2,
      0x4d, 0x08, 0x4d, 0x4f, 0x4d, 0x95, 0x4d, 0xdb, 0x4e, 0x22, 0x4e, 0x69, 0x4e, 0xb1, 0x4e, 0xf8,
      0x4f, 0x3f, 0x4f, 0x86, 0x4f, 0xce, 0x50, 0x16, 0x50, 0x5e, 0x50, 0xa6, 0x50, 0xee, 0x51, 0x36,
      0x51, 0x7e, 0x51, 0xc8, 0x52, 0x11, 0x52, 0x5a, 0x52, 0xa3, 0x52, 0xec, 0x53, 0x36, 0x53, 0x7f,
      0x53, 0xc9, 0x54, 0x13, 0x54, 0x5d, 0x54, 0xa7, 0x54, 0xf1, 0x55, 0x3c, 0x55, 0x87, 0x55, 0xd1,
      0x56, 0x1c, 0x56, 0x68, 0x56, 0xb4, 0x56, 0xff, 0x57, 0x4b, 0x57, 0x97, 0x57, 0xe3, 0x58, 0x2f,
      0x58, 0x7b, 0x58, 0xc7, 0x59, 0x14, 0x59, 0x60, 0x59, 0xad, 0x59, 0xfa, 0x5a, 0x48, 0x5a, 0x95,
      0x5a, 0xe2, 0x5b, 0x30, 0x5b, 0x7e, 0x5b, 0xcc, 0x5c, 0x1a, 0x5c, 0x68, 0x5c, 0xb7, 0x5d, 0x05,
      0x5d, 0x54, 0x5d, 0xa3, 0x5d, 0xf2, 0x5e, 0x41, 0x5e, 0x91, 0x5e, 0xe0, 0x5f, 0x30, 0x5f, 0x80,
      0x5f, 0xd0, 0x60, 0x20, 0x60, 0x71, 0x60, 0xc1, 0x61, 0x12, 0x61, 0x63, 0x61, 0xb4, 0x62, 0x05,
      0x62, 0x56, 0x62, 0xa8, 0x62, 0xf9, 0x63, 0x4b, 0x63, 0x9d, 0x63, 0xef, 0x64, 0x42, 0x64, 0x94,
      0x64, 0xe7, 0x65, 0x39, 0x65, 0x8c, 0x65, 0xde, 0x66, 0x32, 0x66, 0x85, 0x66, 0xd9, 0x67, 0x2c,
      0x67, 0x80, 0x67, 0xd4, 0x68, 0x29, 0x68, 0x7d, 0x68, 0xd2, 0x69, 0x26, 0x69, 0x7b, 0x69, 0xd0,
      0x6a, 0x25, 0x6a, 0x7b, 0x6a, 0xcf, 0x6b, 0x25, 0x6b, 0x7b, 0x6b, 0xd1, 0x6c, 0x27, 0x6c, 0x7d,
      0x6c, 0xd4, 0x6d, 0x2b, 0x6d, 0x82, 0x6d, 0xd9, 0x6e, 0x30, 0x6e, 0x86, 0x6e, 0xde, 0x6f, 0x35,
      0x6f, 0x8d, 0x6f, 0xe5, 0x70, 0x3d, 0x70, 0x95, 0x70, 0xee, 0x71, 0x46, 0x71, 0x9e, 0x71, 0xf7,
      0x72, 0x51, 0x72, 0xaa, 0x73, 0x03, 0x73, 0x5d, 0x73, 0xb7, 0x74, 0x10, 0x74, 0x6a, 0x74, 0xc4,
      0x75, 0x1f, 0x75, 0x79, 0x75, 0xd4, 0x76, 0x2f, 0x76, 0x89, 0x76, 0xe4, 0x77, 0x40, 0x77, 0x9b,
      0x77, 0xf7, 0x78, 0x53, 0x78, 0xaf, 0x79, 0x0b, 0x79, 0x67, 0x79, 0xc4, 0x7a, 0x20, 0x7a, 0x7d,
      0x7a, 0xd9, 0x7b, 0x37, 0x7b, 0x94, 0x7b, 0xf2, 0x7c, 0x50, 0x7c, 0xae, 0x7d, 0x0b, 0x7d, 0x69,
      0x7d, 0xc7, 0x7e, 0x26, 0x7e, 0x85, 0x7e, 0xe3, 0x7f, 0x42, 0x7f, 0xa1, 0x80, 0x01, 0x80, 0x60,
      0x80, 0xbf, 0x81, 0x1f, 0x81, 0x7f, 0x81, 0xe0, 0x82, 0x3f, 0x82, 0xa0, 0x83, 0x00, 0x83, 0x61,
      0x83, 0xc3, 0x84, 0x23, 0x84, 0x84, 0x84, 0xe6, 0x85, 0x48, 0x85, 0xa9, 0x86, 0x0b, 0x86, 0x6d,
      0x86, 0xd0, 0x87, 0x32, 0x87, 0x94, 0x87, 0xf7, 0x88, 0x5b, 0x88, 0xbd, 0x89, 0x20, 0x89, 0x84,
      0x89, 0xe8, 0x8a, 0x4b, 0x8a, 0xaf, 0x8b, 0x14, 0x8b, 0x78, 0x8b, 0xdc, 0x8c, 0x41, 0x8c, 0xa6,
      0x8d, 0x0b, 0x8d, 0x6f, 0x8d, 0xd5, 0x8e, 0x3b, 0x8e, 0xa0, 0x8f, 0x06, 0x8f, 0x6c, 0x8f, 0xd1,
      0x90, 0x38, 0x90, 0x9f, 0x91, 0x06, 0x91, 0x6c, 0x91, 0xd3, 0x92, 0x3a, 0x92, 0xa1, 0x93, 0x09,
      0x93, 0x71, 0x93, 0xd8, 0x94, 0x40, 0x94, 0xa9, 0x95, 0x11, 0x95, 0x79, 0x95, 0xe2, 0x96, 0x4b,
      0x96, 0xb4, 0x97, 0x1d, 0x97, 0x87, 0x97, 0xf0, 0x98, 0x5a, 0x98, 0xc4, 0x99, 0x2d, 0x99, 0x98,
      0x9a, 0x03, 0x9a, 0x6d, 0x9a, 0xd8, 0x9b, 0x42, 0x9b, 0xad, 0x9c, 0x19, 0x9c, 0x84, 0x9c, 0xf0,
      0x9d, 0x5c, 0x9d, 0xc7, 0x9e, 0x34, 0x9e, 0xa0, 0x9f, 0x0c, 0x9f, 0x79, 0x9f, 0xe5, 0xa0, 0x53,
      0xa0, 0xc0, 0xa1, 0x2d, 0xa1, 0x9b, 0xa2, 0x08, 0xa2, 0x76, 0xa2, 0xe4, 0xa3, 0x52, 0xa3, 0xc1,
      0xa4, 0x30, 0xa4, 0x9e, 0xa5, 0x0d, 0xa5, 0x7b, 0xa5, 0xeb, 0xa6, 0x5b, 0xa6, 0xca, 0xa7, 0x3a,
      0xa7, 0xa9, 0xa8, 0x1a, 0xa8, 0x89, 0xa8, 0xfa, 0xa9, 0x6b, 0xa9, 0xdb, 0xaa, 0x4d, 0xaa, 0xbd,
      0xab, 0x2f, 0xab, 0xa0, 0xac, 0x12, 0xac, 0x84, 0xac, 0xf6, 0xad, 0x68, 0xad, 0xda, 0xae, 0x4d,
      0xae, 0xbf, 0xaf, 0x33, 0xaf, 0xa5, 0xb0, 0x19, 0xb0, 0x8c, 0xb1, 0x00, 0xb1, 0x74, 0xb1, 0xe7,
      0xb2, 0x5c, 0xb2, 0xd0, 0xb3, 0x44, 0xb3, 0xb9, 0xb4, 0x2e, 0xb4, 0xa2, 0xb5, 0x18, 0xb5, 0x8d,
      0xb6, 0x03, 0xb6, 0x78, 0xb6, 0xee, 0xb7, 0x64, 0xb7, 0xda, 0xb8, 0x50, 0xb8, 0xc7, 0xb9, 0x3e,
      0xb9, 0xb5, 0xba, 0x2c, 0xba, 0xa3, 0xbb, 0x1a, 0xbb, 0x93, 0xbc, 0x0a, 0xbc, 0x82, 0xbc, 0xfa,
      0xbd, 0x73, 0xbd, 0xeb, 0xbe, 0x64, 0xbe, 0xdd, 0xbf, 0x56, 0xbf, 0xcf, 0xc0, 0x48, 0xc0, 0xc2,
      0xc1, 0x3b, 0xc1, 0xb6, 0xc2, 0x2f, 0xc2, 0xaa, 0xc3, 0x24, 0xc3, 0x9f, 0xc4, 0x1a, 0xc4, 0x95,
      0xc5, 0x10, 0xc5, 0x8b, 0xc6, 0x07, 0xc6, 0x82, 0xc6, 0xff, 0xc7, 0x7a, 0xc7, 0xf7, 0xc8, 0x73,
      0xc8, 0xef, 0xc9, 0x6d, 0xc9, 0xe9, 0xca, 0x67, 0xca, 0xe4, 0xcb, 0x62, 0xcb, 0xdf, 0xcc, 0x5d,
      0xcc, 0xdb, 0xcd, 0x59, 0xcd, 0xd8, 0xce, 0x56, 0xce, 0xd5, 0xcf, 0x54, 0xcf, 0xd3, 0xd0, 0x53,
      0xd0, 0xd2, 0xd1, 0x51, 0xd1, 0xd2, 0xd2, 0x52, 0xd2, 0xd1, 0xd3, 0x52, 0xd3, 0xd3, 0xd4, 0x54,
      0xd4, 0xd5, 0xd5, 0x55, 0xd5, 0xd7, 0xd6, 0x58, 0xd6, 0xda, 0xd7, 0x5c, 0xd7, 0xde, 0xd8, 0x60,
      0xd8, 0xe3, 0xd9, 0x65, 0xd9, 0xe7, 0xda, 0x6b, 0xda, 0xee, 0xdb, 0x71, 0xdb, 0xf5, 0xdc, 0x78,
      0xdc, 0xfb, 0xdd, 0x80, 0xde, 0x04, 0xde, 0x88, 0xdf, 0x0d, 0xdf, 0x92, 0xe0, 0x16, 0xe0, 0x9c,
      0xe1, 0x21, 0xe1, 0xa6, 0xe2, 0x2d, 0xe2, 0xb2, 0xe3, 0x38, 0xe3, 0xbf, 0xe4, 0x45, 0xe4, 0xcb,
      0xe5, 0x52, 0xe5, 0xd9, 0xe6, 0x60, 0xe6, 0xe7, 0xe7, 0x6f, 0xe7, 0xf7, 0xe8, 0x7e, 0xe9, 0x06,
      0xe9, 0x8f, 0xea, 0x17, 0xea, 0xa0, 0xeb, 0x29, 0xeb, 0xb2, 0xec, 0x3b, 0xec, 0xc4, 0xed, 0x4e,
      0xed, 0xd7, 0xee, 0x61, 0xee, 0xeb, 0xef, 0x76, 0xf0, 0x00, 0xf0, 0x8a, 0xf1, 0x15, 0xf1, 0xa1,
      0xf2, 0x2c, 0xf2, 0xb7, 0xf3, 0x42, 0xf3, 0xce, 0xf4, 0x5a, 0xf4, 0xe6, 0xf5, 0x72, 0xf5, 0xfe,
      0xf6, 0x8c, 0xf7, 0x18, 0xf7, 0xa5, 0xf8, 0x32, 0xf8, 0xbf, 0xf9, 0x4e, 0xf9, 0xdb, 0xfa, 0x69,
      0xfa, 0xf7, 0xfb, 0x86, 0xfc, 0x14, 0xfc, 0xa3, 0xfd, 0x32, 0xfd, 0xc1, 0xfe, 0x50, 0xfe, 0xe0,
      0xff, 0x6f, 0xff, 0xff, 0x64, 0x65, 0x73, 0x63, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2e,
      0x49, 0x45, 0x43, 0x20, 0x36, 0x31, 0x39, 0x36, 0x36, 0x2d, 0x32, 0x2d, 0x31, 0x20, 0x44, 0x65,
      0x66, 0x61, 0x75, 0x6c, 0x74, 0x20, 0x52, 0x47, 0x42, 0x20, 0x43, 0x6f, 0x6c, 0x6f, 0x75, 0x72,
      0x20, 0x53, 0x70, 0x61, 0x63, 0x65, 0x20, 0x2d, 0x20, 0x73, 0x52, 0x47, 0x42, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x58, 0x59, 0x5a, 0x20,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x62, 0x99, 0x00, 0x00, 0xb7, 0x85, 0x00, 0x00, 0x18, 0xda,
      0x58, 0x59, 0x5a, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x50, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x6d, 0x65, 0x61, 0x73, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x58, 0x59, 0x5a, 0x20, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x03, 0x16, 0x00, 0x00, 0x03, 0x33, 0x00, 0x00, 0x02, 0xa4, 0x58, 0x59, 0x5a, 0x20,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x6f, 0xa2, 0x00, 0x00, 0x38, 0xf5, 0x00, 0x00, 0x03, 0x90,
      0x73, 0x69, 0x67, 0x20, 0x00, 0x00, 0x00, 0x00, 0x43, 0x52, 0x54, 0x20, 0x64, 0x65, 0x73, 0x63,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2d, 0x52, 0x65, 0x66, 0x65, 0x72, 0x65, 0x6e, 0x63,
      0x65, 0x20, 0x56, 0x69, 0x65, 0x77, 0x69, 0x6e, 0x67, 0x20, 0x43, 0x6f, 0x6e, 0x64, 0x69, 0x74,
      0x69, 0x6f, 0x6e, 0x20, 0x69, 0x6e, 0x20, 0x49, 0x45, 0x43, 0x20, 0x36, 0x31, 0x39, 0x36, 0x36,
      0x2d, 0x32, 0x2d, 0x31, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
      0x00, 0x00, 0x00, 0x00, 0x58, 0x59, 0x5a, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xf6, 0xd6,
      0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0xd3, 0x2d, 0x74, 0x65, 0x78, 0x74, 0x00, 0x00, 0x00, 0x00,
      0x43, 0x6f, 0x70, 0x79, 0x72, 0x69, 0x67, 0x68, 0x74, 0x20, 0x49, 0x6e, 0x74, 0x65, 0x72, 0x6e,
      0x61, 0x74, 0x69, 0x6f, 0x6e, 0x61, 0x6c, 0x20, 0x43, 0x6f, 0x6c, 0x6f, 0x72, 0x20, 0x43, 0x6f,
      0x6e, 0x73, 0x6f, 0x72, 0x74, 0x69, 0x75, 0x6d, 0x2c, 0x20, 0x32, 0x30, 0x30, 0x39, 0x00, 0x00,
      0x73, 0x66, 0x33, 0x32, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x0c, 0x44, 0x00, 0x00, 0x05, 0xdf,
      0xff, 0xff, 0xf3, 0x26, 0x00, 0x00, 0x07, 0x94, 0x00, 0x00, 0xfd, 0x8f, 0xff, 0xff, 0xfb, 0xa1,
      0xff, 0xff, 0xfd, 0xa2, 0x00, 0x00, 0x03, 0xdb, 0x00, 0x00, 0xc0, 0x75
    };
}
