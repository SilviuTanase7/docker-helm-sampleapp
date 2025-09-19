{{- define "SampleApp.name" -}}
{{ .Chart.Name | lower }}
{{- end }}

{{- define "SampleApp.fullname" -}}
{{ include "SampleApp.name" . }}-{{ .Release.Name }}
{{- end }}
