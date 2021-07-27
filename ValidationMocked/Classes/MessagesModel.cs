using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationMocked.Classes
{
    public class MessagesModel
    {
        [Key]
        [Column("ID", TypeName = "NUMBER")]
        public decimal Id { get; set; }

        [Column("ACTIVE_FLAG")]
        [StringLength(1)]
        public string ActiveFlag { get; set; }

        [Column("OCS_DB_FIELD_NAME")]
        [StringLength(50)]
        [Required]
        public string OcsDbFieldName { get; set; }

        [Column("OCS_FORM_FIELD_NAME")]
        [StringLength(100)]
        public string OcsFormFieldName { get; set; }

        [Column("OCS_FORM_FIELD_ORDER")]
        public int? OcsFormFieldOrder { get; set; }

        [Column("OCS_LANG_CODE")]
        [StringLength(2)]
        public string OcsLangCode { get; set; }

        [Column("OCS_MAIN_FRAME_MATCH")]
        [StringLength(100)]
        public string OcsMainFrameMatch { get; set; }

        [Column("OCS_MESSAGE_TXT")]
        [StringLength(2000)]
        public string OcsMessageTxt { get; set; }

        [Column("OCS_MESSAGE_TYPE_CODE")]
        [StringLength(2)]
        public string OcsMessageTypeCode { get; set; }

        [Required]
        [Column("OCSMSGCD_CODE")]
        [StringLength(2)]
        public string OcsmsgcdCode { get; set; }

        [Column("OCS_REQUIRED_FLAG")]
        [StringLength(1)]
        public string OcsRequiredFlag { get; set; }

        [Column("OCS_TEMPLATE_NAME")]
        [StringLength(250)]
        public string OcsTemplateName { get; set; }

        [Column("OCS_TEMPLATE_TITLE")]
        [StringLength(250)]
        public string OcsTemplateTitle { get; set; }

        [Column("START_DATE", TypeName = "DATE")]
        public DateTime StartDate { get; set; }

        [Column("END_DATE", TypeName = "DATE")]
        public DateTime EndDate { get; set; }

        [Column("OCS_FORM_FIELD_TYPE")]
        [StringLength(25)]
        public string OcsFormFieldType { get; set; }

        [Column("OCS_SCREEN_NAME")]
        [StringLength(45)]
        public string OcsScreenName { get; set; }

        [Column("CORRECT_ANSWER_FLAG")]
        [StringLength(1)]
        public string CorrectAnswerFlag { get; set; }


    }
}
