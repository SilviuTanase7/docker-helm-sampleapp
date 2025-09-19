{{- define "sampleapp.name" -}}
{{ .Chart.Name | lower }}
{{- end }}

{{- define "sampleapp.fullname" -}}
{{ include "sampleapp.name" . }}-{{ .Release.Name }}
{{- end }}
